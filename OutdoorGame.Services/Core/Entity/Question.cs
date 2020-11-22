using System;

namespace OutdoorGame.Services.Core.Entity
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public string[] Answers { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}
