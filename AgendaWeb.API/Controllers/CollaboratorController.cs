using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.UseCases.General.Collaborators.GetAllCollaboratorWithFullInfo;
using AgendaWeb.UseCases.General.Collaborators.GetCollaboratorWithFullInfo;
using AgendaWeb.UseCases.General.Collaborators.GetPaginatedCollaboratorInfo;
using AgendaWeb.UseCases.General.Collaborators.SaveCollaborator;
using AgendaWeb.UseCases.General.Collaborators.DeleteCollaborator;
using AgendaWeb.UseCases.General.Collaborators.UpdateCollaborator;

namespace AgendaWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class CollaboratorController : Controller
    {
        private readonly IUseCaseFactory usecaseFactory;

        public CollaboratorController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("findall")]
        public async Task<IActionResult> GetCollaboratorsWithFullInfo()
        {
            try
            {
                var findAllCollaboratorsWithFullInfo = this.usecaseFactory.Create<GetAllCollaboratorWithFullInfoUseCase>();
                var result = await findAllCollaboratorsWithFullInfo.Execute();
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

                var findCollaboratorWithFullInfo = this.usecaseFactory.Create<GetCollaboratorWithFullInfoUseCase>();
                findCollaboratorWithFullInfo.Id = id;
                var result = await findCollaboratorWithFullInfo.Execute();
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
        public async Task<IActionResult> Post([FromBody] CollaboratorSaveDTO collaborator)
        {
            try
            {
                if (collaborator == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveCollaborator = this.usecaseFactory.Create<SaveCollaboratorUseCase>();
                    saveCollaborator.DTO = collaborator;
                    var result = await saveCollaborator.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
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
                var deleteCollaborator = usecaseFactory.Create<DeleteCollaboratorUseCase>();
                deleteCollaborator.Id = id;
                await deleteCollaborator.Execute();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CollaboratorUpdateDTO collaborator)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if (collaborator == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateCollaborator = this.usecaseFactory.Create<UpdateCollaboratorUseCase>();
                    updateCollaborator.DTO = collaborator;
                    updateCollaborator.Id = id;
                    var result = await updateCollaborator.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("findall/pageIndex/{pageIndex}/pageSize/{pageSize}")]
        public async Task<IActionResult> GetCollaboratorPagination(int pageIndex, int pageSize)
        {
            try
            {
                var findPaginatedCollaborator = this.usecaseFactory.Create<GetPaginatedCollaboratorInfoUseCase>();
                findPaginatedCollaborator.PageIndex = pageIndex;
                findPaginatedCollaborator.PageSize = pageSize;
                var result = await findPaginatedCollaborator.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
