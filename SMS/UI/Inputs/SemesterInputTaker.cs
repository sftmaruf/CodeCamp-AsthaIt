using Models;
using UI.Interfaces;

namespace UI;

public class SemesterInputTaker : IInputTaker
{
    private readonly SemesterModel _semesterModel;

    public SemesterInputTaker(SemesterModel semesterModel)
    {
        _semesterModel = semesterModel;
    }

    public void TakeInput()
    {
        Console.Write("Season: ");
        var semesterCode = Console.ReadLine();
        Console.Write("Year: ");
        var year = Console.ReadLine();

        _semesterModel.SemesterCode = semesterCode!;
        _semesterModel.Year = year!;
    }
}