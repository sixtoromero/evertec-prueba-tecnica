using evertec.Domain.Entity;
using evertec.Domain.Interface;
using evertec.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.Domain.Core
{
    public class UsuariosDomain : IUsuariosDomain
    {
        private readonly IUsuariosRepository _Repository;
        public IConfiguration Configuration { get; }

        public UsuariosDomain(IUsuariosRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<Usuarios> GetUserByUserName(Usuarios model)
        {
            return await _Repository.GetUserByUserName(model);
        }

        public async Task<bool> InsertAsync(Usuarios model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Usuarios model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDFacturas)
        {
            return await _Repository.DeleteAsync(IDFacturas);
        }

        public async Task<Usuarios> GetAsync(int IdUsuarios)
        {
            return await _Repository.GetAsync(IdUsuarios);
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

    }
}
