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
}