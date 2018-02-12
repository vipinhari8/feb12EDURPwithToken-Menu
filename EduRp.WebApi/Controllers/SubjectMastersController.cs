﻿
using EduRp.Data;
using EduRp.Service.IService;
using EduRp.Service.Service;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EduRp.WebApi.Controllers
{

    public class SubjectMastersController : ApiController
    {
        private ISubjectMasterService subjectMasterService = new SubjectMasterService();
        [HttpGet]
        public IHttpActionResult Get(int? id,int? userid,string tokenid)
        {
            return Ok(new { results = subjectMasterService.GetList(id, userid, tokenid) });
        }

        [HttpGet]
        //[Route("GetByCourse/{id:int?}/{CourseId:int?}")]
        public IHttpActionResult GetCourseSubjectList(int? id,int? userid,string tokenid, int? CourseId)
        {
            return Ok(new { results = subjectMasterService.GetByCourse(id,userid,tokenid, CourseId) });
        }

        [HttpPut]
        [HttpPost]     
        public IHttpActionResult Save(SubjectMaster subjectMaster)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isUpdate = subjectMasterService.InsUpdSubjectMaster(subjectMaster.UniversityId, subjectMaster);
            if (isUpdate == true)
                return Ok(subjectMaster);
            return BadRequest();
            
        }

        [HttpDelete]
        public IHttpActionResult Delete(SubjectMaster subjectMaster)
        {
            var isDeleted = subjectMasterService.DeleteSubjectMaster(subjectMaster.UniversityId, subjectMaster);
            if (isDeleted == true)
                return Ok();
            return BadRequest();
        }
    }
}