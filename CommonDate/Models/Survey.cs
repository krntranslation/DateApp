using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommonDate.Models
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }

        [Display(Name = "Soccer Games")]
        public bool SoccerGames { get; set; }

        [Display(Name = "NBA Games")]
        public bool NbaGames { get; set; }

        [Display(Name = "Football Games")]
        public bool FootballGames { get; set; }

        [Display(Name = "Baseball Games")]
        public bool BaseballGames { get; set; }

        [Display(Name = "Watching Movies at the theater")]
        public bool MovieTheater { get; set; }

        [Display(Name = "Bowling")]
        public bool Bowling { get; set; }

        [Display(Name = "Going to Outdoor Festivals")]
        public bool Festivals { get; set; }

        [Display(Name = "Going Hiking")]
        public bool Hiking { get; set; }

        [Display(Name = "Distillery Tour")]
        public bool DistilleryTour { get; set; }

        [Display(Name = "Going to Museums")]
        public bool Museums { get; set; }

        [Display(Name = "Going to the Zoo")]
        public bool Zoo { get; set; }

        [Display(Name = "Going dancing")]
        public bool Dancing { get; set; }

        [Display(Name = "Pop Concert")]
        public bool MusicPop { get; set; }

        [Display(Name = "Rock Concert")]
        public bool MusicRock { get; set; }

        [Display(Name = "Hip Hop Concert")]
        public bool MusicHipHop { get; set; }

        [Display(Name = "Country Concert")]
        public bool MusicCountry { get; set; }

        [Display(Name = "Eating Asian Food")]
        public bool FoodAsian { get; set; }

        [Display(Name = "Eating Mexican Food")]
        public bool FoodMexican { get; set; }

        [Display(Name = "Eating Italian Food")]
        public bool FoodItalian { get; set; }

        [Display(Name = "Eating Burgers and Fries")]
        public bool FoodBurgers { get; set; }

        [Display(Name = "Going to Fine Dining")]
        public bool FoodFineDining { get; set; }

        [Display(Name = "Going to a SteakHouse")]
        public bool FoodSteakHouse { get; set; }

        [ForeignKey("User")]
        public int? Id { get; set; }
        public User User { get; set; }
    }
}