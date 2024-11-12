using Microsoft.EntityFrameworkCore;
using PerfumeManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeManagement.DAL.PerfumeRepository
{
    public class CompanyRepository
    {

        private Fall24PerfumeStoreDbContext _context;
        public List<ProductionCompany> GetAll()
        {
            _context = new();
            return _context.ProductionCompanies.ToList();
        }
    }
}
