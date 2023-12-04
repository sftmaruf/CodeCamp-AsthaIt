using Models;
using UI.Interfaces;

namespace UI;

public class StudentOutputProducer : IOutputProducer<StudentModel>
{

    public void ShowList(IReadOnlyList<StudentModel> students)
    {
        Console.WriteLine("Id          Name");
        foreach(var student in students)
        {
            Console.WriteLine($"{student.StudentId} {student.GetFullName()}");
        }
    }

    public void ShowDetails(StudentModel student)
    {
        if(student == null) 
        {
            Console.WriteLine("Sorry student account doesn't exist.");
            return;
        }

        Console.WriteLine($"{nameof(student.FirstName)}: {student.FirstName}");
        Console.WriteLine($"{nameof(student.MiddleName)}: {student.MiddleName}");
        Console.WriteLine($"{nameof(student.LastName)}: {student.LastName}");
        Console.WriteLine($"{nameof(student.JoiningBatch)}: {student.JoiningBatch}");
        Console.WriteLine($"{nameof(student.Department)}: {student.Department}");
        Console.WriteLine($"{nameof(student.Degree)}: {student.Degree}");

        if(student.AttendedSemesters.Count > 0)
        {
            Console.WriteLine("Semesters: ");
            foreach(var semester in student.AttendedSemesters)
            {
                new SemesterOutputProducer().ShowDetails(new() {
                    SemesterCode = semester.SemesterCode,
                    Year = semester.Year,
                    NumberOfCredits = semester.NumberOfCredits,
                    Courses = semester.Courses
                });
                Console.WriteLine();
            }
        }
    }
}