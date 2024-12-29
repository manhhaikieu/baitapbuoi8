using DAL.Models;
//using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.BUS
{
    public class StudentService
    {
        public List<Student> getAllStudent()
        {
            Model2 studentModel = new Model2();
            return studentModel.Students.ToList();
        }
        public Student findStudent(string studentId)
        {
            Model2 studentModel = new Model2();
            return studentModel.Students.FirstOrDefault(p => p.StudentID == studentId);
        }
        public string findImageStudent(string studentId)
        {
            Model2 studentModel = new Model2();
            Student stu = studentModel.Students.FirstOrDefault(p => p.StudentID == studentId);
            if (stu != null)
            {
                return stu.Avatar;
            }
            return null;
        }
        public List<Student> GetStudentByFacultyIDAndNoMajor(int facultyId)
        {
            Model2 studentModel = new Model2();
            return studentModel.Students.Where(p => p.MajorID == null && p.FacultyID == facultyId).ToList();
        }
        public List<Student> GetAllHashNoMajor()
        {
            Model2 studentModel = new Model2();
            return studentModel.Students.Where(p => p.MajorID == null).ToList();
        }
        public void InsertStudent(Student stu)
        {
            Model2 studentModel = new Model2();
            studentModel.Students.AddOrUpdate(stu);
            studentModel.SaveChanges();
        }
        public List<Student> getAllStudentsByFacultyID(int facultyId)
        {
            using (Model2 studentModel = new Model2())
            {
                return studentModel.Students
                    .Where(m => m.FacultyID == facultyId)
                    .ToList();
            }
        }
        public int TotalStudent(List<Student> lstStudents)
        {
            return lstStudents.Count;
        }
        public void DeleteStudent(string studentId)
        {
            Model2 studentModel = new Model2();
            Student student = studentModel.Students.FirstOrDefault(p => p.StudentID == studentId);
            studentModel.Students.Remove(student);
            studentModel.SaveChanges();
        }
    }
}
