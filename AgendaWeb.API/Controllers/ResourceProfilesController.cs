using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.UseCases.General.ResourceProfiles.GetAllResourceProfile;
using AgendaWeb.UseCases.General.ResourceProfiles.GetResourceProfile;
using AgendaWeb.UseCases.General.ResourceProfiles.SaveResourceProfile;
using AgendaWeb.UseCases.General.ResourceProfiles.UpdateResourceProfile;
using AgendaWeb.UseCases.General.ResourceProfiles.DeleteResourceProfile;
using AgendaWeb.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaWeb.API.Controllers
{
    [Route("api/ResourceProfiles")]
    public class ResourceProfilesController : Controller
    {
        private readonly IUseCaseFactory usecaseFactory;

        public ResourceProfilesController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("findall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var findAllResourceProfile = this.usecaseFactory.Create<GetAllResourceProfileUseCase>();
                var result = await findAllResourceProfile.Execute();
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

                var findResoruceProfile = this.usecaseFactory.Create<GetResourceProfileUseCase>();
                findResoruceProfile.Id = id;
                var result = await findResoruceProfile.Execute();
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
        public async Task<IActionResult> Post([FromBody] ResourceProfileDTO resourceProfile)
        {
            try
            {
                if (resourceProfile == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveResourceProfile = this.usecaseFactory.Create<SaveResourceProfileUseCase>();
                    saveResourceProfile.DTO = resourceProfile;
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
        public async Task<IActionResult> Put(int id, [FromBody]ResourceProfileDTO resourceProfile)
        {
            try
            {
                if (id < 1)
                {
                    return NotFound();
                }
                if (resourceProfile == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateResourceProfile = this.usecaseFactory.Create<UpdateResourceProfileUseCase>();
                    updateResourceProfile.DTO = resourceProfile;
                    var result = await updateResourceProfile.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return NotFound();
                }
                var deleteResourceProfile = usecaseFactory.Create<DeleteResourceProfileUseCase>();
                deleteResourceProfile.Id = id;
                var result = await deleteResourceProfile.Execute();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
