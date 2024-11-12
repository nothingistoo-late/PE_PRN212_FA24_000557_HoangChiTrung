using PerfumeManagement.DAL.Entities;
using PerfumeManagement.DAL.PerfumeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeManagement.BLL.Service
{
    public class CompanyService
    {

        private CompanyRepository _repo = new();

        public List<ProductionCompany> GetAllNCC()
        {
            return _repo.GetAll();
        }
    }
}
