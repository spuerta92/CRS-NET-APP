namespace CRS_EXCEPTIONS
{
    public class CourseNotRegisteredException : Exception
    {
        public CourseNotRegisteredException(){}
        public CourseNotRegisteredException(string message) : base(message) { }
        public CourseNotRegisteredException(string message, Exception innerException) : base(message, innerException) {}
    }
}