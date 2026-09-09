using System;

public class Person
{
    public string Id { get; init; }
    public string FullName { get; set; }
    public int BirthYear { get; set; }

    public Person(string id, string fullName, int birthYear)
    {
        Id = id;
        FullName = fullName;
        BirthYear = birthYear;
    }

    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }
}

public class Employee : Person
{
    public decimal BaseSalary { get; set; }

    public Employee(
        string id,
        string fullName,
        int birthYear,
        decimal baseSalary)
        : base(id, fullName, birthYear)
    {
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateIncome()
    {
        return BaseSalary;
    }
}

internal sealed class Manager : Employee
{
    public decimal ResponsibilityAllowance { get; set; }

    public Manager(
        string id,
        string fullName,
        int birthYear,
        decimal baseSalary,
        decimal allowance)
        : base(id, fullName, birthYear, baseSalary)
    {
        ResponsibilityAllowance = allowance;
    }

    public override decimal CalculateIncome()
    {
        return BaseSalary + ResponsibilityAllowance;
    }
}

class Program
{
    static void Main()
    {
        int currentYear = 2026;

        Employee employee = new Employee(
            "E001",
            "Nguyen Van An",
            2003,
            10000000);

        Manager manager = new Manager(
            "M001",
            "Tran Thi Binh",
            1995,
            20000000,
            5000000);

        Console.WriteLine("===== PHIEU LUONG EMPLOYEE =====");
        Console.WriteLine("Ten: " + employee.FullName);
        Console.WriteLine("Tuoi: " + employee.GetAge(currentYear));
        Console.WriteLine("Luong co ban: " + employee.BaseSalary + " VNĐ");
        Console.WriteLine(
            "Thu nhap thuc linh: " + employee.CalculateIncome() + " VNĐ");

        Console.WriteLine();

        Console.WriteLine("===== PHIEU LUONG MANAGER =====");
        Console.WriteLine("Ten: " + manager.FullName);
        Console.WriteLine("Tuoi: " + manager.GetAge(currentYear));
        Console.WriteLine("Luong co ban: " + manager.BaseSalary + " VNĐ");
        Console.WriteLine(
            "Thu nhap thuc linh: " + manager.CalculateIncome() + " VNĐ");

        // Không thể tạo lớp kế thừa từ Manager
        // vì Manager được khai báo là sealed.
        //
        // class Director : Manager
        // {
        // }
    }
}