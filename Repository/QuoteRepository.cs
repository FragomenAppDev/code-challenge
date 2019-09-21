using System.Collections.Generic;
using System.Linq;
using System.IO;
using CodeChallenge.Model;
using Newtonsoft.Json;

namespace CodeChallenge.Repository
{
    public class QuoteRepository
    {
        private const string path = "data/ShortDb.json";

        public ICollection<Quote> GetAll() 
        {
            if (!File.Exists(path)) return new List<Quote>();
            using (StreamReader fileStreamReader = new StreamReader(path)) {
                using (JsonReader jsonReader = new JsonTextReader(fileStreamReader)) {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<ICollection<Quote>>(jsonReader);
                }
            }
        }

        public Quote GetById(long id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public long Create(Quote q) 
        {
            ICollection<Quote> contents = GetAll();
            q.Id = contents.Any() ? contents.Select(x=>x.Id).Max() + 1 : 0;
            contents.Add(q);
            File.WriteAllText(path, JsonConvert.SerializeObject(contents));
            return q.Id;
        }

        public void Update(long id, Quote q)
        {
            ICollection<Quote> contents = GetAll();
            Quote found = contents.FirstOrDefault(x => x.Id == id);
            if (found == null) return;
            found.Author = q.Author;
            found.Text = q.Text;
            File.WriteAllText(path, JsonConvert.SerializeObject(contents));
        }

        public void Delete(long id)
        {
            ICollection<Quote> contents = GetAll();
            File.WriteAllText(path, JsonConvert.SerializeObject(contents.Where(x => x.Id != id)));            
        }
    }
}