//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace PWS_6
{
    public class WcfDataService1 : EntityFrameworkDataService<pws_lab6Entities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [WebGet]
        public IQueryable<Student> InsertStudent(String name)
        {
            Student student = new Student();
            student.Name = name;
            pws_lab6Entities context = this.CurrentDataSource;
            context.Student.Add(student);
            context.SaveChanges();
            return context.Student;
        }

        [WebGet]
        public IQueryable<Note> InsertNote(String subject, int note1, int studentId)
        {
            Note note = new Note();
            note.Subj = subject;
            note.StudentId = studentId;
            note.NoteValue = note1;
            pws_lab6Entities context = this.CurrentDataSource;
            context.Note.Add(note);
            context.SaveChanges();
            return context.Note;
        }

        [WebGet]
        public IQueryable<Student> ChangeStudent(int id, String name)
        {
            pws_lab6Entities context = this.CurrentDataSource;
            Student student = context.Student.Find(id);
            student.Name = name;
            context.SaveChanges();
            return context.Student;
        }

        [WebGet]
        public IQueryable<Note> ChangeNote(int id, String subject, int note1, int studentId)
        {
            pws_lab6Entities context = this.CurrentDataSource;
            Note note = context.Note.Find(id);
            note.Subj = subject;
            note.StudentId = studentId;
            note.NoteValue = note1;
            context.SaveChanges();
            return context.Note;
        }
    }
}
