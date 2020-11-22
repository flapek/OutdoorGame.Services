using System;

namespace OutdoorGame.Services.Core.Entity
{
    public class Answer
    {
        public Guid QuestionId { get; set; }
        public string Reply { get; set; }
    }
}
