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
    
    public partial class ProgramStudyCourseAssociation : BaseEntity
    {
        public int ProgramStudyCourseId { get; set; }
        public int ProgramStudyId { get; set; }
        public int CourseId { get; set; }
        public Nullable<int> UniversityId { get; set; }
    }
}
