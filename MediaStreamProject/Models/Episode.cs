using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class Episode
    {
        public Episode() {}
        public Episode(int number, int seasonID, int serieID, int duration)
        {
            Number = number;
            SeasonID = seasonID;
            SerieID = serieID;
            Duration = duration;
        }
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeasonID { get; set; }
        public int SerieID { get; set; }
        public int Duration { get; set; }
        public string Video { get; set; }
    }
}