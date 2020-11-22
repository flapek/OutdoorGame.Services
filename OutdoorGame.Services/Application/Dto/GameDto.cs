using OutdoorGame.Services.Infrastructure.Mongo;
using System;
using System.Collections.Generic;

namespace OutdoorGame.Services.Application.Dto
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> QuestionId { get; set; }
        public List<WaypointDocument> Waypoints { get; set; }
    }
}