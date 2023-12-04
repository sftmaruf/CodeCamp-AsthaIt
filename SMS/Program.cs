using System.Text.RegularExpressions;
using Data;
using Entities;
using Models;
using Services;
using UI;
using Validators;

var unitOfWork = new UnitOfWorks(new List<Student>(), new List<Course>(), new List<Semester>());

var screen = new Screen();
screen.AddOptions(new string[] {
    "List of Students",
    "Add New Student",
    "View Student Details",
    "Delete Student",
    "Courses List",
    "Add Semester",
    "Add Course"
});

screen.ShowTitle("** Welcome to the Student Management System **");
screen.ShowOptions();

while(true)
{    
    var (response, forward) = screen.WaitForResponse();
    Console.WriteLine($"You have selected options '{response}'.\n");

    switch(response)
    {
        case "1":
            {
                var studentModel = new StudentModel(new StudentService(unitOfWork));
                var result = studentModel.GetAllStudents();
                screen.ShowList(new StudentOutputProducer(), result.Data!);
                break;
            }
        case "2":
            {
                var studentModel = new StudentModel(new StudentService(unitOfWork));
                var inputResult = screen.TakeInput(new StudentInputTaker(studentModel));
                if(!inputResult.IsSuccess)
                {
                    Console.WriteLine(inputResult.Errors[0]);
                    break;
                } 

                var result = studentModel.AddStudent();
                if(!result.IsSuccess) Console.WriteLine(result.Errors[0]);
                break;
            }
        case "3":
            {
                Console.Write("Student Id: ");
                var studentId = Console.ReadLine()!;
                var idValidation = Regex.Match(studentId, StudentValidator.StudentIdRegex);
                if(!idValidation.Success)
                {
                    Console.WriteLine("Invalid id format.");
                    break;
                }

                var studentModel = new StudentModel(new StudentService(unitOfWork));
                var result = studentModel.GetById(studentId);
                screen.ShowDetails(new StudentOutputProducer(), result.Data!);
                break;
            }
        case "4":
            {
                Console.Write("Student Id: ");
                var studentId = Console.ReadLine()!;
                var idValidation = Regex.Match(studentId, StudentValidator.StudentIdRegex);

                if(!idValidation.Success)
                {
                    Console.WriteLine("Invalid id format.");
                    break;
                }

                var studentModel = new StudentModel(new StudentService(unitOfWork));
                var result = studentModel.DeleteStudent(studentId);

                if(!result.IsSuccess) Console.WriteLine(result.Errors[0]);
                break;
            }
        case "5":
            {
                var courseModel = new CourseModel(new CourseService(unitOfWork));
                var result = courseModel.GetAllCourses();
                screen.ShowList(new CourseOutputProducer(), result.Data!);
                break;
            }
        case "6":
            {
                var semesterModel = new SemesterModel(new SemesterService(unitOfWork));
                var inputResult = screen.TakeInput(new SemesterInputTaker(semesterModel));
                if(!inputResult.IsSuccess)
                {
                    Console.WriteLine(inputResult.Errors[0]);
                    break;
                }

                Console.Write("Student Id: ");
                var studentId = Console.ReadLine()!;
                var idValidation = Regex.Match(studentId, StudentValidator.StudentIdRegex);
                if(!idValidation.Success)
                {
                    Console.WriteLine("Invalid id format.");
                    break;
                }
                
                var studentModel = new StudentModel(new StudentService(unitOfWork));
                var result = studentModel.AddSemester(studentId, semesterModel);
                if(!result.IsSuccess) Console.WriteLine(result.Errors[0]);
                break;   
            }
        case "7":
            {
                Console.Write("Student Id: ");
                var studentId = Console.ReadLine()!;
                var idValidation = Regex.Match(studentId, StudentValidator.StudentIdRegex);
                if(!idValidation.Success)
                {
                    Console.WriteLine("Invalid id format.");
                    break;
                }

                var semesterCourseModel = new SemesterCourseModel(new SemesterService(unitOfWork));
                var courseModel = new CourseModel(new CourseService(unitOfWork));
                var studentModel = new StudentModel(new StudentService(unitOfWork))
                {
                    StudentId = studentId
                };
                var inputResult = screen.TakeInput(new SemesterCourseInputTaker(semesterCourseModel, courseModel, studentModel));
                if(!inputResult.IsSuccess) 
                {
                    Console.WriteLine(inputResult.Errors[0]);
                    break;
                }

                var result = studentModel.AddCourse(studentId, semesterCourseModel);
                if(!result.IsSuccess) Console.WriteLine(result.Errors[0]);
                break;
            }
        case "exit":
            break;
        case "cls":
            Console.Clear();
            screen.ShowOptions();
            break;
        default:
            Console.WriteLine($"Sorry there is no option as `{response}`. Please select a valid option from the provided list.");
            break;
    }

    if(!forward) break;
}