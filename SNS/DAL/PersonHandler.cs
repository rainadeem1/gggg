using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class PersonHandler
    {
        
        public static int Save(CourseMetarialEntities db,Person per) {
                db.Persons.Add(per);
                db.SaveChanges();
                return per.Id;
        }

        public static List<Person> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Persons.ToList();
            }
        }

        public static Person ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Persons.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public static List< Person> Type(string type)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Persons.Where(m => m.PersonType == type).ToList();
            }
        }

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.Persons.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Persons.Remove(dt);
                    db.SaveChanges();
                    Shared.Message =dt.FirstName+ " Deleted";
                }
            }
        }

        public static void Update(int id,Person per)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Persons.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    dt.FirstName = per.FirstName;
                    dt.LastName = per.LastName;
                    dt.Phone = per.Phone;
                    dt.Address = per.Address;
                    if (!string.IsNullOrEmpty(per.Picture))
                    {
                        dt.Picture = per.Picture;
                    }
                   
                   
                    db.SaveChanges();
                    Shared.Message = dt.FirstName + " Updated";
                }
            }
        }
    }
}