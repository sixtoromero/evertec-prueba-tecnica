using Dapper;
using evertec.Domain.Entity;
using evertec.InfraStructure.Interface;
using evertec.Transversal.Common;
using System.Data;

namespace evertec.InfraStructure.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ClientesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Cliente model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClientesInsert";
                var parameters = new DynamicParameters();
                
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Fecha_Nacimiento", model.Fecha_Nacimiento);
                parameters.Add("Foto", model.Foto);
                parameters.Add("Estado_Civil", model.Estado_Civil);
                parameters.Add("Tiene_Hermanos", model.Tiene_Hermanos);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Cliente model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClientesUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Id", model.Id);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Fecha_Nacimiento", model.Fecha_Nacimiento);
                parameters.Add("Foto", model.Foto);
                parameters.Add("Estado_Civil", model.Estado_Civil);
                parameters.Add("Tiene_Hermanos", model.Tiene_Hermanos);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelClientes";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Cliente> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClientesByID";
                var parameters = new DynamicParameters();
                parameters.Add("IdCliente", ID);

                var result = await connection.QuerySingleAsync<Cliente>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClientes";

                var result = await connection.QueryAsync<Cliente>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
