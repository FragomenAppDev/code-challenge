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
        IDictionary<int, int> pairsDictionary = new Dictionary<int, int>();

        public QuoteRepository()
        {
            ICollection<Quote> quotes = GetAll();
            CreatePairsDataStruct(quotes);
        }

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
            AddQuoteToPairsDataStruct(q);
            return q.Id;
        }

        public void Update(long id, Quote q)
        {
            ICollection<Quote> contents = GetAll();
            Quote found = contents.FirstOrDefault(x => x.Id == id);
            if (found == null) return;
            RemoveQuoteFromPairsDataStruct(found);
            found.Author = q.Author;
            found.Text = q.Text;
            File.WriteAllText(path, JsonConvert.SerializeObject(contents));
            AddQuoteToPairsDataStruct(q);
        }

        public void Delete(long id)
        {
            ICollection<Quote> contents = GetAll();
            Quote q = contents.Where(x => x.Id == id).FirstOrDefault();
            if(q != null) 
            {
                contents.Remove(q);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(contents));
            RemoveQuoteFromPairsDataStruct(q);            
        }

        private void CreatePairsDataStruct(ICollection<Quote> quotes)
        {
            foreach(Quote quote in quotes)
            {
                AddQuoteToPairsDataStruct(quote);
            }
        }

        private void AddQuoteToPairsDataStruct(Quote quote)
        {
            int length = quote.Text.Length;
            if(pairsDictionary.ContainsKey(length))
            {
                pairsDictionary[length] = pairsDictionary[length]+1;
            } 
            else
            {
                pairsDictionary[length] = 1;
            }
        }

        private void RemoveQuoteFromPairsDataStruct(Quote quote)
        {
            int length = quote.Text.Length;
            if(pairsDictionary.ContainsKey(length))
            {
                if(pairsDictionary[length] == 1)
                {
                    pairsDictionary.Remove(length);
                }
                else 
                {
                    pairsDictionary[length] = pairsDictionary[length]-1;
                }
            } 
        }

        public int GetNumberOfPairs(int length)
        {
            int retVal = 0;
            for (int i = 0; i< length; ++i)
            {
                if(pairsDictionary.ContainsKey(i))
                {
                    if (2*i <=length)
                    {
                        retVal += (pairsDictionary[i] * pairsDictionary[i] -1 ) / 2;
                    }
                    for (int j = i +1; j <= length-i; ++j)
                    {
                        if(pairsDictionary.ContainsKey(j))
                        {
                            retVal += pairsDictionary[i]*pairsDictionary[j];
                        }
                    }
                }

            }
            return retVal;
        }
    }
}