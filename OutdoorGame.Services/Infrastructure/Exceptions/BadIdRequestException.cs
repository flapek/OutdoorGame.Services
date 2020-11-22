using Joint.Exception.Exceptions;
using System;
using System.Net;

namespace OutdoorGame.Services.Infrastructure.Exceptions
{
    public class BadIdRequestException : InfrastructureException
    {
        public override string Code => "bad_id_request_exception";
        public override HttpStatusCode StatusCodes => HttpStatusCode.BadRequest;

        public BadIdRequestException(Guid id) : base($"Incorect id: {id}")
        {
        }
    }
}
