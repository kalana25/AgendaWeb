using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.UseCases.General.Styles.GetCustomStyles;
using AgendaWeb.UseCases.General.Styles.GetAllStyle;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaWeb.API.Controllers
{
    [Route("api/Styles")]
    public class StylesController : Controller
    {
        private readonly IUseCaseFactory usecaseFactory;

        public StylesController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("custome/{customeStyle}")]
        public async Task<IActionResult> GetCustomeStyles(bool customeStyle)
        {
            try
            {
                var findAllCustomeStyles = this.usecaseFactory.Create<GetCustomStylesUseCase>();
                findAllCustomeStyles.CustomStyle = customeStyle;
                var result = await findAllCustomeStyles.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/<controller>
        [HttpGet("findall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var findAllStyles = this.usecaseFactory.Create<GetAllStyleUseCase>();
                var result = await findAllStyles.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
