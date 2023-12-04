using System.Text.Json;
using Data.Interfaces;
using Entities;
using Utility;

namespace Data;

public class CourseRepository : IRepository
{
    public List<Course> Courses { get; private set; }
    public bool IsPristine { get; set; } = true;

    public CourseRepository(List<Course> courses)
    {
        Courses = courses;
    }

    public void LoadValues(string filePath)
    {
        if(File.Exists(filePath))
        {
            var coursesJson = File.ReadAllText(filePath);

            if (!string.IsNullOrWhiteSpace(coursesJson)) 
                Courses = JsonSerializer.Deserialize<List<Course>>(coursesJson)!;
        }
    }

    public IResult<List<Course>> GetAll()
    {
        return Result<List<Course>>.Success(Courses);
    }

    public IResult<Course> GetSingleOrDefault(Func<Course, bool> expression)
    {
        var course = Courses.SingleOrDefault(expression);
        
        if(course is null) return Result<Course>.Fail("Course not found");
        return Result<Course>.Success(course);
    }

    public IResult<IReadOnlyList<Course>> GetFilteredCourses(Func<Course, bool> expression)
    {
        var filteredCourses = Courses.Where(expression).ToList();
        return Result<IReadOnlyList<Course>>.Success(filteredCourses);
    }

    public IResult<Course> GetById(string id)
    {
        var course = Courses.SingleOrDefault(c => c.Id == id);
        if(course == null) return Result<Course>.Fail("Course not found.");
        return Result<Course>.Success(course);
    }
}