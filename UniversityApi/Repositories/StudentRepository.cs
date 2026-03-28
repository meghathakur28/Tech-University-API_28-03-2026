using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly UniversityContext _context;
        public StudentRepository(UniversityContext context)
        {
            _context = context;
        }
        // Implement your code here  
        public bool DeleteStudent(int studentId)
        {
            var delStud = _context.Students.FirstOrDefault(x => x.StudentId == studentId);
            if (delStud == null)
            {
                return false;
            }
            _context.Students.Remove(delStud);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Student> GetStudentsByCourseTitle(string courseTitle)
        {
            var stcour = _context.Students.Where(x => x.Enrollments.Any(x => x.Course.Title == courseTitle)).ToList();
            return stcour;
        }
    }
}
