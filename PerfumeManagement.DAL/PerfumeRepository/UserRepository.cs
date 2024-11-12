using PerfumeManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeManagement.DAL.PerfumeRepository
{
    public class UserRepository
    {
        private Fall24PerfumeStoreDbContext? _context;

        public Psaccount? GetUser(string email, string password)
        {
            _context = new();
            return _context.Psaccounts.FirstOrDefault(x => x.EmailAddress.ToLower().Trim() == email.ToLower().Trim() && x.Password == password);
        }
    }
}
