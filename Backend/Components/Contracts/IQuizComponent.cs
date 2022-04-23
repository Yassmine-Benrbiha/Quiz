using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using QuizDTO = Components.DTO.QuizDTO;

namespace Components.Contracts
{
    public interface IQuizComponent
    {
        Task<QuizDTO> GeQuizById(Guid quizId);
        Task<IEnumerable<QuizDTO>> GetQuizzes();
        Task<QuizDTO> Add(QuizDTO quiz);
        /*
         Task<IEnumerable<QuizDTO>> GetCaseTypes();
         Task<AddCaseTypeDto> GetCaseTypeById(Guid caseTypeId);
     
         Task<CaseTypeDto> Update(AddCaseTypeDto caseType);
         Task Delete(Guid caseTypeId);
         Task<IEnumerable<WizardCaseTypeDto>> GetActivePublishedCaseTypes();*/
    }
}