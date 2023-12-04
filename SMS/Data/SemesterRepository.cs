using System.Text.Json;
using Data.Interfaces;
using Entities;
using Utility;

namespace Data;

public class SemesterRepository : IRepository
{
    public List<Semester> Semesters { get; private set; }
    public bool IsPristine { get; set; } = true;

    public SemesterRepository(List<Semester> semesters)
    {
        Semesters = semesters;
    }

    public void LoadValues(string filePath)
    {
        if(File.Exists(filePath))
        {
            var semestersJson = File.ReadAllText(filePath);

            if (!string.IsNullOrWhiteSpace(semestersJson)) 
                Semesters = JsonSerializer.Deserialize<List<Semester>>(semestersJson)!;
        }
    }

    public IResult Add(Semester semester)
    {
        Semesters.Add(semester);
        IsPristine = false;

        return Result<Semester>.Success();
    }
}