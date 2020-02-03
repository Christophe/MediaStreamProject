using System;
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

        public Note(int notes, int userId, int mediaId)
        {
            ValeurNote = notes;
            UserId = userId;
            MediaId = mediaId;
        }

        [Key]
        public int Id { get; set; }
        public int ValeurNote { get; set; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
    }
}