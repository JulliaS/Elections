using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Vybory.Models;

namespace Vybory.Controllers
{
    public class VoteController : Controller
    {
        private IUnitOfWork db;

        public VoteController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        [HttpGet]
        public IActionResult StartVote()
        {
            bool is_now = true;
            var citizens = db.Citizens.GetAll();
            int choosen_el_id = 0;
            try
            {
                var electoin = db.Elections.Find(el => el.StartVote <= DateTime.Now && el.EndVote >= DateTime.Now && el.Year == DateTime.Now.Year).First();
                choosen_el_id = electoin.Id;
            }
            catch
            {
                is_now = false;
            }
            List<User> users = new List<User>();

            if (!is_now)
            {
                try
                {
                    var electoin = db.Elections.Find(el => el.StartVote >= DateTime.Now && el.Year == DateTime.Now.Year).Min();
                    if (electoin != null)
                    {
                        return View("TillElection", electoin);
                    }
                    else
                    {
                        return View();
                    }
                }
                catch
                {
                    return View("AnyPlanElection");
                }
            }
            else
            {
                foreach (var citizen in citizens)
                {
                    var candidats = db.Candidats.Find(cand => cand.CitizenId == citizen.Id && cand.ElectionId == choosen_el_id).ToList();
                    if (candidats.Count != 0)
                    {
                        foreach (var candidat in candidats)
                        {
                            users.Add(db.Users.Get((int)candidat.CitizenId));
                        }
                    }

                };

                return View(users);
            }
        }

        [HttpPost]
        public IActionResult StartVote(string cndt)
        {
            var userId = Convert.ToInt16(User.Claims.Where(x => x.Type == "userId").First().Value);
            var votes = db.Votes.GetAll();
            var electoin = db.Elections.Find(el => el.StartVote <= DateTime.Now && el.EndVote >= DateTime.Now && el.Year == DateTime.Now.Year).First();
            var citizen = db.Citizens.Get(userId);
            var candidatIdInCetizenTable = Convert.ToInt32(cndt);
            var candidat = db.Candidats.Find(cand => cand.CitizenId == candidatIdInCetizenTable).First();
            foreach (var v in votes)
            {
                if (userId == v.CitizenId)
                {
                    ViewBag.Message = string.Format("Ви вже використали можливість проголосувати");
                    return StartVote();
                }
            }
            var vote = new Vote()
            {
                Id = votes.Count() + 1,
                ElectionId = electoin.Id,
                PollingStationId = citizen.PollingStationId,
                CitizenId = userId,
                CandidatId = candidat.Id
            };
            db.Votes.Create(vote);
            db.Save();
            return View("SuccessVote");
        }

        public IActionResult VoteResults()
        {
            List<int> count = new List<int>();
            try
            {
                var electoin = db.Elections.Find(el => el.StartVote <= DateTime.Now && el.EndVote >= DateTime.Now && el.Year == DateTime.Now.Year).First();
                var candidats = db.Candidats.Find(cand => cand.ElectionId == electoin.Id);
                List<User> users = new List<User>();

                if (candidats.Count() != 0)
                {
                    foreach (var candidat in candidats)
                    {
                        users.Add(db.Users.Get((int)candidat.CitizenId));
                        count.Add(db.Votes.Find(vote => vote.CandidatId == candidat.Id).Count());
                    }
                }
                dynamic result = new ExpandoObject();
                result.Candidats = candidats;
                result.Users = users;
                result.Count = count;

                return View(result);
            }
            catch
            {
                ViewBag.Message = string.Format("Наразі вибори зараз не проводяться і ви не можете подивитись результати");
                return RedirectToAction("Index2", "Home");
            }
        }

        private void Tick(int seconds, int minutes, int hours)
        {
            seconds++;
            if(seconds == 60)
            {
                minutes++;
                seconds = 00;
            }
            if(minutes == 60)
            {
                hours++;
                minutes = 00;
            }
        }
    }
}