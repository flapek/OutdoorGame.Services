using Elasticsearch.Net.Specification.WatcherApi;
using Joint.DB.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OutdoorGame.Services.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorGame.Services.Infrastructure.Mongo
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMongo(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();

            var users = scope.ServiceProvider.GetService<IMongoRepository<QuestionDocument, Guid>>().Collection;
            var userBuilder = Builders<QuestionDocument>.IndexKeys;
            Task.Run(async () => await users.Indexes.CreateOneAsync(
                new CreateIndexModel<QuestionDocument>(userBuilder.Ascending(i => i.Name),
                    new CreateIndexOptions
                    {
                        Unique = true
                    })));

            return builder;
        }

        public static List<QuestionDocument> AsList(this IReadOnlyList<QuestionDocument> userDocuments)
            => userDocuments.Select(document => document).ToList();

        public static List<GameDocument> AsList(this IReadOnlyList<GameDocument> userDocuments)
            => userDocuments.Select(document => document).ToList();

        public static List<WaypointDocument> AsList(this IReadOnlyList<Waypoint> waypoints)
            => waypoints.Select(document => document.AsDocument()).ToList();

        public static WaypointDocument AsDocument(this Waypoint waypoint)
            => new WaypointDocument
            {
                City = waypoint.City,
                Country = waypoint.Country,
                Number = waypoint.Number,
                Street = waypoint.Street
            };

        public static GameDocument AsDocument(this Game game)
            => new GameDocument
            {
                Id = game.Id,
                Name = game.Name,
                QuestionId = game.QuestionId,
                Places = game.Waypoints.AsList()
            };

        public static QuestionDocument AsDocument(this Question question)
            => new QuestionDocument
            {
                Id = question.Id,
                Name = question.Name,
                Query = question.Query,
                Answers = question.Answers,
                IsActive = question.IsActive,
                IsVisible = question.IsVisible
            };
    }
}
