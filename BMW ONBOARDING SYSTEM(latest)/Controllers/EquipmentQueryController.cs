using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentQueryController : ControllerBase
    {
        private readonly IEquipmentQueryRepository _queryRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EquipmentQueryController(IEquipmentQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        ////[Authorize(Roles = Role.Admin)]
        //[HttpPost]
        //[Route("[action]/{userid}")]
        //public async Task<ActionResult<EquipementQueryViewModel>> CreateEquipmentQuery(int userid, [FromBody] EquipementQueryViewModel model)
        //{
        //    try
        //    {
        //        var query = _mapper.Map<EquipmentQuery>(model);

        //        _queryRepository.Add(query);

        //        if (await _queryRepository.SaveChangesAsync())
        //        {
        //            AuditLog auditLog = new AuditLog();
        //            auditLog.AuditLogDescription = "Created Query  with description" + ' ' + query.EquipmentQueryDescription;
        //            auditLog.AuditLogDatestamp = DateTime.Now;
        //            auditLog.UserId = userid;
        //            return Ok("Query Status Successfully created");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        BadRequest();
        //    }
        //    return BadRequest();
        //}

        //[Authorize(Roles = Role.Onboarder)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentQueryViewModelcs>> ReportEquipmentQuery(int userid,[FromBody] EquipmentQueryViewModelcs model)
        {
            try
            {
                var query = _mapper.Map<EquipmentQuery>(model);
                query.QueryStatusId = 1;

                //Eqquer
                //EquipmentQuery newQuery = new EquipmentQuery();
                //newQuery.EquipmentId = model.EquipmentId;
                //newQuery.QueryStatusId = 1;
                //newQuery.OnboarderID = Convert.ToInt32(model.OnboarderId);
                //newQuery.EquipmentQueryDescription = model.EquipmentQueryDescription;
                //newQuery.EquipmentQueryDate = DateTime.Now;
                _queryRepository.Add(query);

                if (await _queryRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception e )
            {

                BadRequest(e);
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut()]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<ResolveQueryViewModel>> ResolveQuery(int userid, ResolveQueryViewModel model)
        {
            try
            {
                var existingQuery = await _queryRepository.GetQueryByIDAsync(model.EquipmentQueryId);

                if (existingQuery == null) return NotFound($"Could Not find course with the Equipment query you are trying to Resolve");
             
                _mapper.Map(model, existingQuery);
                //change the query manually
                existingQuery.QueryStatusId = model.EquipmentQueryStatusId;
                if (await _queryRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Resolved query number" + ' ' + model.EquipmentQueryId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }   //for admin to get all queries
        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllEqipmentQueries()
        {
            try
            {
                var queries = await _queryRepository.GetAllqueriesAsync();
                return Ok(queries);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //get specific query by id
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetEquipmentQuerybyid(int id)
        {
            try
            {
                var queries = await _queryRepository.GetQueryByIDAsync(id);
                return Ok(queries);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //used to get all the queries for that onboarder
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetEquipmentQuerybyOnboarderid(int id)
        {
            try
            {
                var queries = await _queryRepository.GetQueryByOnboarderIDc(id);
                return Ok(queries);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetQueryStatus()
        {
            try
            {
                var queryStatus = await _queryRepository.GetAllQueryStatuses();
                return Ok(queryStatus);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }






        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentQueryViewModelcs>> CreateQueryStatus(int userid, [FromBody] EquipmentQueryStatusViewModel model)
        {
            try
            {
                var query = _mapper.Map<QueryStatus>(model);

                _queryRepository.Add(query);

                if (await _queryRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Query status with description" + ' ' + query.EquipmentQueryDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok();
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetQueryStatusById(int id)
        {
            try
            {
                var queryStatus = await _queryRepository.GetQueryStatusByIDAsync(id);
                return Ok(queryStatus);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetQueryById(int id)
        {
            try
            {
                var query = await _queryRepository.GetQueryByIDAsync(id);
                return Ok(query);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
