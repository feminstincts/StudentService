using System.Collections.Generic;
using StudentService.Models;

namespace StudentService.Services
{
    public interface IStudentService 
    {
        void CreateStudent(Student student);
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int id);
        IEnumerable<Student> FindStudents(string keyword);
    }
}