using APIModels;
using Microsoft.EntityFrameworkCore;

namespace API_Lab4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonHobbyLink> HobbiesPersonsLinks{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data Persons
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    PersonId = 1,
                    Name = "Elin Otterdahl",
                    PhoneNumber = 0706342635
                });
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    PersonId = 2,
                    Name = "Marcus Linderholm",
                    PhoneNumber = 070834728
                });
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    PersonId = 3,
                    Name = "Sofie Apelqvist",
                    PhoneNumber = 070726492
                });

            //seed Hobbies
            modelBuilder.Entity<Hobby>().
                HasData(new Hobby
                {
                    HobbyId = 1,
                    Title = "Horse-ridng",
                    Description = "Love spending time in the stable, the connection with the horse, riding etc"                   
                });
            modelBuilder.Entity<Hobby>().
               HasData(new Hobby
               {
                   HobbyId = 2,
                   Title = "Skiing",
                   Description = "The mountains, the thrill of the speed, hot chocolate, Jäger etc"                   
               });
            modelBuilder.Entity<Hobby>().
               HasData(new Hobby
               {
                   HobbyId = 3,
                   Title = "Fishing",
                   Description = "Enjoys going out with the boat, hoping to catch a big pike"                   
               });    
            modelBuilder.Entity<Hobby>().
               HasData(new Hobby
               {
                   HobbyId = 4,
                   Title = "Padel",
                   Description = "Enjoys a good match"                   
               });
            modelBuilder.Entity<Hobby>().
               HasData(new Hobby
               {
                   HobbyId = 5,
                   Title = "Puzzle",
                   Description = "The best of the Christmas, when Santa brings a puzzle"
               });

            //seed links
            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 1,
                    WebLink = "https://www.varbergsridskola.se"
                    
                });
            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 2,
                    WebLink = "https://www.lofsdalen.com/sv/skidakning"                   
                });
            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 3,
                    WebLink = "https://www.skistar.com/sv/myskistar/destination/trysil/"                    
                });
            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 4,
                    WebLink = "https://www.visitvarberg.se/ovrigt/outdoor/outdoorsidor/fiska.html"                    
                });
            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 5,
                    WebLink = "https://minhast.se/"                    
                });
            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 6,
                    WebLink = "https://www.facebook.com/ponactive/"                    
                });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 1,
                PersonID = 1,
                HobbyId= 1,
                LinkId= 1
            });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 2,
                PersonID = 1,
                HobbyId = 2,
                LinkId = 2
            });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 3,
                PersonID = 1,
                HobbyId = 2,
                LinkId = 3
            });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 4,
                PersonID = 2,
                HobbyId = 2,
                LinkId = 2
            });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 5,
                PersonID = 2,
                HobbyId = 3,
                LinkId = 4
            });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 6,
                PersonID = 3,
                HobbyId = 1,
                LinkId = 5
            });
            modelBuilder.Entity<PersonHobbyLink>().HasData(new PersonHobbyLink
            {
                Id = 7,
                PersonID = 3,
                HobbyId = 4,
                LinkId = 6
            });
        }
    }
}
