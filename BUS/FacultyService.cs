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
    public class FacultyService
    {
        public List<Faculty> getAllFaculty()
        {
            Model2 studentModel = new Model2();
            return studentModel.Faculties.ToList();
        }
        public Faculty findFaculty(int id)
        {
            Model2 studentModel = new Model2();
            return studentModel.Faculties.FirstOrDefault(p => p.FacultyID == id);
        }
        public void insertFaculty(Faculty facItem)
        {
            Model2 studentModel = new Model2();
            studentModel.Faculties.AddOrUpdate(facItem);
            studentModel.SaveChanges();
        }
        public void updateFaculty(Faculty facItem)
        {
            Model2 studentModel = new Model2();
            studentModel.Faculties.AddOrUpdate(facItem);
            studentModel.SaveChanges();
        }
        public void deleteFaculty(int facID)
        {
            Model2 studentModel = new Model2();
            Faculty item = studentModel.Faculties.FirstOrDefault(p => p.FacultyID == facID);
            studentModel.Faculties.Remove(item);
            studentModel.SaveChanges();
        }
    }
}