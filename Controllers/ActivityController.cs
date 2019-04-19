using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CSharpbelt.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CSharpbelt.Controllers
{
    public class ActivityController : Controller
    {
        private AshContext mycontext;

        // this is to get the user who is currently active
        private User ActiveUser
        {
            get {return mycontext.Users.Where(u => u.UserId ==HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }
        public ActivityController(AshContext context)
        {
            mycontext = context;
        }
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "User");
            }
            return View(InitializeDashboard());
        }
        [HttpGet]
        [Route("NewActivity")]
        public IActionResult NewActivity()
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpPost]
        [Route("AddActivity")]
        public IActionResult AddActivity(NewActivity newActivity)
        {
            // Console.WriteLine("lollll");
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "User");
            }

    // part 1 begin
            var ParticipatingActivities = mycontext.Participate.Where( p => p.UserId == ActiveUser.UserId).Select(u => u.ParticipatingActivities).ToList();
            foreach (var activity in ParticipatingActivities)
            {
                Console.WriteLine(activity.Date);
                DateTime start_date = activity.Date;
                DateTime end_date = start_date.AddMinutes((double)activity.Duration);
                Console.WriteLine(end_date);
                DateTime activity_date = newActivity.Date;
                DateTime activity_end_date = activity_date.AddMinutes((double)newActivity.Duration);
            }
            var CreatedActivities = mycontext.Activities.Where(u => u.UserId == ActiveUser.UserId).Include( a => a.Coordinator).ToList();
            foreach(var activity in CreatedActivities)
            {
                DateTime start_date = activity.Date;
                DateTime end_date = start_date.AddMinutes((double)activity.Duration);
                Console.WriteLine(end_date);
                DateTime activity_date = newActivity.Date;
                DateTime activity_end_date = activity_date.AddMinutes((double)newActivity.Duration);
            }
            if(Request.Form["dur"] == "minutes")
            {
                newActivity.Duration =  newActivity.Duration;
            }
            if(Request.Form["dur"] == "hours")
            {
                newActivity.Duration =  newActivity.Duration * 60;
            }
            if(Request.Form["dur"] == "days")
            {
                newActivity.Duration =  newActivity.Duration * 1440;
            }
    // // end part 1

            if(ModelState.IsValid)
            {
                Activity theActivity = new Activity()
                {
                    Title = newActivity.Title,
                    Date = newActivity.Date,
                    Time = newActivity.Time,
                    Duration = newActivity.Duration,
                    Description = newActivity.Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = ActiveUser.UserId,
                };
                mycontext.Add(theActivity);
                mycontext.SaveChanges();
                Activity currentActivity = mycontext.Activities.Where(a => a.UserId == ActiveUser.UserId).Last();
                int currentActivityId = currentActivity.ActivityId;
                return Redirect($"ActivityDetails/{currentActivityId}");
            }
            return View("NewActivity");
        }


        [HttpGet]
        [Route("Join/{activity_id}")]
        public IActionResult JoinActivity(int activity_id)
        {
             if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "User");
            }
    // insert part 2 here
    //not able to joy the overlap activities
            var ParticipatingActivities = mycontext.Participate.Where( p => p.UserId == ActiveUser.UserId).Select(u => u.ParticipatingActivities).ToList();
            Activity currentActivity = mycontext.Activities.SingleOrDefault(a => a.ActivityId == activity_id);
            foreach (var activity in ParticipatingActivities)
            {
                DateTime start_date = activity.Date;
                DateTime end_date = start_date.AddMinutes((double)activity.Duration);
                Console.WriteLine(end_date);
                System.Console.WriteLine("Is this getting joined or not #$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                DateTime activity_date = currentActivity.Date;
                DateTime activity_end_date = activity_date.AddMinutes((double)currentActivity.Duration);
                if(activity_date < start_date && activity_end_date < start_date)
                {
                    currentActivity.Date = currentActivity.Date;
                    currentActivity.Duration = currentActivity.Duration;
                }
                else if (activity_date > start_date && activity_date > end_date )
                {
                    currentActivity.Date = currentActivity.Date;
                    currentActivity.Duration = currentActivity.Duration;
                }
                else
                {
                    ViewBag.Error = null;
                    TempData["error"] = "Activity Conflict!!!!! You cannot be at 2 places at once";
                    Console.WriteLine("Dashboard");
                    return Redirect ("/Dashboard");
                }
            }
    // end part 2 

            Participate newParticipation = new Participate
            {
                UserId = ActiveUser.UserId,
                ActivityId = activity_id
            };
            mycontext.Participate.Add(newParticipation);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("Leave/{activity_id}")]
        public IActionResult LeaveActivity(int activity_id)
        {
            Participate currentParticipate = mycontext.Participate.SingleOrDefault( p => p.UserId == ActiveUser.UserId && p.ActivityId == activity_id);
            mycontext.Participate.Remove(currentParticipate);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Delete/{activity_id}")]
        public IActionResult DeleteActivity(int activity_id)
        {
            Activity theActivity = mycontext.Activities.SingleOrDefault(a => a.ActivityId == activity_id);
            mycontext.Activities.Remove(theActivity);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("ActivityDetails/{activity_id}")]
        public IActionResult ActivityDetails( int activity_id)
        {
            Activity theActivity = mycontext.Activities.Include(a => a.Participants).ThenInclude(p => p.ParticipatingUsers).SingleOrDefault(a => a.ActivityId == activity_id);
            int num = theActivity.UserId;
            ViewBag.theUser = mycontext.Users.SingleOrDefault( u => u.UserId == num);
            ViewBag.ActiveUserId = ActiveUser.UserId;
            return View(theActivity);
        }
        public DashboardModels InitializeDashboard()
        {
            var ParticipatingActivities = mycontext.Participate.Where( p => p.UserId == ActiveUser.UserId).Select(u => u.ParticipatingActivities).ToList();
            return new DashboardModels
            {
                AllActivities = mycontext.Activities.OrderBy(u => u.Date).Include( a => a.Participants).ThenInclude(p => p.ParticipatingUsers).ToList(),
                AllUsers = mycontext.Users.Include( u => u.CreatedActivities).ToList(),
                User = ActiveUser,
                JoinedActivities = ParticipatingActivities       
            };
        }
    }
}