//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EduRp.Data
{
    using EduRp.Data.Core.Foundation;
    using System;
    using System.Collections.Generic;
    
    public partial class ExaminationSchedule : BaseEntity
    {
        public int ExaminationScheduleId { get; set; }
        public Nullable<int> ExaminationTypeId { get; set; }
        public Nullable<System.DateTime> ExaminationDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<System.DateTime> GenerateHallTicketDate { get; set; }
        public Nullable<int> UniversityId { get; set; }
        public Nullable<byte> Active { get; set; }
        public Nullable<System.DateTime> lastupdateddt { get; set; }
        public Nullable<int> lastupdatedby { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> ProgramStudyId { get; set; }
        public Nullable<int> CourseId { get; set; }
    }
}
