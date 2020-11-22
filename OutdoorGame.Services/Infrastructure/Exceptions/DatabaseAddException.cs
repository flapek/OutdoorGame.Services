using Joint.Exception.Exceptions;
using System.Net;

namespace OutdoorGame.Services.Infrastructure.Exceptions
{
    public class DatabaseAddException : InfrastructureException
    {
        public override string Code => "database_add_exception";
        public override HttpStatusCode StatusCodes => HttpStatusCode.InternalServerError;

        public DatabaseAddException() : base("Wrong attempt to add resource!")
        {
        }
    }
}
