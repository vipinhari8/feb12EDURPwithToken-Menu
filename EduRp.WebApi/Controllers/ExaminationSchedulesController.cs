using EduRp.Data;
using EduRp.Service.IService;
using EduRp.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EduRp.WebApi.Controllers
{
    public class ExaminationSchedulesController : ApiController
    {
        private IExaminationScheduleService examinationschedulesService = new ExaminationScheduleService();

        public IHttpActionResult GetExaminationDetail(int? id, int? userid, string tokenid, int? examinationtypeid)
        {
            return Ok(new
            {
                results = examinationschedulesService.GetExaminationDetail(id, userid, tokenid, examinationtypeid).ToList()
            });
        }
        public IHttpActionResult GetExaminationSchedule(int? id, int? userid, string tokenid, int? batchid, int? psid, int? courseid, int? examinationtypeid)
        {
            return Ok(new
            {
                results = examinationschedulesService.GetExaminationSchedule(id, userid, tokenid,batchid,psid,courseid, examinationtypeid).ToList()
            });
        }
        public IHttpActionResult GetStudentExamScheduleByAdminNo(int? id, int? userid, string tokenid, string admissionnumber)
        {
            return Ok(new
            {
                results = examinationschedulesService.GetStudentExamScheduleByAdminNo(id, userid, tokenid, admissionnumber).ToList()
            });
        }
        public IHttpActionResult UpdateExaminationSchedule(GetExaminationSchedule_Result getExaminationSchedule)
        {
            var isUpdate = examinationschedulesService.UpdateExaminationSchedule(getExaminationSchedule.UniversityId, getExaminationSchedule);
            if (isUpdate == true)
                return Ok();

            return BadRequest();
        }
    }
}
