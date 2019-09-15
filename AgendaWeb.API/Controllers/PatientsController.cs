using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.UseCases.General.Patients.GetAllPatientWithFullInfo;
using AgendaWeb.UseCases.General.Patients.GetPatientWithFullInfo;
using AgendaWeb.UseCases.General.Patients.SavePatient;
using AgendaWeb.UseCases.General.Patients.DeletePatient;
using AgendaWeb.UseCases.General.Patients.UpdatePatient;
using AgendaWeb.UseCases.General.Patients.GetPaginatedPatientInfo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        private readonly IUseCaseFactory usecaseFactory;

        public PatientsController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("findall")]
        public async Task<IActionResult> GetPatientsWithFullInfo()
        {
            try
            {
                var findAllPatientWithFullInfo = this.usecaseFactory.Create<GetAllPatientWithFullInfoUseCase>();
                var result = await findAllPatientWithFullInfo.Execute();
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

                var findPatientWithFullInfo = this.usecaseFactory.Create<GetPatientWithFullInfoUseCase>();
                findPatientWithFullInfo.Id = id;
                var result = await findPatientWithFullInfo.Execute();
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
        public async Task<IActionResult> Post([FromBody] PatientSaveDTO patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var savePatient = this.usecaseFactory.Create<SavePatientUseCase>();
                    savePatient.DTO = patient;
                    var result = await savePatient.Execute();
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
                var deletePatient = usecaseFactory.Create<DeletePatientUseCase>();
                deletePatient.Id = id;
                await deletePatient.Execute();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PatientUpdateDTO patient)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if (patient == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updatePatient = this.usecaseFactory.Create<UpdatePatientUseCase>();
                    updatePatient.DTO = patient;
                    updatePatient.Id = id;
                    var result = await updatePatient.Execute();
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
        public async Task<IActionResult> GetPatientPagination(int pageIndex,int pageSize)
        {
            try
            {
                var findPaginatedPatient = this.usecaseFactory.Create<GetPaginatedPatientInfoUseCase>();
                findPaginatedPatient.PageIndex = pageIndex;
                findPaginatedPatient.PageSize = pageSize;
                var result = await findPaginatedPatient.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
