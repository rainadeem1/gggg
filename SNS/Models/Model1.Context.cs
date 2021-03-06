﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SNS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CourseMetarialEntities : DbContext
    {
        public CourseMetarialEntities()
            : base("name=CourseMetarialEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<FacultyType> FacultyTypes { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<StudentCours> StudentCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TeacherCours> TeacherCourses { get; set; }
        public virtual DbSet<UploadComment> UploadComments { get; set; }
        public virtual DbSet<UploadNotification> UploadNotifications { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<sp_comments_Result> sp_comments(Nullable<int> uploadId)
        {
            var uploadIdParameter = uploadId.HasValue ?
                new ObjectParameter("uploadId", uploadId) :
                new ObjectParameter("uploadId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_comments_Result>("sp_comments", uploadIdParameter);
        }
    
        public virtual int sp_delUplaodNotifications()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delUplaodNotifications");
        }
    
        public virtual ObjectResult<sp_FacultyMail_Result> sp_FacultyMail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_FacultyMail_Result>("sp_FacultyMail", emailParameter);
        }
    
        public virtual ObjectResult<sp_OnUploadNotifications_Result> sp_OnUploadNotifications(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_OnUploadNotifications_Result>("sp_OnUploadNotifications", studentIDParameter);
        }
    
        public virtual ObjectResult<sp_OnUploadNotifications_Course_Result> sp_OnUploadNotifications_Course(Nullable<int> courseID)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("courseID", courseID) :
                new ObjectParameter("courseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_OnUploadNotifications_Course_Result>("sp_OnUploadNotifications_Course", courseIDParameter);
        }
    
        public virtual ObjectResult<sp_studentCourses_Result> sp_studentCourses(Nullable<int> studetnID)
        {
            var studetnIDParameter = studetnID.HasValue ?
                new ObjectParameter("studetnID", studetnID) :
                new ObjectParameter("studetnID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_studentCourses_Result>("sp_studentCourses", studetnIDParameter);
        }
    
        public virtual ObjectResult<sp_StudentMail_Result> sp_StudentMail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_StudentMail_Result>("sp_StudentMail", emailParameter);
        }
    
        public virtual ObjectResult<sp_teacherCourses_Result> sp_teacherCourses(Nullable<int> teacherID)
        {
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("TeacherID", teacherID) :
                new ObjectParameter("TeacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_teacherCourses_Result>("sp_teacherCourses", teacherIDParameter);
        }
    
        public virtual ObjectResult<sp_UnApproveStudentCourses_Result> sp_UnApproveStudentCourses(Nullable<int> teacherID)
        {
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("TeacherID", teacherID) :
                new ObjectParameter("TeacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_UnApproveStudentCourses_Result>("sp_UnApproveStudentCourses", teacherIDParameter);
        }
    }
}
