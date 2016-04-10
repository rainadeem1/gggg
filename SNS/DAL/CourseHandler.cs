using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class CourseHandler
    {
        
        public static void Save(Cours cou) {
            try
            {
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {
                   
                    db.Courses.Add(cou);
                    db.SaveChanges();
                    Shared.Message = cou.Name + " Saved";
                }
            }
            catch (Exception ex) { Shared.Message = "Some Error Like "+ex.Message; }
        }

        public static List<Cours> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Courses.ToList();
            }
        }

        public static Cours ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Courses.Where(m => m.Id == id).FirstOrDefault();
            }
        }


        public static Cours Code(string code)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Courses.Where(m => m.Code == code).FirstOrDefault();
            }
        }

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.Courses.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Courses.Remove(dt);
                    db.SaveChanges();
                    Shared.Message =dt.Name + " Deleted";
                }
            }
        }

        public static void Update(int id,Cours cou)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Courses.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    dt.Name = cou.Name;
                    dt.Code = cou.Code;
                    db.SaveChanges();
                    Shared.Message = dt.Name + " Updated";
                }
            }
        }
    }
}