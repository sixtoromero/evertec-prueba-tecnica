using Dapper;
using evertec.Domain.Entity;
using evertec.InfraStructure.Interface;
using evertec.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.InfraStructure.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsuariosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Usuarios> GetUserByUserName(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuariosByUserName";
                var parameters = new DynamicParameters();
                parameters.Add("Correo", model.Correo);
                parameters.Add("Contrasena", model.Contrasena);

                var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> InsertAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Correo", model.Correo);
                //parameters.Add("Usuario", model.Usuario);
                parameters.Add("Contrasena", model.Contrasena);                

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Correo", model.Correo);
                //parameters.Add("Usuario", model.Usuario);
                parameters.Add("Contrasena", model.Contrasena);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelUsuarios";
                var parameters = new DynamicParameters();

                parameters.Add("Id", ID);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Usuarios> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuariosByID";
                var parameters = new DynamicParameters();
                parameters.Add("Id", ID);

                var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuarios";

                var result = await connection.QueryAsync<Usuarios>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
