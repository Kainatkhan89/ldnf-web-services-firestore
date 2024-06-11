using System;

namespace learndotnetfast_web_services.Common.Exceptions.Custom
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message)
            : base(message)
        {
        }
    }
}
