using System.Threading.Tasks;

namespace ProductService.DataAccess
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
