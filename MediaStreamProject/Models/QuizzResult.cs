using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class QuizzResult
    {
        public QuizzResult()
        {
        }

        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public int Score { get; set; }
        public string Theme { get; set; }
        public double Time { get; set; }
    }
}