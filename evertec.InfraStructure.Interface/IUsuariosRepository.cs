using evertec.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.InfraStructure.Interface
{
    public interface IUsuariosRepository : IRepository<Usuarios>
    {
        Task<Usuarios> GetUserByUserName(Usuarios model);
    }
}
