using System;

namespace OutdoorGame.Services.Application.Dto
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}
