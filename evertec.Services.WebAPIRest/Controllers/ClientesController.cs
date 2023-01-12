using evertec.Application.DTO;
using evertec.Application.Interface;
using evertec.Services.WebAPIRest.Helpers;
using evertec.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace evertec.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesApplication _Application;
        private readonly AppSettings _appSettings;

        public ClientesController(IClientesApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<ClienteDTO>> response = new Response<IEnumerable<ClienteDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(int ID)
        {
            Response<ClienteDTO> response = new Response<ClienteDTO>();

            try
            {
                response = await _Application.GetAsync(ID);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] ClienteDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.InsertAsync(modelDto);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ClienteDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.UpdateAsync(modelDto);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpDelete("DelAsync")]
        public async Task<IActionResult> DelAsync(int ID)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response = await _Application.DeleteAsync(ID);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }        
    }    
}
