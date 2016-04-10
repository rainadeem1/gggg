using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class UserHandler
    {
        

        public static int Save(CourseMetarialEntities db, User Us)
        {
            try
            {
                db.Users.Add(Us);
                db.SaveChanges();
                return Us.Id;
            }
            catch (Exception ex) { Shared.Message = "Some Error Like " + ex.Message; return 0; }
        }

        public static  List<User> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Users.ToList();
            }
        }
        public static List<User> Type(string type)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Users.Where(m=>m.Type==type) .ToList();
            }
        }

        public static User ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Users.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public static User Email(string email)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Users.Where(m => m.Email == email).FirstOrDefault();
            }
        }

        public static User PersonID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Users.Where(m => m.PersonID == id).FirstOrDefault();
            }
        }

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.Users.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Users.Remove(dt);
                    db.SaveChanges();
                   // Shared.Message =dt.Name + " Deleted";
                }
            }
        }

        public static void Update(int id,User Us)
        {
            
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Users.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    dt.Email = Us.Email;
                    dt.Password = Us.Password;
                    db.SaveChanges();
                   // Shared.Message = dt.Name + " Updated";
                }
            }
        }
    }
}