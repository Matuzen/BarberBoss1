namespace BarberBoss.Exception.ExceptionsBase;
public class ErrorOnValidationException(List<string> errorMessages) : BarberBossException
{
    public List<string> Errors { get; set; } = errorMessages;
}
