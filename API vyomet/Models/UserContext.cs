using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_vyomet.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Alert> Alert { get; set; }
    }
}
