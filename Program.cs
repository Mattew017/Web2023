using EntityFrameworkConsole;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine(DateTime.Parse("2023-03-19").ToString("dd/MMyyyy"));
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    // ������� ������
    Department department1 = new Department { Name = "������ �����" };
    Department department2 = new Department { Name = "������ �����" };
    // ������� ���� ��������
    VacationType vacationType1 = new VacationType { Type = "�������� ������������ ������" };
    VacationType vacationType2 = new VacationType { Type = "�������������� ������������ ������" };
    VacationType vacationType3 = new VacationType { Type = "������ ��� ���������� ���������� �����" };
    // ������� �����������
    Employee employee1 = new Employee
    {
        Name = "����",
        LastName = "������",
        Passport = "12312",
        PhoneNumber = "789809877",
        Adress = "���, ��. �������, �. �����������",
        Position = "�����������",
        Department = department1,
    };
    Employee employee2 = new Employee
    {
        Name = "����",
        LastName = "������",
        Passport = "345345",
        PhoneNumber = "9583459378",
        Adress = "���, ��. �������, �. �����������",
        Position = "�����������",
        Department = department2
    };
    // ������� �������
    Vacation vacation1 = new Vacation
    {
        VacationType = vacationType1,
        StartDate = DateTime.Parse("02-05-2022"),
        EndDate = DateTime.Parse("15-06-2022"),
        Employee = employee1,
    };
    Vacation vacation2 = new Vacation
    {
        VacationType = vacationType2,
        StartDate = DateTime.Parse("11-09-2022"),
        EndDate = DateTime.Parse("23-12-2022"),
        Employee = employee2,
    };
    // ������ ������������
    BusinessTrip trip1 = new BusinessTrip
    {
        Purpose = "���� ������������",
        Adress = "������ ������������",
        Employee = employee1,
        StartDate = DateTime.Parse("02-12-2020"),
        EndDate = DateTime.Now,
    };

    BusinessTrip trip2 = new BusinessTrip
    {
        Purpose = "���� ������������2",
        Adress = "������ ������������2",
        Employee = employee1,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
    };
    // ��������� �� � ��
    db.Departments.AddRange(department1, department2);
    db.VacationTypes.AddRange(vacationType1, vacationType2, vacationType3);
    db.Employees.AddRange(employee1, employee2);
    db.Vacations.AddRange(vacation1, vacation2);
    db.BusinessTrips.AddRange(trip1, trip2);
    db.SaveChanges();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore;
    }
    );
builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed((host) => true)
                .AllowAnyHeader());
    });
var app = builder.Build();
app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
