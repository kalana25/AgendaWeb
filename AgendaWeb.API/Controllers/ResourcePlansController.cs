using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.UseCases.DTO;
using Microsoft.AspNetCore.Mvc;
using AgendaWeb.UseCases.General.ResourcePlans.GetAllResourcePlansWithProfiles;

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
    }
}
