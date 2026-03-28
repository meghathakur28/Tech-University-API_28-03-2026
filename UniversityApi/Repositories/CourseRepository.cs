using Microsoft.AspNetCore.Components.Forms;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class CourseRepository : ICourse
    {
        private readonly UniversityContext _context;
        public CourseRepository(UniversityContext context) { 
            _context = context;
        }
        public IEnumerable<Course> GetCoursesByInstructorName(string instructorName)
        {
            var courseInstructor = _context.Courses.Where(x => x.InstructorCourses.Any(c => c.Instructor.Name == instructorName)).ToList();
            return courseInstructor;
        }

        public IEnumerable<Course> GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            var coursesAboveGrade = _context.Courses.Where(x => x.Enrollments.Any(c=>c.Grade==grade)).ToList();
            return coursesAboveGrade;
        }

        public bool UpdateCourse(Course course)
        {
            var cour = _context.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (cour != null)
            {
                return false;
            }
            _context.Courses.Add(course);
            _context.SaveChanges();
            return true;
        }
    }
}
