using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class InstructorRepository : IInstructor
    {
        private readonly UniversityContext _context;
        public InstructorRepository(UniversityContext context) {
            _context = context;
        }
        // Implement your code here  
        public bool AddInstructor(Instructor instructor)
        {
            var instruct = _context.Instructors.FirstOrDefault(x=>x.InstructorId == instructor.InstructorId);
            if (instruct == null)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count)
        {
            var instructorcount = _context.Instructors.Where(x => x.InstructorCourses.Count > count).ToList();
            return instructorcount;
        }

        public IEnumerable<Instructor> GetInstructorsWithMostEnrollments()
        {
            var topInstructors = _context.Instructors
                                  .Select(i => new
                                  {
                                  Instructor = i,
        EnrollmentCount = i.InstructorCourses
            .SelectMany(ic => ic.Course.Enrollments)
            .Count()
    })
    .Where(x => x.EnrollmentCount ==
        _context.Instructors
            .Select(i => i.InstructorCourses
                .SelectMany(ic => ic.Course.Enrollments)
                .Count())
            .Max())
    .Select(x => x.Instructor)
    .ToList();
            return topInstructors;
        }
    }
}
