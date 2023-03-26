using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Сущность "Сотрудник"
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? Passport { get; set; }
    public string? Adress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Position { get; set; }
    // навигационные свойства
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}



// "Отдел организации"
public class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

// Командировки
public class BusinessTrip
{ 
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    public string? Adress { get;set; }
    public string? Purpose { get; set; }
    // навигационное свойство
    public Employee? Employee { get; set; }
    public int EmployeeId { get; set; }
}

public class Vacation
{
    public int Id { get; set; }
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set; }
    public int DaysCount { get; set; }
    // навигационные свойства
    public VacationType? VacationType { get; set; }
    public Employee? Employee { get; set; }
    public int EmployeeId { get; set; }
    public int VacationTypeId { get; set; }
}

// Типы отпусков
public class VacationType
{
    public int Id { get; set; }
    public string? Type { get; set; }
}