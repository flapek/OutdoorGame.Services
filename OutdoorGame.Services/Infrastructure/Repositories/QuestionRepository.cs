using Joint.DB.Mongo;
using OutdoorGame.Services.Core.Entity;
using OutdoorGame.Services.Core.Exceptions;
using OutdoorGame.Services.Core.Repositories;
using OutdoorGame.Services.Infrastructure.Exceptions;
using OutdoorGame.Services.Infrastructure.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorGame.Services.Infrastructure.Repositories
{
    internal sealed class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoRepository<QuestionDocument, Guid> _repository;

        public QuestionRepository(IMongoRepository<QuestionDocument, Guid> repository)
            => _repository = repository;

        public async Task CheckAsync(Answer answer)
        {
            var question = await _repository.GetAsync(answer.QuestionId);

            if (question == null)
                throw new BadIdRequestException(answer.QuestionId);

            if (question.Answers.Any(x => x == answer.Reply))
                return;

            throw new AnswerIsIncorectException(answer.Reply);
        }

        public async Task<List<QuestionDocument>> GetAsync(IEnumerable<Guid> ids)
            => ids.Select(x => _repository.GetAsync(x).Result).ToList();

        public async Task AddAsync(Question question) 
            => await _repository.AddAsync(question.AsDocument());

    }
}
