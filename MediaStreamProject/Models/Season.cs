using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class Season
    {
        public Season() {}
        public Season(int number, int serieID, string synopsis)
        {
            Number = number;
            SerieID = serieID;
            Synopsis = synopsis;
        }
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int SerieID { get; set; }
        public string Synopsis { get; set; }
    }
}