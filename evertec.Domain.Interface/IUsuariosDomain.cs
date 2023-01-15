using evertec.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.Domain.Interface
{
    public interface IUsuariosDomain : IDomain<Usuarios>
    {
        Task<Usuarios> GetUserByUserName(Usuarios model);
    }
}
