using JobBoard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Interview> Interviews { get; set; }
    }
}
