using OutdoorGame.Services.Infrastructure.Mongo;
using System.Collections.Generic;
using System.Linq;

namespace OutdoorGame.Services.Application.Dto
{
    public static class Extension
    {
        public static List<QuestionDto> AsDto(this List<QuestionDocument> games)
            => games.Select(x => x.AsDto()).ToList();

        public static QuestionDto AsDto(this QuestionDocument game)
            => new QuestionDto
            {
                Id = game.Id,
                Name = game.Name,
                Query = game.Query,
                IsActive = game.IsActive,
                IsVisible = game.IsVisible
            };

        public static GamesDto AsDto(this List<GameDocument> games)
            => new GamesDto { GamesDtos = games.Select(x => x.AsDto()).ToList() };

        public static GameDto AsDto(this GameDocument game)
            => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Waypoints = game.Places.ToList(),
                QuestionId = game.QuestionId.ToList()
            };
    }
}
