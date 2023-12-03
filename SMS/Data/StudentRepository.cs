using System.Text.Json;
using Data.Interfaces;
using Entities;
using Utility;

namespace Data;

public class StudentRepository : IRepository
{
    public List<Student> Students { get; private set; }
    public bool IsPristine { get; set; } = true;

    public StudentRepository(List<Student> students)
    {
        Students = students;
    }

    public void LoadValues(string filePath)
    {
        if(File.Exists(filePath))
        {
            var studentsJson = File.ReadAllText(filePath);

            if (!string.IsNullOrWhiteSpace(studentsJson)) 
                Students = JsonSerializer.Deserialize<List<Student>>(studentsJson)!;
        }
    }

    public IResult Add(Student student)
    {
        Students.Add(student);
        IsPristine = false;

        return Result<Student>.Success();
    }

    public IResult<List<Student>> GetAll()
    {
        return Result<List<Student>>.Success(Students);
    }

    public IResult<Student> GetById(Guid id)
    {
         var student = Students.SingleOrDefault(student => student.Id == id);
        if(student is not null) return Result<Student>.Success(student);

        return Result<Student>.Fail("Student not found");
    }

    public IResult DeleteById(Guid id)
    {
        var result = GetById(id);
        if(!result.IsSuccess) return Result<Student>.Fail("Student not found");
        var student = result.Data!;

        var isRemoved = Students.Remove(student);
        if(!isRemoved) return Result<Student>.Fail("Deleting operation failed.");
        IsPristine = false;

        return Result<Student>.Success();
    }
}