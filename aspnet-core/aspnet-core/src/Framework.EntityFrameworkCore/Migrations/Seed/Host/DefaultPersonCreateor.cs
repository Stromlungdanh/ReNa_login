using Framework.EntityFrameworkCore;
using Framework.PhoneBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Migrations.Seed.Host
{
    public class DefaultPersonCreateor
    {
        private FrameworkDbContext _context;

        public DefaultPersonCreateor(FrameworkDbContext context)
        {
            this._context = context;
        }

        public void Create()
        {
            var ben = new Person
            {
                Name = "Ben",
                SurName = "Phillip",
                EmailAddress = "phillipben@gmail.com"
            };

            if(ben != null)
            {
                _context.Persons.Add(ben);
            }


            var ben1 = new Person
            {
                Name = "Ben1",
                SurName = "Phillip",
                EmailAddress = "phillipben@gmail.com"
            };

            if (ben != null)
            {
                _context.Persons.Add(ben1);
            }
            var ben2 = new Person
            {
                Name = "Ben2",
                SurName = "Phillip",
                EmailAddress = "phillipben@gmail.com"
            };

            if (ben != null)
            {
                _context.Persons.Add(ben2);
            }

        }
    }
}
