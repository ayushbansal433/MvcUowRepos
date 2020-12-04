using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUowRepos.Repository
{
    public class MvcUow : IMvcUow
    {
        private IMvcRepository<User> _userRepository;
        private readonly MvcUowReposEntities _context;

        public MvcUow(MvcUowReposEntities context)
        {
            _context = context;
        }

        public IMvcRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new MvcRepository<User>(_context)); }
        }
    }
}
