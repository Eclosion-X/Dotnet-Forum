﻿using Microsoft.EntityFrameworkCore;

namespace CampusForum.Models
{
    public class CoreDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StateText> State_text { get; set; }
        public virtual DbSet<Like> like_state { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Hobby> User_hobby { get; set; }
        public virtual DbSet<Check> user_check { get; set; }
        public virtual DbSet<Album> Album { set; get; }
        public virtual DbSet<Album_picture> Album_picture { set; get; }

        public CoreDbContext()
        {

        }
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
          

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseMySQL(@"server = localhost; uid = dbuser; pwd = 12345678;
                    port = 3306; database = dotnet_forum; sslmode = Preferred;");

            }
        }

    }
}