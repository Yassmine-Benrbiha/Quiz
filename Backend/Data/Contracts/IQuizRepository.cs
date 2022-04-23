
using Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IQuizRepository
    {
         Task<Quiz> GetById(Guid quizId);
         Task<IEnumerable<Quiz>> GetAll();
        Task<Quiz> Add(Quiz casetype, List<Question> questions);
    }
}