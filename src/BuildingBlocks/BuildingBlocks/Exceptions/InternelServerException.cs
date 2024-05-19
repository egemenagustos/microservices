namespace BuildingBlocks.Exceptions
{
    public class InternelServerException : Exception
    {
        public string? Details { get; set; }

        public InternelServerException()
        {
        }

        public InternelServerException(string? message) : base(message)
        {
        }

        public InternelServerException(string? message, string? details) : base(message)
        {
            Details = details;
        }
    }
}
