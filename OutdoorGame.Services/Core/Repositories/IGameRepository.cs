using OutdoorGame.Services.Core.Entity;
using OutdoorGame.Services.Infrastructure.Mongo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutdoorGame.Services.Core.Repositories
{
    public interface IGameRepository
    {
        Task<List<GameDocument>> Get();
        Task<GameDocument> Get(Guid id);
        Task Add(Game game);
    }
}
