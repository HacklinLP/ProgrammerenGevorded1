namespace BedrijvenDomein;

public class BedrijfsException : Exception
{
    public BedrijfsException()
    {
    }

    public BedrijfsException(string? message) : base(message)
    {
    }

    public BedrijfsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}