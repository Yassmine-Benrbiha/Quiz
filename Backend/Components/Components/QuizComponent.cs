using AutoMapper;
using Components.Contracts;
using Components.DTO;
using Data.Contracts;
using Data.Models;
using QuizDTO = Components.DTO.QuizDTO;

namespace Components.Components
{
    public class QuizComponent : IQuizComponent
    {
        private readonly IMapper _mapper;
        private readonly IQuizRepository _quizRepository;

        public QuizComponent(IMapper mapper, IQuizRepository quizRepository)
        {
            _mapper = mapper;
            _quizRepository = quizRepository;
        }

        public async Task<QuizDTO> GeQuizById(Guid quizId)
        {
            var quiz = await _quizRepository.GetById(quizId);
            return _mapper.Map<QuizDTO>(quiz);
        }

        
        public async Task<IEnumerable<QuizDTO>> GetQuizzes()
        {
            var result = await _quizRepository.GetAll();
            return _mapper.Map<IEnumerable<QuizDTO>>(result);
        }

        
        public async Task<QuizDTO> Add(QuizDTO quiz) 
        {
            var result = _mapper.Map<Data.Models.Quiz>(quiz);
            //var options = new List<Data.Models.Option> ();
            var questions = new List<Data.Models.Question>();
            var questionModel = new Question();
            foreach (var question in quiz.Questions.ToList())
            {
                questionModel = _mapper.Map<Data.Models.Question>(question);
                foreach (var option in question.Options.ToList())
                {
                    var optionModel = _mapper.Map<Data.Models.Option>(option);
                    optionModel.OptLastModifiedDate = DateTime.UtcNow;
                   // options.Add(optionModel);
                    questionModel.QuestionOptions.Add(new QuestionOption { Opt = optionModel });
                }
                questions.Add(questionModel);
            }
            var quizModel = await _quizRepository.Add(result, questions);
            return _mapper.Map<QuizDTO>(quizModel);
        }

        /*
        public async Task<CaseTypeDto> Update(AddCaseTypeDto caseType)
        {
            await ValidateCaseType(caseType.CtyName, caseType.CtyId);
            var result = _mapper.Map<CaseTypeModel>(caseType);
            var casetypeModel = await _caseTypeRepository.Update(result, _mapper.Map<List<Data.Models.Location>>(caseType.Locations),
                _mapper.Map<List<Data.Models.ClientPolicyControlException>>(caseType.ClientPolicyControlExceptions),
                _mapper.Map<List<Data.Models.HelpPlan>>(caseType.HelpPlans), _mapper.Map<List<Data.Models.HelpPlanType>>(caseType.HelpPlanTypes));
            return _mapper.Map<CaseTypeDto>(casetypeModel);
        }

        public async Task Delete(Guid caseTypeId)
        {
            await _caseTypeRepository.Delete(caseTypeId);
        }

        public async Task<IEnumerable<WizardCaseTypeDto>> GetActivePublishedCaseTypes()
        {
            var result = await _caseTypeRepository.GetActivePublishedCaseTypes();
            var mappedCaseTypes = _mapper.Map<IEnumerable<WizardCaseTypeDto>>(result);
            foreach (var ct in mappedCaseTypes)
            {
                foreach (var hp in ct.HelpPlans)
                {
                    hp.HelpPlanTypeIds = await _helpPlanTypeRepository.GetHelpPlanTypesByHelpPlanId(hp.HplId);
                }
            }
            return mappedCaseTypes;
        }

        private async Task ValidateCaseType(string name, Guid? caseTypeId = default)
        {
            if (!await CheckCaseTypeNameUnicity(name, caseTypeId))
            {
                throw new InvalidCaseTypeException($"Name: {name} Should be unique");
            }
        }

        private async Task<bool> CheckCaseTypeNameUnicity(string name, Guid? caseTypeId)
        {
            return await _caseTypeRepository.GetCaseTypeByName(name, caseTypeId) == null;
        }*/
    }
}