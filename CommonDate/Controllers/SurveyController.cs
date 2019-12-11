using CommonDate.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CommonDate.Controllers
{
    //[Authorize]
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
        public ActionResult SurveyComparer(int id)
        {
            Survey survey = new Survey();
            string loggedInUser = User.Identity.GetUserId();
            var userSurvey = context.Surveys.Where(s => s.SurveyId == id);

            userSurvey.Where(s => s.BaseballGames == true);

            return View(id);


            return View();
        }
        public ActionResult SearchEvents()
        {
            Event events = new Event();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SearchEvents(Event events)
        {
            var authorApi = APIKeys.eventfulApi;
            string id = User.Identity.GetUserId();
            var user = context.Users.Where(s => s.ApplicationId == id).FirstOrDefault();
            string url = @"https://community-eventful.p.rapidapi.com/events/search?keywords={events}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", authorApi);
            HttpResponseMessage response = await client.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Class1[] eventPlacesList = JsonConvert.DeserializeObject<Class1[]>(data);
            }
            return View("eventResults", events);
        }
        public ActionResult eventResults(Class1[] eventPlacesList)
        {
            return View(eventPlacesList);
        }
        public async Task<ActionResult> GeoLocation(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            string Url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string matchAddress = System.Web.HttpUtility.UrlEncode(
                user.StreetAddress + " " +
                user.City + " " +
                user.StateCode + " " +
                user.Zipcode);
            string apiKey = "&key="+APIKeys.googleApi;
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(Url + matchAddress + apiKey);
            JObject map = JObject.Parse(response);
            user.lat = (float)map["results"][0]["geometry"]["location"]["lat"];
            user.lng = (float)map["results"][0]["geometry"]["location"]["lng"];

            return View(user);
        }




    }
}

