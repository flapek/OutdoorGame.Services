﻿using Joint.Exception.Exceptions;
using System;
using System.Net;

namespace OutdoorGame.Services.Infrastructure.Exceptions
{
    internal sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, ex.StatusCodes),
                AppException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, ex.StatusCodes),
                InfrastructureException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, ex.StatusCodes),
                _ => new ExceptionResponse(new { code = "error", reason = "There was an error." }, HttpStatusCode.BadRequest)
            };
    }
}
