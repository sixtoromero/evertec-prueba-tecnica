using AutoMapper;
using evertec.Application.DTO;
using evertec.Application.Interface;
using evertec.Domain.Entity;
using evertec.Domain.Interface;
using evertec.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.Application.Main
{
    public class ClientesApplication : IClientesApplication
    {
        private readonly IClientesDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ClientesApplication> _logger;

        public ClientesApplication(IClientesDomain _Domain, IMapper mapper, IAppLogger<ClientesApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(ClienteDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Cliente>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ClienteDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Cliente>(modelDto);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int ID)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DeleteAsync(ID);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<ClienteDTO>> GetAsync(int ID)
        {
            var response = new Response<ClienteDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);

                response.Data = _mapper.Map<ClienteDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<ClienteDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ClienteDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ClienteDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
