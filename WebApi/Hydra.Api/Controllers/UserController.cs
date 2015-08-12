using Hydra.Domain;
using Mogo.Repository.Generic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hydra.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private MogoAbstractRepository<User, long> _userRepository;

        public UserController(MogoAbstractRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return _userRepository.Select(includeProperties: "Slides");
        }

        // GET: api/User/5
        public User Get(long id)
        {
            return _userRepository.FindById(id, includeProperties: "Slides");
        }

        // POST: api/User
        public void Post([FromBody]User user)
        {
            _userRepository.Insert(user);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]User user)
        {
            user.Id = id;
            _userRepository.Update(user);
        }

        // DELETE: api/User/5
        public void Delete(long id)
        {
            User user = _userRepository.FindById(id);
            _userRepository.Delete(user);
        }
    }
}
