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
    using EduRp.Data.Core;
    using System;
    
    public partial class GetExaminationSchedule_Result:Entity
    {
        public int ExaminationTypeId { get; set; }
        public string ExamGroup { get; set; }
        public string ExamName { get; set; }
        public int ExaminationScheduleId { get; set; }
        public Nullable<System.DateTime> ExaminationDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
    }
}
