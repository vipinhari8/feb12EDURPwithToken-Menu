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
    using System;
    
    public partial class GetBulkData_Result
    {
        public int BulkLoadRequestId { get; set; }
        public int UnivesityId { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public bool FileUploadtoFolderStatus { get; set; }
        public bool FileUploadtoDBStatus { get; set; }
        public System.DateTime FileUploadedtoFolderOn { get; set; }
        public Nullable<System.DateTime> FileUploadedtoDBOn { get; set; }
    }
}
