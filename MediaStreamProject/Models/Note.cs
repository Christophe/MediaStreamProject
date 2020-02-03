﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class Note
    {
        public Note() { }

        public Note(int notes, int userId, int filmId)
        {
            Notes = notes;
            UserId = userId;
            FilmId = filmId;
        }

        [Key]
        public int Id { get; set; }
        public int Notes { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        [ForeignKey("FilmId")]
        public virtual Film film { get; set; }
    }
}