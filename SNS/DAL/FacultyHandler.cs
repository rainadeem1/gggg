using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class FacultyHandler
    {

        public static int Save(CourseMetarialEntities db, Faculty per)
        {
            try
            {
                db.Faculties.Add(per);
                db.SaveChanges();
                return per.Id;
            }
            catch (Exception ex) { Shared.Message = "Some Error Like " + ex.Message; return 0; }
        }

        public static List<Faculty> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                
                return (from a in db.Faculties
                        .Include("Person")
                        .Include("Designation")
                        select a).ToList();
            }
        }

        public static List<Faculty> FacultyTitle(string title)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {

                return (from a in db.Faculties
                        .Include("Person")
                        .Include("Designation")
                        where a.FacultyType.Title == title
                        select a).ToList();
            }
        }

        public static Faculty ID(int id)
        {
            
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Faculties.Include("Person").Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.Faculties.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Faculties.Remove(dt);
                    db.SaveChanges();
                   // Shared.Message =dt.Name + " Deleted";
                }
            }
        }

        public static void Update(int id,Faculty fac)
        {
            
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Faculties.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    dt.DesignationID = fac.DesignationID;
                    dt.TypeID = fac.TypeID;   
                    db.SaveChanges();
                   // Shared.Message = dt.Name + " Updated";
                }
            }
        }
    }
}