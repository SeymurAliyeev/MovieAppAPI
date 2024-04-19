using System.Runtime.Serialization;

namespace MovieSolution.Business.CustomExceptions.CommonExceptions;

public class NotFoundException : Exception
{
    public NotFoundException( string message)
    {
    }
}
