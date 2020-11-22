using System;
using System.Collections.Generic;

namespace OutdoorGame.Services.Core.Entity
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> QuestionId { get; set; }
        public List<Waypoint> Waypoints { get; set; }

    }
}
