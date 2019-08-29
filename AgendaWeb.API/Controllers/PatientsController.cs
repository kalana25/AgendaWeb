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

    }
}
