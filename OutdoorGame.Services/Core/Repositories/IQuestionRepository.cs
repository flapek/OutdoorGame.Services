using OutdoorGame.Services.Core.Entity;
using OutdoorGame.Services.Infrastructure.Mongo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutdoorGame.Services.Core.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<QuestionDocument>> GetAsync(IEnumerable<Guid> ids);
        Task CheckAsync(Answer answer);
        Task AddAsync(Question question);
    }
}
