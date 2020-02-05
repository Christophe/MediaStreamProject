namespace MediaStreamProject.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1") {}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<QuizzResult> QuizzResults { get; set; }
        public virtual DbSet<FilmWishList> FilmWishLists { get; set; }
        public virtual DbSet<SerieWishList> SerieWishLists { get; set; }
        public virtual DbSet<FilmHistorique> FilmHistoriques { get; set; }
        public virtual DbSet<SerieHistorique> SerieHistoriques { get; set; }
        

    }
}