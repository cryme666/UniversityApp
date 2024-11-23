using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;
using UniversityApp.Models;
public class UniversityHub : Hub
{
    private readonly UniversityContext _context;

    public UniversityHub(UniversityContext context)
    {
        _context = context;
    }

    public async Task SendLecturers()
    {
        var lecturers = _context.Lecturer.ToList();
        await Clients.All.SendAsync("ReceiveLecturers", lecturers);
    }

    public async Task AddLecturer(Lecturer lecturer)
    {
        _context.Lecturer.Add(lecturer);
        await _context.SaveChangesAsync();
        await SendLecturers();
    }

    public async Task EditLecturer(Lecturer lecturer)
    {
        
        _context.Lecturer.Update(lecturer);
        await _context.SaveChangesAsync();
        await SendLecturers();
    }

    public async Task DeleteLecturer(int lecturerId)
    {
        var lecturer = _context.Lecturer.FirstOrDefault(l => l.LecturerID == lecturerId);
        if (lecturer != null)
        {
            _context.Lecturer.Remove(lecturer);
            await _context.SaveChangesAsync();
            await SendLecturers();
        }
    }

    public async Task SendSubjects()
{
    var subjects = _context.Subject.ToList();
    await Clients.All.SendAsync("ReceiveSubjects", subjects);
}

public async Task AddSubject(Subject subject)
{
    _context.Subject.Add(subject);
    await _context.SaveChangesAsync();
    await SendSubjects();
}

public async Task EditSubject(Subject subject)
{
    _context.Subject.Update(subject);
    await _context.SaveChangesAsync();
    await SendSubjects();
}

public async Task DeleteSubject(int subjectId)
{
    var subject = _context.Subject.FirstOrDefault(s => s.SubjectID == subjectId);
    if (subject != null)
    {
        _context.Subject.Remove(subject);
        await _context.SaveChangesAsync();
        await SendSubjects();
    }
}
 public async Task SendPositions()
    {
        var positions = _context.Position.ToList();
        await Clients.All.SendAsync("ReceivePositions", positions);
    }

    public async Task AddPosition(Position position)
    {
        _context.Position.Add(position);
        await _context.SaveChangesAsync();
        await SendPositions();
    }

    public async Task EditPosition(Position position)
    {
        _context.Position.Update(position);
        await _context.SaveChangesAsync();
        await SendPositions();
    }

    public async Task DeletePosition(int positionId)
    {
        var position = _context.Position.FirstOrDefault(p => p.PositionID == positionId);
        if (position != null)
        {
            _context.Position.Remove(position);
            await _context.SaveChangesAsync();
            await SendPositions();
        }
    }
}


