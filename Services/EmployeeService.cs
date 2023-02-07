using Scenario2.Models;

namespace Scenario2.Services;

public static class EmployeeService
{
    static List<Employees> Employees { get; }
    static int nextId = 3;
    static EmployeeService()
    {
        Employees = new List<Employees>
        {
            new Employees { Id = 1, IsManager = false, IsCEO = true , Salary = 400 , ManagerId = null },
            new Employees { Id = 2, IsManager = true, IsCEO = false , Salary = 40 , ManagerId = null }
        };
    }

    public static List<Employees> GetAll() => Employees;

    public static Employees? Get(int id) => Employees.FirstOrDefault(p => p.Id == id);

    public static void Add(Employees employee)
    {
        employee.Id = nextId++;
        Employees.Add(employee);
    }

    public static void Delete(int id)
    {
        var employee = Get(id);
        if(employee is null)
            return;

        Employees.Remove(employee);
    }

    public static void Update(Employees employee)
    {
        var index = Employees.FindIndex(p => p.Id == employee.Id);
        if(index == -1)
            return;

        Employees[index] = employee;
    }
}