using Joint.Exception.Exceptions;
using System.Net;

namespace OutdoorGame.Services.Core.Exceptions
{
    public class AnswerIsIncorectException : DomainException
    {
        public override string Code => "answer_is_incorect_exception";
        public override HttpStatusCode StatusCodes => HttpStatusCode.BadRequest;
        
        public AnswerIsIncorectException(string message) : base($"Bad Answer for question! \nYour answer: {message}")
        {
        }

    }
}
