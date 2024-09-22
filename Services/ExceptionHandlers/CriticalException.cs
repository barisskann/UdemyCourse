namespace Services.ExceptionHandlers;

public class CriticalException(string errorMessage) : Exception(errorMessage)
{
}
