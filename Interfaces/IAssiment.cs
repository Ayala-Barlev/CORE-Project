using Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace Items.Interfaces
{
    public interface IAssiment
    {
        public List<Assiment> GetAll() ;
        public Assiment Get(int id);
        public bool Update(int id, Assiment newAssiment);
        public bool Delete(int id);
        public void Add(Assiment assiment);
    }
}