using DataAccess.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLeetSpeakDal : EfBaseRepository<LeetSpeakTranslator> ,ILeetSpeakDal
    {
        private readonly HttpClient _client;
        private readonly ILeetSpeakDal _leetSpeakDal;
        private readonly ProjectContext _context;
        Uri baseAddress = new Uri("https://api.funtranslations.com/translate/leetspeak.json?text=");

        public EfLeetSpeakDal(ProjectContext context, ILeetSpeakDal leetSpeakDal) : base(context)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _leetSpeakDal = leetSpeakDal;
        }


        public async Task<LeetSpeakTranslator> Create(LeetSpeakTranslator leetSpeakTranslator)
        {
            string data = JsonConvert.SerializeObject(leetSpeakTranslator);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + leetSpeakTranslator.contents.text, content).Result;

            if ((response.IsSuccessStatusCode))
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                var convert = JsonConvert.DeserializeObject<LeetSpeakTranslator>(jsonstring);
                var contents = new Contents();// table that saves text and its translation.
                contents.translated = convert.contents.translated;
                contents.text = convert.contents.text;
                _context.Contents.Add(contents);
                _context.SaveChanges();
            }

            return leetSpeakTranslator;

        }



        public Contents GetContent(Expression<Func<Contents, bool>> filter)
        {
            return _context.Set<Contents>().FirstOrDefault(filter);
        }



        public void DeleteContent(int id)
        {
            var deleteContent = GetContent(a => a.Id == id);
            deleteContent.IsActive = false;
            _context.Update(deleteContent);
            _context.SaveChanges();
        }
        
    }
}
