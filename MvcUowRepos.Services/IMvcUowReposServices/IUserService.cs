using MvcUowRepos.Model.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcUowRepos.Services.IMvcUowReposServices
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
    }
}
