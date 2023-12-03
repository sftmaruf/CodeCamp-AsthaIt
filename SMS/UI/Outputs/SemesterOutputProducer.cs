using Models;
using UI.Interfaces;

namespace UI;

public class SemesterOutputProducer : IOutputProducer<SemesterModel>
{
    public void ShowDetails(SemesterModel item)
    {
        Console.WriteLine($"{nameof(item.SemesterCode)}: {item.SemesterCode+item.Year}");
        Console.WriteLine($"{nameof(item.NumberOfCredits)}: {item.NumberOfCredits}");
        Console.WriteLine($"{nameof(item.Courses)}: ");

        foreach(var course in item.Courses!)
        {
            Console.WriteLine($"\t{nameof(course.Id)}: {course.Id}");
            Console.WriteLine($"\t{nameof(course.Name)}: {course.Name}");
            Console.WriteLine($"\t{nameof(course.Credit)}: {course.Credit}");
            Console.WriteLine($"\t{nameof(course.InstructorName)}: {course.InstructorName}");
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