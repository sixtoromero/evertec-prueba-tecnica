using evertec.Domain.Entity;
using evertec.Domain.Interface;
using evertec.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;

namespace evertec.Domain.Core
{
    public class ClientesDomain : IClientesDomain
    {
        private readonly IClientesRepository _Repository;
        public IConfiguration Configuration { get; }

        public ClientesDomain(IClientesRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(Cliente model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Cliente model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int IDFacturas)
        {
            return await _Repository.DeleteAsync(IDFacturas);
        }

        public async Task<Cliente> GetAsync(int IdCliente)
        {
            return await _Repository.GetAsync(IdCliente);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
