using System;
using System.Collections.Generic;
using app_persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace app_persistence
{
    public class Db : DbContext
    {
        private readonly string connectionString;
        private readonly bool isMock; //Indicates if a mock database is in use for unit testing

        #region Database Tables
        public DbSet<Patient> Patients { get; set; }

        #endregion Database Tables

        public Db(string connectionString)
        {
            if (connectionString != null)
            {
                this.connectionString = connectionString;
            }
            else
            {
                isMock = true;
            }
        }

        [Obsolete("This constructor is only used for EF migrations", true)]
        public Db() : this("Server=localhost;Port=5432;Database=clinic_app_aldo;User Id=postgres;Password=admin") { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //make sure were not running a unit test b4 setting connection string
            if(!isMock)
            {
                //TODO: maybe add logging here to check the SQL that EF throws out
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }


    }
}
