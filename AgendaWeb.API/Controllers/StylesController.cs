using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.UseCases.General.Styles.GetCustomStyles;
using AgendaWeb.UseCases.General.Styles.GetAllStyle;
using AgendaWeb.UseCases.General.Styles.GetStyle;
using AgendaWeb.UseCases.General.Styles.SaveStyle;
using AgendaWeb.UseCases.General.Styles.UpdateStyle;
using AgendaWeb.UseCases.General.Styles.DeleteStyle;
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

        [HttpGet("find/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findStyle = this.usecaseFactory.Create<GetStyleUseCase>();
                findStyle.Id = id;
                var result = await findStyle.Execute();
                if(result == null)
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
        public async Task<IActionResult> Post([FromBody] StyleDTO style)
        {
            try
            {
                if(style == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveStyle = this.usecaseFactory.Create<SaveStyleUseCase>();
                    saveStyle.DTO = style;
                    var result = await saveStyle.Execute();
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
        public async Task<IActionResult> Put(int id, [FromBody]StyleDTO style)
        {
            try
            {
                if(id<1)
                {
                    return NotFound();
                }
                if(style == null)
                {
                    return BadRequest();
                }
                if(ModelState.IsValid)
                {
                    var updateStyle = this.usecaseFactory.Create<UpdateStyleUseCase>();
                    updateStyle.DTO = style;
                    var result = await updateStyle.Execute();
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
                var deleteStyle = usecaseFactory.Create<DeleteStyleUseCase>();
                deleteStyle.Id = id;
                var result = await deleteStyle.Execute();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
