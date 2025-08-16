using COAHub.Domain.Application_Modes.Account_Model;
using COAHub.Domain.Application_Modes.Contact_Model;
using COAHub.Domain.Application_Modes.Journal_Model;
using COAHub.Domain.Application_Modes.Other_Model;
using COAHub.Domain.Application_Modes.User_Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Infrastructure.CONTEXT
{
    public class CoaDbContext : IdentityDbContext<UserModel, RoleModel, string>
    {
        public CoaDbContext(DbContextOptions<CoaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserModel>()
              .HasOne(x => x.Person)
              .WithOne(y => y.User)
              .HasForeignKey<Person>(y => y.UserId);

            builder.Entity<Currency>().HasData(
                   new { Id = 1, Name = "US Dollar", ShortName = "USD" },
                   new { Id = 2, Name = "Euro", ShortName = "EURO" },
                   new { Id = 3, Name = "Tanzania Shilling", ShortName = "TZS" });

            builder.Entity<Gender>().HasData(
                   new { Id = 1, Name = "Male" },
                   new { Id = 2, Name = "Female" }
                   );
            builder.Entity<JournalType>().HasData(
                   new { Id = 1, Name = "Manual" },
                   new { Id = 2, Name = "System Generated" }
                   );
            builder.Entity<AccountType>().HasData(
                   new { Id = 1, Name = "Asset" },
                   new { Id = 2, Name = "Liability" },
                   new { Id = 3, Name = "Equity" },
                   new { Id = 4, Name = "Income" },
                   new { Id = 5, Name = "Expense" }
                   );
            builder.Entity<IdentityCardType>().HasData(
                    new { Id = 1, Name = "NIDA", DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                    new { Id = 2, Name = "ZANID", DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                    new { Id = 3, Name = "PASSPORT", DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                    new { Id = 4, Name = "DRIVING LICENSE", DateCreated = DateTime.Now, DateUpdated = DateTime.Now }
                    );
        }

        //Folder :: CONTACTS
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }

        //Folder :: ACC
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }

        //Folder :: JOURNALS
        public DbSet<JournalEntityLine> JournalEntityLines { get; set; }
        public DbSet<JournalType> JournalTypes { get; set; }
        public DbSet<JournalEntryModel> JournalEntries { get; set; }
        public DbSet<IndustsryTemplate> IndustsryTemplates { get; set; }
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<UserCompanyRole> UserCompanyRoles { get; set; }



    }
}
