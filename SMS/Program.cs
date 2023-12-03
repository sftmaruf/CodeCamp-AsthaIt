using Data;
using Entities;
using Models;
using Services;
using UI;

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
    Console.WriteLine($"You have selected options `{response}`\n");

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
                screen.TakeInput(new StudentInputTaker(studentModel));
                var result = studentModel.AddStudent();
                break;
            }
        case "3":
            {
                Console.Write("Student Id: ");
                var isValidId = Guid.TryParse(Console.ReadLine()!, out var studentId);

                if(isValidId)
                {
                    var studentModel = new StudentModel(new StudentService(unitOfWork));
                    var result = studentModel.GetById(studentId);
                    screen.ShowDetails(new StudentOutputProducer(), result.Data!);
                }
                else
                {
                    Console.WriteLine("Invalid id format. Try again with a valid Guid.");
                }
                break;
            }
        case "4":
            {
                var studentModel = new StudentModel(new StudentService(unitOfWork));
                var result = studentModel.DeleteStudent(Guid.Parse(Console.ReadLine()!));

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
                screen.TakeInput(new SemesterInputTaker(semesterModel));

                var studentModel = new StudentModel(new StudentService(unitOfWork));

                Console.Write("Student Id: ");
                var isValidId = Guid.TryParse(Console.ReadLine()!, out var studentId);

                if(isValidId)
                {
                    studentModel.AddSemester(studentId, semesterModel);
                }
                else
                {
                    Console.WriteLine("Invalid id format. Try again with a valid Guid.");
                }
                
                break;   
            }
        case "7":
            {
                var semesterCourseModel = new SemesterCourseModel(new SemesterService(unitOfWork));
                screen.TakeInput(new SemesterCourseInputTaker(semesterCourseModel));

                Console.Write("Student Id: ");
                var isValidId = Guid.TryParse(Console.ReadLine()!, out var studentId);

                if(isValidId)
                {
                    var studentModel = new StudentModel(new StudentService(unitOfWork));
                    var result = studentModel.AddCourse(studentId, semesterCourseModel);
                
                    if(!result.IsSuccess) Console.WriteLine(result.Errors[0]);
                }
                else
                {
                    Console.WriteLine("Invalid id format. Try again with a valid Guid.");
                }

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