using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.UseCases.DTO;
using Microsoft.AspNetCore.Mvc;
using AgendaWeb.UseCases.General.ResourcePlans.GetAllResourcePlansWithProfiles;
using AgendaWeb.UseCases.General.ResourcePlans.SaveResourcePlan;
using AgendaWeb.UseCases.General.ResourcePlans.GetResourcePlanWithProfiles;
using AgendaWeb.UseCases.General.ResourcePlans.UpdateResourcePlan;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaWeb.API.Controllers
{
    [Route("api/ResourcePlans")]
    public class ResourcePlansController : Controller
    {
        private readonly IUseCaseFactory usecaseFactory;

        public ResourcePlansController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("findall")]
        public async Task<IActionResult> GetPlansWithProfiles()
        {
            try
            {
                var findAllPlansWithProfiles = this.usecaseFactory.Create<GetAllResourcePlansWithProfileUseCase>();
                var result = await findAllPlansWithProfiles.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findResourcePlan = this.usecaseFactory.Create<GetResourcePlanWithProfileUseCase>();
                findResourcePlan.Id = id;
                var result = await findResourcePlan.Execute();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResourcePlanSaveDTO resourcePlan)
        {
            try
            {
                if (resourcePlan == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveResourceProfile = this.usecaseFactory.Create<SaveResourcePlanUseCase>();
                    saveResourceProfile.DTO = resourcePlan;
                    var result = await saveResourceProfile.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] ResourcePlanUpdateDTO resourcePlan)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if(resourcePlan == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateResourcePlan = this.usecaseFactory.Create<UpdateResourcePlanUseCase>();
                    updateResourcePlan.DTO = resourcePlan;
                    var result = await updateResourcePlan.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
