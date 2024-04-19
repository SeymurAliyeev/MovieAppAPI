using System.Runtime.Serialization;

namespace MovieSolution.Business.CustomExceptions.CommonExceptions;

internal class AlreadyExistException : Exception
{
    public AlreadyExistException(string message)
    {
    }
}
