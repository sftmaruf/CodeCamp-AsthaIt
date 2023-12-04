using Models;
using UI.Interfaces;
using Utility;

namespace UI;

public class Screen : IScreen 
{
    private Dictionary<int, string> _options = new();

    public void ShowTitle(string title) {
        Console.WriteLine($"{title}\n");
    }

    public void AddOptions(string[] labels) 
    {
        for(var i = 0; i < labels.Length; i++)
        {
            _options.Add(_options.Count + 1, labels[i]);
        }
    }

    public void ShowOptions()
    {
        foreach(var key in _options.Keys)
        {
            Console.WriteLine($"{key}. {_options[key]}");
        }

        Console.WriteLine("*Type 'exit' to exit the application and 'cls' to clear the screen.");
    }

    public void ShowStudent(List<StudentModel> students)
    {
        foreach(var student in students)
        {
            Console.WriteLine($"Name: {student.GetFullName()}");
        }
    }

    public (string? response, bool forward) WaitForResponse()
    {
        Console.Write(">>> ");
        var response = Console.ReadLine();

        return response == "exit"  ? (response, false) : (response, true);
    }

    public IResult TakeInput(IInputTaker inputTaker)
    {
       try {
            inputTaker.TakeInput();
            return Result<Screen>.Success();
       }
       catch(Exception ex)
       {
            return Result<Screen>.Fail(ex.Message);
       }
    }

    public void ShowList<T>(IOutputProducer<T> outputProducer, IReadOnlyList<T> lists)
    {
        outputProducer.ShowList(lists);
    }

    public void ShowDetails<T>(IOutputProducer<T> outputProducer, T item)
    {
        outputProducer.ShowDetails(item);
    }
}