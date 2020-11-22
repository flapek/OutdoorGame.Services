using Joint.DB.Mongo;
using OutdoorGame.Services.Core.Entity;
using OutdoorGame.Services.Core.Repositories;
using OutdoorGame.Services.Infrastructure.Exceptions;
using OutdoorGame.Services.Infrastructure.Mongo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutdoorGame.Services.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {

        private readonly IMongoRepository<GameDocument, Guid> _repository;

        public GameRepository(IMongoRepository<GameDocument, Guid> repository)
            => _repository = repository;

        public async Task<List<GameDocument>> Get() 
            => (await _repository.FindAsync(x => true))?.AsList();

        public async Task<GameDocument> Get(Guid id)
            => await _repository.GetAsync(id) ?? throw new BadIdRequestException(id);
        
        public async Task Add(Game game)
        {
            if (game.Id == null)
                game.Id = new Guid();

            await _repository.AddAsync(game.AsDocument());
        }

    }
}
