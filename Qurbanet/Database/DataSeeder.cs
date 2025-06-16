using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Entities;
using Qurbanet.Models.Enums;

namespace Qurbanet.Database
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (context.Organizations.Any())
            {
                return;
            }

            // create demo users if none exist
            if (!context.Users.Any())
            {
                var demoUser = new User
                {
                    Name = "Demo",
                    Surname = "User",
                    Username = "demo",
                    Password = "demo",
                    Email = "demo@example.com",
                    Phone = "5550000000",
                    UserType = UserType.User,
                    CreateUserId = 0,
                    UpdateUserId = 0,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };
                var organizer = new User
                {
                    Name = "Organizer",
                    Surname = "User",
                    Username = "organizer",
                    Password = "organizer",
                    Email = "organizer@example.com",
                    Phone = "5551111111",
                    UserType = UserType.Organizer,
                    CreateUserId = 0,
                    UpdateUserId = 0,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };
                var admin = new User
                {
                    Name = "Admin",
                    Surname = "User",
                    Username = "admin",
                    Password = "admin",
                    Email = "admin@example.com",
                    Phone = "5552222222",
                    UserType = UserType.Admin,
                    CreateUserId = 0,
                    UpdateUserId = 0,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };
                context.Users.AddRange(demoUser, organizer, admin);
                await context.SaveChangesAsync();
            }

            var orgOwner = context.Users.First(u => u.UserType == UserType.Organizer);
            var organization = new Organization
            {
                UserId = orgOwner.Id,
                Name = "Demo Organizasyon",
                Year = DateTime.UtcNow.Year,
                IsPaid = true,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddDays(1),
                CreateUserId = orgOwner.Id,
                UpdateUserId = orgOwner.Id,
            };
            context.Organizations.Add(organization);
            await context.SaveChangesAsync();

            var rnd = new Random();
            var animals = new List<Animal>();
            for (int i = 1; i <= 18; i++)
            {
                bool sold = rnd.NextDouble() < 0.6;
                animals.Add(new Animal
                {
                    OrganizationId = organization.Id,
                    NameOrTag = $"A{i:000}",
                    Species = "Cow",
                    Breed = "Mixed",
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    WeightKg = 250 + rnd.Next(80),
                    Price = 1000 + rnd.Next(500),
                    Status = sold ? "Sold" : "Available",
                    CreateUserId = orgOwner.Id,
                    UpdateUserId = orgOwner.Id
                });
            }
            context.Animals.AddRange(animals);
            await context.SaveChangesAsync();

            foreach (var animal in animals.Where(a => a.Status == "Sold"))
            {
                var customer = new Customer
                {
                    FullName = $"Müşteri {animal.NameOrTag}",
                    PhoneNumber = "5550000000",
                    Email = $"customer{animal.NameOrTag}@demo.com",
                    CreateUserId = orgOwner.Id,
                    UpdateUserId = orgOwner.Id
                };
                context.Customers.Add(customer);
                await context.SaveChangesAsync();

                decimal paidPortion = (decimal)(0.3 + rnd.NextDouble() * 0.7);
                var sale = new Sale
                {
                    AnimalId = animal.Id,
                    CustomerId = customer.Id,
                    SalePrice = animal.Price,
                    AmountPaid = Math.Round(animal.Price * paidPortion, 2),
                    SaleDate = DateTime.UtcNow,
                    CreateUserId = orgOwner.Id,
                    UpdateUserId = orgOwner.Id
                };
                context.Sales.Add(sale);
                await context.SaveChangesAsync();

                var payment = new Payment
                {
                    SaleId = sale.Id,
                    Amount = sale.AmountPaid,
                    PaymentDate = DateTime.UtcNow,
                    CreateUserId = orgOwner.Id,
                    UpdateUserId = orgOwner.Id
                };
                context.Payments.Add(payment);
                await context.SaveChangesAsync();
            }

            int order = 1;
            foreach (var animal in animals)
            {
                var stage = (Stage)rnd.Next(1, 5);
                DateTime start = DateTime.UtcNow.AddHours(-rnd.Next(5));
                DateTime? end = stage == Stage.Kesim ? null : start.AddHours(1);

                context.CuttingEvents.Add(new CuttingEvent
                {
                    AnimalId = animal.Id,
                    Stage = stage,
                    StartTime = start,
                    EndTime = end,
                    OrderNumber = order++,
                    CreateUserId = orgOwner.Id,
                    UpdateUserId = orgOwner.Id
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
