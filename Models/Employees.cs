namespace Scenario2.Models;

public class Employees
{
    public int Id { get; set; }
    public bool IsManager { get; set; }
    public bool IsCEO { get; set; }
    public decimal Salary { get; set; }
    public int? ManagerId { get; set; }
}