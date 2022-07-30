using Entities.Concrete;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;


namespace DataAccess.Abstract
{
    public interface ILeetSpeakDal : IBaseRepository<LeetSpeakTranslator>
    {
        Task<LeetSpeakTranslator> Create(LeetSpeakTranslator leetTranslator);
        Contents GetContent(Expression<Func<Contents, bool>> filter);
        void DeleteContent(int id);
    }
}