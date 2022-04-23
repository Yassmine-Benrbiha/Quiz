using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;
using AutoMapper;
using Components.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IMapper _mapper;
        private readonly IQuizComponent _quizComponent;

        public QuizController(ILogger<QuizController> logger,
            IMapper mapper,
            IQuizComponent quizComponent)
        {
            _logger = logger;
            _mapper = mapper;
            _quizComponent = quizComponent;
        }



        [HttpGet("GetById/{quizId}")]
        public async Task<QuizVM> GetById(Guid quizId)
        {
            _logger.LogInformation("Info logging");
            try
            {
                var result = await _quizComponent.GeQuizById(quizId);
                return _mapper.Map<QuizVM>(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw exception;
            }
        }

      
        //[Authorize]
        [HttpGet("GetAll")]
        public async Task<IEnumerable<QuizVM>> GetAll()
        {
         
                var result = await _quizComponent.GetQuizzes();
                return _mapper.Map<IEnumerable<QuizVM>>(result);
  
        }

       

      [HttpPost("Post")]
      public async Task<QuizVM> Add(QuizVM quiz)
      {
          _logger.LogInformation("Add a quiz");
          try
          {
              var result = _mapper.Map<Components.DTO.QuizDTO>(quiz);
              var caseType = await _quizComponent.Add(result);
              var quizViewModel = _mapper.Map<QuizVM>(caseType);

              return quizViewModel;
          }

          catch (Exception exception)
          {
              _logger.LogError(exception.Message);
              throw exception;
          }
      }
    }
}