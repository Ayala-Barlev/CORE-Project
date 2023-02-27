using Items.Models;
using System.Collections.Generic;
using System.Linq;
using Items.Interfaces;

namespace Items.Services 
{   
    public class AssimentService:IAssiment
    {    
        private List<Assiment> assiments = new List<Assiment>
        {
            new Assiment {Id=1, Description="wash the floor", Done = false },
            new Assiment {Id=2, Description="bake a cake", Done = true }
        };

        public List<Assiment> GetAll() => assiments;
        public Assiment Get(int id)
        {
            return assiments.FirstOrDefault(a => a.Id == id);
        }
        public bool Update(int id, Assiment newAssiment)
        {
            if (newAssiment.Id != id)
                return false;
            
            var assiment = assiments.FirstOrDefault(a => a.Id == id);
            assiment.Description = newAssiment.Description;
            assiment.Done = newAssiment.Done;
            return true;
        }

        public bool Delete(int id)
        {
            var assiment = assiments.FirstOrDefault(a => a.Id == id);
            if (assiment == null)
                return false;
            assiments.Remove(assiment);
            return true;
        }

        public void Add(Assiment assiment)
        {
            assiment.Id = assiments.Max(a => a.Id) + 1;
            assiments.Add(assiment);
        }

        



    }
}