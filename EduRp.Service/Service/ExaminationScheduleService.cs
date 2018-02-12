using EduRp.Data;
using EduRp.Service.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduRp.Service.Service
{
    public class ExaminationScheduleService : IExaminationScheduleService
    {
        private edurp_devEntities db = new edurp_devEntities();

        public List<GetExaminationDetail_Result> GetExaminationDetail(int? id,int? userid,string tokenid,int? examinationtypeid)
        {
            return db.GetExaminationDetail(id,userid,tokenid, examinationtypeid).ToList();
        }

        public List<GetExaminationSchedule_Result> GetExaminationSchedule(int? id, int? userid, string tokenid,int? batchid,int? psid,int? courseid,int? examinationtypeid)
        {
            return db.GetExaminationSchedule(id, userid, tokenid, batchid, psid, courseid, examinationtypeid).ToList();
        }
        public List<GetStudentExamScheduleByAdminNo_Result> GetStudentExamScheduleByAdminNo(int? id, int? userid, string tokenid, string admissionnumber)
        {
            return db.GetStudentExamScheduleByAdminNo(id, userid, tokenid, admissionnumber).ToList();
        }

        public bool UpdateExaminationSchedule(int? id , GetExaminationSchedule_Result getExaminationSchedule)
        {
            try
            {
                var obj = JsonConvert.SerializeObject
                 (new GetExaminationSchedule_Result
                 {
                     ExamName = getExaminationSchedule.ExamName,
                     ExamGroup = getExaminationSchedule.ExamGroup,
                     ExaminationTypeId = getExaminationSchedule.ExaminationTypeId,
                     ExaminationScheduleId = getExaminationSchedule.ExaminationScheduleId,
                     ExaminationDate = getExaminationSchedule.ExaminationDate,
                     StartTime = getExaminationSchedule.StartTime,
                     UniversityId = getExaminationSchedule.UniversityId,
                     UserId = getExaminationSchedule.UserId,
                     TokenId = getExaminationSchedule.TokenId,

                 });


                var ExamSchObj = obj.ToString();

                var JsonObj = db.UpdateExaminationSchedule(id, ExamSchObj);

                return true;
                //db.ClassRoomMasters.Add(getExaminationSchedule);
                //db.SaveChanges();
                //return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("NotImplementedException", ex);
                return false;
            }

        }

        //public bool UpdateExaminationScheduleDetail(int? id, GetExaminationDetail getExaminationDetail)
        //{
            
        //}

        public bool UpdateExaminationStudent()
        {
            throw new NotImplementedException();
        }
        //public List<GetExamScheduleClassRoom_Result> GetExamScheduleClassRoom(int? id, int? userid, string tokenid)
        //{
        //    return db.GetExamScheduleClassRoom(id, userid, tokenid, batchid, psid, courseid, examinationtypeid).ToList();
        //}

        //public List<GetExamScheduleStaff_Result> GetExamScheduleStaff(int? id, int? userid, string tokenid)
        //{
        //    return db.GetExamScheduleStaff(id, userid, tokenid, batchid, psid, courseid, examinationtypeid).ToList();
        //}
    }
}