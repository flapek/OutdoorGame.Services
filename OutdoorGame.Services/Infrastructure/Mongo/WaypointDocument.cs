using System;

namespace OutdoorGame.Services.Infrastructure.Mongo
{
    public class WaypointDocument
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

    }
}