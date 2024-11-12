using PerfumeManagement.DAL.Entities;
using PerfumeManagement.DAL.PerfumeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeManagement.BLL.Service
{
    public class UserService
    {
        private UserRepository? _userRepo = new();

        public Psaccount? Authenticate(string email, string password)
        {
            return _userRepo.GetUser(email, password);
        }
    }
}
