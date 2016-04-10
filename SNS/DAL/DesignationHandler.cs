using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class DesignationHandler
    {
        public static void Save(Designation des) {
            try
            {
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {
                    db.Designations.Add(des);
                    db.SaveChanges();
                    Shared.Message = des.Title + " Saved";
                }
            }
            catch (Exception ex) { Shared.Message = "Some Error Like "+ex.Message; }
        }

        public static List<Designation> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Designations.ToList();
            }
        }

        public static Designation ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Designations.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.Designations.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Designations.Remove(dt);
                    db.SaveChanges();
                    Shared.Message =dt.Title+ " Deleted";
                }
            }
        }

        public static void Update(int id,Designation des)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Designations.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    dt.Title = des.Title;
                    dt.Description = des.Description;
                    db.SaveChanges();
                    Shared.Message = dt.Title + " Updated";
                }
            }
        }
    }
}