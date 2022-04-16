namespace SchoolOfDev.Exceptions
{
    public class ForbiddenExcepetion : Exception
    {
        public ForbiddenExcepetion() : base() { }

        public ForbiddenExcepetion(string message) : base(message) { }
    }
}
