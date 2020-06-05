using System.Collections.Generic;
using System.Linq;
using StudentService.Data;
using StudentService.Models;

namespace StudentService.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _repository;
        public StudentService(IStudentRepo repository)
        {
            _repository = repository;
        }

        public void CreateStudent(Student student)
        {
            _repository.CreateStudent(student);
        }

        public IEnumerable<Student> FindStudents(string keyword)
        {
            keyword = keyword.ToLower();
            return _repository.ReadAllStudent().Where(x => 
                x.FirstName.ToLower().Contains(keyword) || 
                x.LastName.ToLower().Contains(keyword) || 
                x.MatricNumber.ToLower().Contains(keyword) || 
                x.Year.ToString().ToLower().Contains(keyword) ||
                x.Program.ToLower().Contains(keyword) ||
                x.EntryDate.ToString().ToLower().Contains(keyword)
            );
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _repository.ReadAllStudent();
        }

        public Student GetStudentById(int id)
        {
            return _repository.ReadStudentById(id);
        }
    }
}