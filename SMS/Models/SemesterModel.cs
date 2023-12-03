using System.ComponentModel.DataAnnotations;
using Entities;
using Sercvices.Interfaces;

namespace Models;

public class SemesterModel
{
    [RegularExpression("/^.*$", ErrorMessage = "Invalid format of Semester Code")]
    public string SemesterCode { get; set; } = String.Empty;
    public string Year { get; set; } = String.Empty;
    public int NumberOfCredits { get; set; }
    public List<SemesterCourse>? Courses { get; set; } = new();

    private readonly ISemesterService? _semesterService;

    public SemesterModel()
    {
    }

    public SemesterModel(ISemesterService semesterService)
    {   
        _semesterService = semesterService;
    }

    public void CreateSemester()
    {
        _semesterService!.CreateSemester(this);
    }

    public IReadOnlyList<SemesterModel> GetAllSemesters()
    {
        var semestersEO = _semesterService!.GetAllSemesters();
        var semesters = new List<SemesterModel>();

        foreach(var semesterEO in semestersEO)
        {
            semesters.Add(new()
            {
                SemesterCode = semesterEO.SemesterCode,
                Year = semesterEO.Year,
                NumberOfCredits = semesterEO.NumberOfCredits,
                Courses = semesterEO.Courses
            });
        }
        
        return semesters.AsReadOnly();
    }

    public SemesterModel GetById(string semesterCode)
    {
        var semesterEO = _semesterService!.GetById(semesterCode);

        return new()
            {
                SemesterCode = semesterEO.SemesterCode,
                Year = semesterEO.Year,
                NumberOfCredits = semesterEO.NumberOfCredits,
                Courses = semesterEO.Courses
            };
    }
}