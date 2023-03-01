using Items.Models;
using Items.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Items.Services 
{   
    public class AssimentService:IAssiment
    {    
        // private List<Assiment> assiments = new List<Assiment>
        // {
        //     new Assiment {Id=1, Description="wash the floor", Done = false },
        //     new Assiment {Id=2, Description="bake a cake", Done = true }
        // };
        List<Assiment> assiments { get; }
        private IWebHostEnvironment  webHost;
        private string filePath;
        public AssimentService(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "Assiments.json");
            using (var jsonFile = File.OpenText(filePath))
            {
                assiments = JsonSerializer.Deserialize<List<Assiment>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
        private void saveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(assiments));
        }
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
            saveToFile();
            return true;
        }

        public bool Delete(int id)
        {
            var assiment = assiments.FirstOrDefault(a => a.Id == id);
            if (assiment == null)
                return false;
            assiments.Remove(assiment);
            saveToFile();
            return true;
        }

        public void Add(Assiment assiment)
        {
            assiment.Id = assiments.Max(a => a.Id) + 1;
            assiments.Add(assiment);
            saveToFile();
        }

        



    }
}