using AutoMapper;
using MvcUowRepos.Model.DtoModels;
using MvcUowRepos.Repository;
using MvcUowRepos.Services.IMvcUowReposServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUowRepos.Services.MvcUowReposServices
{
    public class UserService:IUserService
    {
        private readonly IMvcUow _mvcUow;

        public UserService(IMvcUow mvcUow)
        {
            _mvcUow = mvcUow;
        }

        private static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            return ConfigureMapper().Map<List<UserDto>>(await _mvcUow.UserRepository.GetAll());
        }
    }
}
