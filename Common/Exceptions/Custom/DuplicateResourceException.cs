

namespace learndotnetfast_web_services.Common.Exceptions.Custom
{
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException(string message)
            : base(message)
        {

        }
    }
}
