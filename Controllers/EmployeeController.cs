using Scenario2.Models;
using Scenario2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Scenario2.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {
    }

[HttpGet]
public ActionResult<List<Employees>> GetAll() =>
        EmployeeService.GetAll();
    // GET all action


[HttpGet("{id}")]
public ActionResult<Employees> Get(int id)
{
    var employee = EmployeeService.Get(id);

    if(employee == null)
        return NotFound();

    return employee;
}
    // GET by Id action


[HttpPost]
public IActionResult Create(Employees employee)
{            
    EmployeeService.Add(employee);
    return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
}

[HttpPut("{id}")]
public IActionResult Update(int id, Employees employee)
{

        if (id != employee.Id)
        return BadRequest();
           
    var existingEmployee = EmployeeService.Get(id);
    if(existingEmployee is null)
        return NotFound();
   
    EmployeeService.Update(employee);           
   
    return NoContent();
    // This code will update the employee and return a result
}




[HttpDelete("{id}")]
public IActionResult Delete(int id)
{

    var employee = EmployeeService.Get(id);
   
    if (employee is null)
        return NotFound();
       
    EmployeeService.Delete(id);
   
    return NoContent();
    // This code will delete the employee and return a result
}
}