using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class DataSeeder
    {
        public static void SeedAdmin(FitnessCenterDbContext context)
        {
            if (!context.Employees.Any())
            {
                AppUser user = new AppUser() { CreatedAt = DateTime.Now, Address = "adress", Email = "admin@gmail.com", FirstName = "admin", LastName = "admin", HashedPassword = "d2ac345bbd3159c3a5e1ddb297d56b38ab1ea2e6d55a5055e0d36ba4ca525eb1", PhoneNumber = "000", Status = UserStatus.ACTIVE };
                context.AppUsers.Add(user);
                context.SaveChanges();

                Employee employee = new Employee { AppUser = user, Salary = 500 };
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
    }
}
