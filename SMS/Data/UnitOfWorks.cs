
using System.Text.Json;
using Entities;

namespace Data;

public class UnitOfWorks : IUnitOfWork
{
    public StudentRepository StudentRepository { get; private set; }
    public CourseRepository CourseRepository { get; private set; }
    public SemesterRepository SemesterRepository { get; private set; }
    public List<Semester> Semesters { get; private set; }

    private string _filePath = string.Empty;
    private string _studentsFilePath = string.Empty;
    private string _coursesFilePath = string.Empty;
    private string _semestersFilePath = string.Empty;

    public UnitOfWorks(List<Student> students, List<Course> courses, List<Semester> semesters)
    {
        StudentRepository = new StudentRepository(students);
        CourseRepository = new CourseRepository(courses);
        SemesterRepository = new SemesterRepository(semesters);
        Semesters = semesters;

        SetFilePath();
        CreateFile();
        LoadData();
    }

    public void SetFilePath(string path = "../Data")
    {
        _filePath = path;
        _studentsFilePath = $"{_filePath}/students.json";
        _coursesFilePath = $"{_filePath}/courses.json";
        _semestersFilePath = $"{_filePath}/semesters.json";
    }

    public void CreateFile()
    {
        if(!File.Exists(_studentsFilePath)) File.Create(_studentsFilePath);
        if(!File.Exists(_coursesFilePath)) File.Create(_coursesFilePath);
        if(!File.Exists(_semestersFilePath)) File.Create(_semestersFilePath);
    }

    public void LoadData()
    {
        if(File.Exists(_studentsFilePath))
        {
            StudentRepository.LoadValues(_studentsFilePath);
        }

        if(File.Exists(_coursesFilePath))
        {
            CourseRepository.LoadValues(_coursesFilePath);
        }

        if(File.Exists(_semestersFilePath))
        {
            SemesterRepository.LoadValues(_semestersFilePath);
        }
    }

    public void SaveChanges()
    {
        if(!StudentRepository.IsPristine)
        {
            var serializedStudents = JsonSerializer.Serialize(StudentRepository.Students);
            File.WriteAllText(_studentsFilePath, serializedStudents);

            StudentRepository.IsPristine = !StudentRepository.IsPristine;
        }

        if(!CourseRepository.IsPristine)
        {
            var serializedCourses = JsonSerializer.Serialize(CourseRepository.Courses);
            File.WriteAllText(_coursesFilePath, serializedCourses);

            CourseRepository.IsPristine = !CourseRepository.IsPristine;
        }

        if(!SemesterRepository.IsPristine)
        {
            var serializedSemesters = JsonSerializer.Serialize(SemesterRepository.Semesters);
            File.WriteAllText(_semestersFilePath, serializedSemesters);

            SemesterRepository.IsPristine = !SemesterRepository.IsPristine;
        }

    }

    // responsible to seed the course values.
    private void InsertDummyCourses(List<Course> courses)
    {
        courses.Add(new()
        {
            Id = "AOL 101",
            Name = "Art of Living",
            Credit = 3
        });

        courses.Add(new()
        {
            Id = "SE 111",
            Name = "Computer Fundamentals",
            Credit = 3
        });

        courses.Add(new()
        {
            Id = "SE 112",
            Name = "Computer Fundamentals Lab",
            Credit = 1
        });

        courses.Add(new()
        {
            Id = "SE 113",
            Name = "Introduction To Software Engineering",
            Credit = 3
        });


        courses.Add(new()
        {
            Id = "SE 114",
            Name = "English",
            Credit = 3
        });

        courses.Add(new()
        {
            Id = "MAT 124",
            Name = "Math-I",
            Credit = 3
        });

        File.WriteAllText(_coursesFilePath, JsonSerializer.Serialize(courses));
    }
}