using PerfumeManagement.DAL.Entities;
using PerfumeManagement.DAL.PerfumeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeManagement.BLL.Service
{
    public class PerfumeService
    {

        private PerfumeRepository _repo = new();
        public List<PerfumeInformation> GetAll()
        {
            return _repo.GetAll();
        }

        public void AddPerfume(PerfumeInformation obj)
          => _repo.Create(obj);

        public List<PerfumeInformation> GetAllPerfume()
            => _repo.GetAll();

        public void UpdatePerfume(PerfumeInformation obj) => _repo.Update(obj);

        public void DeletePerfume(PerfumeInformation obj) => _repo.Delete(obj);
    }
}
