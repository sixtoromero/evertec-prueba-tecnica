using System.Data;

namespace evertec.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
