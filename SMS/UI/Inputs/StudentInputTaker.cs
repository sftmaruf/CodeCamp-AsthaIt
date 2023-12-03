using System.Text;
using Commons;
using Models;
using UI.Interfaces;

namespace UI;

public class StudentInputTaker : IInputTaker
{
    private readonly StudentModel _studentModel;

    public StudentInputTaker(StudentModel studentModel)
    {
        _studentModel = studentModel;
    }

    private void ShowPrompt()
    {
        Console.WriteLine("Please provide the following information:");
    }

    public void TakeInput()
    {
        ShowPrompt();

        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        
        Console.Write("Middle Name: ");
        var middleName = Console.ReadLine();
        
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();
        
        Console.Write("Joining Batch: ");
        var joiningBatch = Console.ReadLine();
        
        var department = TakeInputDepartment();
        
        var degree = TakeInputDegree();

        _studentModel.FirstName = firstName!;
        _studentModel.MiddleName = middleName!;
        _studentModel.LastName = lastName!;
        _studentModel.JoiningBatch = joiningBatch!;
        _studentModel.Department = department;
        _studentModel.Degree = degree;
    }

    private string TakeInputDepartment()
    {
        var label = new StringBuilder();
        var departmentNames = Enum.GetNames<Department>();

        foreach(var name in departmentNames)
            label.Append($"{name} ");

        Console.WriteLine("Available department names: " + label.ToString().Trim());
        Console.Write("Department: ");
        var input = Console.ReadLine()!.Trim();

        if(!departmentNames.Contains(input))
        {
            throw new Exception("Invalid department name. Try again with a valid department name.");
        }

        return input;
    }

    private string TakeInputDegree()
    {
        var label = new StringBuilder();
        var degreeNames = Enum.GetNames<Degree>();

        foreach(var name in degreeNames) label.Append($"{name} ");

        Console.WriteLine("Available degrees: " + label.ToString().Trim());
        Console.Write("Degree: ");
        var input = Console.ReadLine()!.Trim();

        if(!degreeNames.Contains(input))
        {
            throw new Exception("Invalid degree name. Try again with a valid degree name.");
        }

        return input;
    }
}