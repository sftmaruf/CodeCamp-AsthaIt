using Models;
using UI.Interfaces;

namespace UI;

public class SemesterOutputProducer : IOutputProducer<SemesterModel>
{
    public void ShowDetails(SemesterModel item)
    {
        Console.WriteLine($"\t{nameof(item.SemesterCode)}: {item.SemesterCode+item.Year}");
        Console.WriteLine($"\t{nameof(item.NumberOfCredits)}: {item.NumberOfCredits}");
        Console.WriteLine($"\t{nameof(item.Courses)}: ");

        foreach(var course in item.Courses!)
        {
            Console.WriteLine($"\t\t{nameof(course.Id)}: {course.Id}");
            Console.WriteLine($"\t\t{nameof(course.Name)}: {course.Name}");
            Console.WriteLine($"\t\t{nameof(course.Credit)}: {course.Credit}");
            Console.WriteLine($"\t\t{nameof(course.InstructorName)}: {course.InstructorName}");
            Console.WriteLine();
        }
    }

    public void ShowList(IReadOnlyList<SemesterModel> semesters)
    {
        Console.WriteLine("Semesters: ");

        foreach(var semester in semesters)
        {
            Console.WriteLine($"{semester.SemesterCode}{semester.Year}");
        }
    }
}