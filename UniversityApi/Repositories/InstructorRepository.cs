using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class InstructorRepository : IInstructor
    {
        private readonly 
        public InstructorRepository() { 
        }
        // Implement your code here  
        public bool AddInstructor(Instructor instructor)
        {
            var instructor = 
        }

        public IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instructor> GetInstructorsWithMostEnrollments()
        {
            throw new NotImplementedException();
        }
    }
}
