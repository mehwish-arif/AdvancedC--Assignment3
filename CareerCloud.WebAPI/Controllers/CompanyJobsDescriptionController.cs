﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private CompanyJobDescriptionLogic _logic;

        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("companyjobdesc/{id}")]
        [ProducesResponseType(typeof(CompanyJobDescriptionPoco), 200)]
        public ActionResult GetCompanyJobsDescription(Guid id)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(id);

            if (poco != null)
            {
                return Ok(poco);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("companyjobdesc")]
        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyjobdesc")]
        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyjobdesc")]
        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("companyjobdesc")]
        [ProducesResponseType(typeof(List<CompanyJobDescriptionPoco>), 200)]
        public ActionResult GetAllCompanyJobDescription()
        {
            return Ok(_logic.GetAll());
        }
    }
}
