using evertec.Application.DTO;
using evertec.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.Application.Interface
{
    public interface IUsuariosApplication : IApplication<UsuariosDTO>
    {
        Task<Response<UsuariosDTO>> GetUserByUserName(UsuariosDTO model);
    }
}
