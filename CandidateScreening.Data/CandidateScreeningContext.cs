using CandidateScreening.Data.Entities;
using CandidateScreening.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateScreening.Data
{
    public class CandidateScreeningContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
    }
}
