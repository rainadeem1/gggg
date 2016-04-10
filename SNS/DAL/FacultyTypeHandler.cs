using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class FacultyTypeHandler
    {
        

        public static void Save(FacultyType des) {
            try
            {
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {
                    db.FacultyTypes.Add(des);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Shared.Message = "Some Error in faculty type Like "+ex.Message; }
        }

        public static List<FacultyType> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.FacultyTypes.ToList();
            }
        }

        public static void InitializeType(string Title, int id)
        {
            var dt = FacultyTypeHandler.Title(Title);
            if (dt == null)
            {
                FacultyType ft = new FacultyType();
                ft.Id = id;
                ft.Title = Title;
                Save(ft);
            }
        }

        public static FacultyType ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.FacultyTypes.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public static FacultyType Title(string Title)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.FacultyTypes.Where(m => m.Title == Title).FirstOrDefault();
            }
        }

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.FacultyTypes.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.FacultyTypes.Remove(dt);
                    db.SaveChanges();
                    Shared.Message =dt.Title+ " Deleted";
                }
            }
        }

        //public static void Update(int id,FacultyType des)
        //{
        //    using (CourseMetarialEntities db = new CourseMetarialEntities())
        //    {
        //        var dt = db.FacultyTypes.Where(m => m.Id == id).FirstOrDefault();
        //        if (dt != null)
        //        {
        //            dt.Title = des.Title;
        //            dt.Description = des.Description;
        //            db.SaveChanges();
        //            Shared.Message = dt.Title + " Updated";
        //        }
        //    }
        //}
    }
}