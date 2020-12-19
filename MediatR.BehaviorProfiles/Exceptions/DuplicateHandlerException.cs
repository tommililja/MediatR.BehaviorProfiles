using System;

namespace MediatR.BehaviorProfiles.Exceptions
{
    public class DuplicateHandlerException : Exception
    {
        public DuplicateHandlerException(string handler) : base($"Handler {handler} has already been included.")
        {

        }
    }
}