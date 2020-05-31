using System;
using System.Collections.Generic;
using System.Linq;
using StudentService.Models;

namespace StudentService.Data
{
    public class InMemoryStudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        public InMemoryStudentRepo(StudentContext context)
        {
            _context = context;
        }
        public void CreateStudent(Student student)
        {
            if(student == null){
                throw new ArgumentNullException(nameof(student));
            }
            _context.Students.Add(student);
            SaveChanges();
        }
        
        public IEnumerable<Student> FindStudents(string keyword)
        {
            return GetAllStudent().Where(x => 
                x.FirstName.Contains(keyword) || 
                x.LastName.Contains(keyword) || 
                x.MatricNumber.Contains(keyword) || 
                x.Year.ToString().Contains(keyword) ||
                x.Program.Contains(keyword) ||
                x.EntryDate.ToString().Contains(keyword)
            );
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}