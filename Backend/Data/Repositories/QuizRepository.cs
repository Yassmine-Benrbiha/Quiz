using Data.Contracts;
using CED.Alpha.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class QuizRepository : IQuizRepository, IDisposable
    {
        private myDatabaseContext _myDatabaseContext;

        public QuizRepository(
            myDatabaseContext myDatabaseContext)
        {
            _myDatabaseContext = myDatabaseContext;            
        }

        public async Task<Quiz> GetById(Guid quizId)
        {
            try
            {
                return await _myDatabaseContext.Quizzes
                    .Include(quiz => quiz.QuizQuestions)
                    .ThenInclude(ctl => ctl.Que)
                    .ThenInclude(ctl => ctl.QuestionOptions)
                    .ThenInclude(ctl => ctl.Opt)
                    .SingleOrDefaultAsync(quiz => quiz.QuiId == quizId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return await _myDatabaseContext.Quizzes.ToListAsync();
        }


        public async Task<Quiz> Add(Quiz quiz, List<Question> questions)
        {
            using (var context = _myDatabaseContext)
            {
                {
                    try
                    {
                        quiz.QuiLastModifiedDate = DateTime.UtcNow;

                        AddQuestions(quiz, questions);

                        await context.Quizzes.AddAsync(quiz);

                        await context.SaveChangesAsync();
                        return quiz;
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
        }
            

        public void AddQuestions(Quiz quiz, List<Question> questions)
        {
            foreach (var question in questions.ToList())
            {
                question.QueLastModifiedDate = DateTime.UtcNow;
                quiz.QuizQuestions.Add(new QuizQuestion { Que = question }); 
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_myDatabaseContext != null)
                {
                    _myDatabaseContext.Dispose();
                    _myDatabaseContext = null;
                }
            }
        }
    }
}
