using BarberBoss.Communication.Enums;
using System.ComponentModel.DataAnnotations;

namespace BarberBoss.Communication.Requests;
public class RequestRegisterExpenseJSon
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public EPagamentType Type { get; set; }
}
