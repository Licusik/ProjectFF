using DataAccess.Data;
using Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using Models.Enums;

namespace DataAccess;

public class AppDbInitializer
{    public static void Seed(IApplicationBuilder applicationBuilder)
      {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.EnsureCreated();

        // Cinemas
        if (!context.Cinemas.Any())
        {
            context.Cinemas.AddRange(new List<Cinema>()
        {
            new Cinema()
            {
                Name = "AMC Empire 25",
                Logo = "https://example.com/amc_logo.jpg",
                Description = "Iconic 25-screen multiplex in Times Square offering first-run films, IMAX screenings & stadium seating."
            },
            new Cinema()
            {
                Name = "Odeon Leicester Square",
                Logo = "https://example.com/odeon_logo.jpg",
                Description = "Historic cinema hosting major film premieres, with luxury seating and state-of-the-art projection systems."
            },
            new Cinema()
            {
                Name = "ArcLight Hollywood",
                Logo = "https://example.com/arclight_logo.jpg",
                Description = "Upscale multiplex with 21st-century technology, reserved seating & a lounge, plus a cafe & bar."
            },
            new Cinema()
            {
                Name = "Prince Charles Cinema",
                Logo = "https://example.com/prince_charles_logo.jpg",
                Description = "Independent cinema showing cult classics, sing-alongs and arthouse films in London's West End."
            },
            new Cinema()
            {
                Name = "Alamo Drafthouse",
                Logo = "https://example.com/alamo_logo.jpg",
                Description = "Cinema chain offering creative pub grub, cocktails & events like quote-along screenings & theme parties."
            }
        });
            context.SaveChanges();
        }

        // Actors
        if (!context.Actors.Any())
        {
            context.Actors.AddRange(new List<Actor>()
        {
            new Actor() { FullName = "Leonardo DiCaprio", Bio = "Academy Award-winning American actor", ProfilePictureUrl = "https://example.com/dicaprio.jpg" },
            new Actor() { FullName = "Meryl Streep", Bio = "Most Oscar-nominated actor in history", ProfilePictureUrl = "https://example.com/streep.jpg" },
            new Actor() { FullName = "Tom Hanks", Bio = "Beloved American actor and filmmaker", ProfilePictureUrl = "https://example.com/hanks.jpg" },
            new Actor() { FullName = "Cate Blanchett", Bio = "Australian actress known for versatile roles", ProfilePictureUrl = "https://example.com/blanchett.jpg" },
            new Actor() { FullName = "Denzel Washington", Bio = "Acclaimed actor and two-time Oscar winner", ProfilePictureUrl = "https://example.com/washington.jpg" },
            new Actor() { FullName = "Scarlett Johansson", Bio = "Highest-grossing actress of all time", ProfilePictureUrl = "https://example.com/johansson.jpg" },
            new Actor() { FullName = "Joaquin Phoenix", Bio = "Oscar-winning actor known for intense roles", ProfilePictureUrl = "https://example.com/phoenix.jpg" },
            new Actor() { FullName = "Emma Stone", Bio = "Academy Award-winning American actress", ProfilePictureUrl = "https://example.com/stone.jpg" },
            new Actor() { FullName = "Christian Bale", Bio = "British method actor known for transformations", ProfilePictureUrl = "https://example.com/bale.jpg" },
            new Actor() { FullName = "Viola Davis", Bio = "Acclaimed actress and EGOT winner", ProfilePictureUrl = "https://example.com/davis.jpg" }
        });
            context.SaveChanges();
        }

        // Producers
        if (!context.Producers.Any())
        {
            context.Producers.AddRange(new List<Producer>()
        {
            new Producer() { FullName = "Steven Spielberg", Bio = "Legendary filmmaker", ProfilePictureUrl = "https://example.com/spielberg.jpg" },
            new Producer() { FullName = "Christopher Nolan", Bio = "British-American filmmaker", ProfilePictureUrl = "https://example.com/nolan.jpg" },
            new Producer() { FullName = "Kathleen Kennedy", Bio = "President of Lucasfilm", ProfilePictureUrl = "https://example.com/kennedy.jpg" },
            new Producer() { FullName = "Quentin Tarantino", Bio = "Auteur filmmaker", ProfilePictureUrl = "https://example.com/tarantino.jpg" },
            new Producer() { FullName = "Ava DuVernay", Bio = "Groundbreaking director/producer", ProfilePictureUrl = "https://example.com/duvernay.jpg" }
        });
            context.SaveChanges();
        }

        // Movies
        if (!context.Movies.Any())
        {
            context.Movies.AddRange(new List<Movie>()
        {
            new Movie()
            {
                Name = "Inception",
                Description = "A thief who steals corporate secrets through dream-sharing technology",
                Price = 14.99,
                ImageUrl = "https://example.com/inception.jpg",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(120),
                CinemaId = 3,
                ProducerId = 2,
                MovieCategory = MovieCategory.Documentary
            },
            new Movie()
            {
                Name = "The Dark Knight",
                Description = "Batman faces the Joker in a battle for Gotham's soul",
                Price = 12.99,
                ImageUrl = "https://example.com/dark_knight.jpg",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(90),
                CinemaId = 1,
                ProducerId = 2,
                MovieCategory = MovieCategory.Action
            },
            new Movie()
            {
                Name = "The Godfather",
                Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son",
                Price = 9.99,
                ImageUrl = "https://example.com/godfather.jpg",
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now.AddDays(60),
                CinemaId = 4,
                ProducerId = 1,
                MovieCategory = MovieCategory.Drama
            },
            new Movie()
            {
                Name = "Pulp Fiction",
                Description = "Various interconnected stories of criminals in Los Angeles",
                Price = 11.50,
                ImageUrl = "https://example.com/pulp_fiction.jpg",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(150),
                CinemaId = 2,
                ProducerId = 4,
                MovieCategory = MovieCategory.Crime
            }
        });
            context.SaveChanges();
        }

        // Actors & Movies
        if (!context.Actors_Movies.Any())
        {
            context.Actors_Movies.AddRange(new List<Actor_Movie>()
        {
            new Actor_Movie() { MovieId = 1, ActorId = 1 },  // Inception: DiCaprio
            new Actor_Movie() { MovieId = 1, ActorId = 9 },  // Inception: Bale
            new Actor_Movie() { MovieId = 2, ActorId = 9 },  // Dark Knight: Bale
            new Actor_Movie() { MovieId = 2, ActorId = 7 },  // Dark Knight: Phoenix
            new Actor_Movie() { MovieId = 3, ActorId = 3 },  // Godfather: Hanks
            new Actor_Movie() { MovieId = 4, ActorId = 1 },  // Pulp Fiction: DiCaprio
            new Actor_Movie() { MovieId = 4, ActorId = 8 }   // Pulp Fiction: Stone
        });
            context.SaveChanges();
        }
    }

    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

        //Roles
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //Users
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        string adminUserEmail = "admin@etickets.com";

        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        if (adminUser == null)
        {
            var newAdminUser = new AppUser()
            {
                FullName = "Admin User",
                UserName = "admin-user",
                Email = adminUserEmail,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(newAdminUser, "Admin1");
            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        }


        string appUserEmail = "user@etickets.com";

        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        if (appUser == null)
        {
            var newAppUser = new AppUser()
            {
                FullName = "Application User",
                UserName = "app-user",
                Email = appUserEmail,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(newAppUser, "User1*");
            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        }
    }
}

