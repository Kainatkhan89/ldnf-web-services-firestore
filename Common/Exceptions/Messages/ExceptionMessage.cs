namespace learndotnetfast_web_services.Common.Exceptions.Messages
{
    public static class ExceptionMessage
    {
        public const string ResourceAlreadyExistsError = "Resource already exists";
        public const string NotFoundError = "Not found";
        public const string CourseModuleNotFound = "Course module not found with id: ";
        public const string CourseModuleAlreadyExistsWithTitle = "Course module already exists with title: ";
        public const string CourseModuleAlreadyExistsWithNumber = "Course module already exists with number: ";
        public const string TutorialNotFound = "Tutorial not found with id: ";
        public const string TutorialAlreadyExistsWithTitle = "Tutorial already exists with title: ";
        public const string TutorialAlreadyExistsWithNumber = "Tutorial already exists with number: ";
        public const string InvalidEnumTypeValue = "Invalid icon value";
        public const string DatabaseOperationFailed = "Database operation failed";
    }
}
