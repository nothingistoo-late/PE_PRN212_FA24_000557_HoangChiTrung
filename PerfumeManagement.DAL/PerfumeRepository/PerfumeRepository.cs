using Microsoft.EntityFrameworkCore;
using PerfumeManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeManagement.DAL.PerfumeRepository
{
    public class PerfumeRepository
    {

        private Fall24PerfumeStoreDbContext _context;

        public List<PerfumeInformation> GetAll()
        {
            _context = new();
            return _context.PerfumeInformations.Include("ProductionCompany").ToList();
        }

        public void Create(PerfumeInformation obj)
        {
            _context = new();
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Update(PerfumeInformation obj)
        {
            _context = new();
            _context.Update(obj);
            _context.SaveChanges();
        }
        public void Delete(PerfumeInformation obj)
        {
            _context = new();
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}
