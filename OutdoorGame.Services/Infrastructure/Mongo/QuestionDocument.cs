using Joint.Types;
using System;

namespace OutdoorGame.Services.Infrastructure.Mongo
{
    public sealed class QuestionDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public string[] Answers { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}
