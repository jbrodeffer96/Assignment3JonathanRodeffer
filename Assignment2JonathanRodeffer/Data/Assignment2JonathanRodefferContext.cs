using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment2JonathanRodeffer.Models
{
    public class Assignment2JonathanRodefferContext : DbContext
    {
        public Assignment2JonathanRodefferContext (DbContextOptions<Assignment2JonathanRodefferContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment2JonathanRodeffer.Models.UserDataEntry> UserDataEntry { get; set; }
    }
}
