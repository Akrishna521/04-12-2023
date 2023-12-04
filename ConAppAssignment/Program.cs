using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "Krishna",
            LastName = "Anishetty",
            Salary = 75000.00
        };
        SerializeEmployee(employee);
        Employee deserializedEmployee = DeserializeEmployee();
        Console.WriteLine("Deserialized Employee:");
        Console.WriteLine($"ID: {deserializedEmployee.Id}");
        Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
        Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
        Console.WriteLine($"Salary: {deserializedEmployee.Salary}");

        Console.ReadLine();
    }

    static void SerializeEmployee(Employee employee)
    {
        IFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("employee.bin", FileMode.Create))
        {
            formatter.Serialize(fs, employee);
        }
    }

    static Employee DeserializeEmployee()
    {
        IFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("employee.bin", FileMode.Open))
        {
            return (Employee)formatter.Deserialize(fs);
        }
    }
}
