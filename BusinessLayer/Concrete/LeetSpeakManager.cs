using AutoMapper;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LeetSpeakManager : ILeetSpeakService
    {
        private readonly IMapper _mapper;
        private readonly ILeetSpeakDal _leetspeakDal;
        public LeetSpeakManager(IMapper mapper, ILeetSpeakDal leetspeakDal)
        {
            _mapper = mapper;
            _leetspeakDal = leetspeakDal;
        }

        public Task<LeetSpeakTranslator> CreateLeetSpeak(LeetSpeakTranslator leetTranslator)
        {
            var create = _leetspeakDal.Create(leetTranslator);
            return create;
        }

        public void DeleteRecord(int id)
        {
            _leetspeakDal.DeleteContent(id);
            
        }

       
        
    }
}
