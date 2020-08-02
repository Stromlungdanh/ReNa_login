using Framework.EntityFrameworkCore;
using Framework.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Migrations.Seed.Host
{
    public class InitialPeopleCreator
    {
        private readonly FrameworkDbContext _context;

        public InitialPeopleCreator(FrameworkDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Douglas",
                        SurName = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com"
                    });
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        SurName = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org"
                    });
            }
        }
    }
}
