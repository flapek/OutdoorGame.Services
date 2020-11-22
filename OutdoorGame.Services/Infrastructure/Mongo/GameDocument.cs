using Joint.Types;
using System;
using System.Collections.Generic;

namespace OutdoorGame.Services.Infrastructure.Mongo
{
    public class GameDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> QuestionId { get; set; }
        public List<WaypointDocument> Places { get; set; }
    }
}
