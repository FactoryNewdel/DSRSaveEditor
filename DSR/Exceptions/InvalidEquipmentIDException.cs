namespace DSR.Exceptions;

public class InvalidEquipmentIDException : Exception
{
    public InvalidEquipmentIDException()
    {
    }

    public InvalidEquipmentIDException(string? message) : base(message)
    {
    }
}