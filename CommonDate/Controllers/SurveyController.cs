using CommonDate.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonDate.Controllers
{
    public class SurveyController : Controller
    {
        ApplicationDbContext context;

        public SurveyController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Details(int id)
        {
            Survey survey = context.Surveys.Where(s => s.SurveyId == id).FirstOrDefault();
            return View(survey);
        }
        public ActionResult Index()
        {
            return View(context.Surveys.ToList());
        }
        public ActionResult Create()
        {
            Survey survey = new Survey();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Survey survey)
        {
            try
            {
                context.Surveys.Add(survey);
                context.SaveChanges();
                string id = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
                survey.Id = user.Id;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Survey survey = context.Surveys.Where(s => s.SurveyId == id).FirstOrDefault();
            return View(survey);
        }
        [HttpPost]
        public ActionResult Edit(int id, Survey survey)
        {
            try
            {
                Survey surveyEdit = context.Surveys.Where(s => s.SurveyId == id).FirstOrDefault();
                surveyEdit.BaseballGames = surveyEdit.BaseballGames;
                surveyEdit.Bowling = surveyEdit.Bowling;
                surveyEdit.Dancing = surveyEdit.Dancing;
                surveyEdit.DistilleryTour = surveyEdit.DistilleryTour;
                surveyEdit.Festivals = surveyEdit.Festivals;
                surveyEdit.FoodAsian = surveyEdit.FoodAsian;
                surveyEdit.FoodBurgers = surveyEdit.FoodBurgers;
                surveyEdit.FoodFineDining = surveyEdit.FoodFineDining;
                surveyEdit.FoodItalian = surveyEdit.FoodItalian;
                surveyEdit.FoodMexican = surveyEdit.FoodMexican;
                surveyEdit.FoodSteakHouse = surveyEdit.FoodSteakHouse;
                surveyEdit.FootballGames = surveyEdit.FootballGames;
                surveyEdit.Hiking = surveyEdit.Hiking;
                surveyEdit.MovieTheater = surveyEdit.MovieTheater;
                surveyEdit.Museums = surveyEdit.Museums;
                surveyEdit.MusicCountry = surveyEdit.MusicCountry;
                surveyEdit.MusicHipHop = surveyEdit.MusicHipHop;
                surveyEdit.MusicPop = surveyEdit.MusicPop;
                surveyEdit.MusicRock = surveyEdit.MusicRock;
                surveyEdit.NbaGames = surveyEdit.NbaGames;
                surveyEdit.SoccerGames = surveyEdit.SoccerGames;
                surveyEdit.Zoo = surveyEdit.Zoo;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            Survey survey = context.Surveys.Where(s => s.SurveyId == id).FirstOrDefault();
            return View(survey);
        }
        [HttpPost]
        public ActionResult Delete(int id, Survey survey)
        {
            try
            {
                Survey surveyDelete = context.Surveys.Where(s => s.SurveyId == id).FirstOrDefault();
                context.Surveys.Remove(surveyDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult GenderMatch()
        {
            string UserId = User.Identity.GetUserId();
            var tempuser = context.Users.Where(u => u.ApplicationId == UserId).FirstOrDefault();
            var matchZipGender = context.Users.Where(s => s.Gender == tempuser.GenderPreference && s.Zipcode == tempuser.Zipcode);
           
            return View(matchZipGender);
        }
        public ActionResult SurveyComparer()
        {
            Survey surveyMatch = new Survey();
            string idSurvey = User.Identity.GetUserId();
            //surveyMatch = context.Surveys.Where(s=>s.SurveyId == 
            return View();
        }
       
	

    }
}

//surveyComparer.BaseballGames = surveyComparer.BaseballGames;
//            surveyComparer.Bowling = surveyComparer.Bowling;
//            surveyComparer.Dancing = surveyComparer.Dancing;
//            surveyComparer.DistilleryTour = surveyComparer.DistilleryTour;
//            surveyComparer.Festivals = surveyComparer.Festivals;
//            surveyComparer.FoodAsian = surveyComparer.FoodAsian;
//            surveyComparer.FoodBurgers = surveyComparer.FoodBurgers;
//            surveyComparer.FoodFineDining = surveyComparer.FoodFineDining;
//            surveyComparer.FoodItalian = surveyComparer.FoodItalian;
//            surveyComparer.FoodMexican = surveyComparer.FoodMexican;
//            surveyComparer.FoodSteakHouse = surveyComparer.FoodSteakHouse;
//            surveyComparer.FootballGames = surveyComparer.FootballGames;
//            surveyComparer.Hiking = surveyComparer.Hiking;
//            surveyComparer.MovieTheater = surveyComparer.MovieTheater;
//            surveyComparer.Museums = surveyComparer.Museums;
//            surveyComparer.MusicCountry = surveyComparer.MusicCountry;
//            surveyComparer.MusicHipHop = surveyComparer.MusicHipHop;
//            surveyComparer.MusicPop = surveyComparer.MusicPop;
//            surveyComparer.MusicRock = surveyComparer.MusicRock;
//            surveyComparer.NbaGames = surveyComparer.NbaGames;
//            surveyComparer.SoccerGames = surveyComparer.SoccerGames;
//            surveyComparer.Zoo = surveyComparer.Zoo;