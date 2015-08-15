using AutoMapper;
using Hydra.Api.DTO;
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
    [EnableCors(origins: "*", headers: "*", methods: "GET,PUT,POST,DELETE")]
    public class UserController : ApiController
    {
        private MogoAbstractRepository<User, long> _userRepository;

        public UserController(MogoAbstractRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        public IEnumerable<UserDTO> Get()
        {
            return Mapper.Map<List<User>,List<UserDTO>>(_userRepository.Select(includeProperties: "Slides").ToList());
        }

        // GET: api/User/5
        public UserDTO Get(long id)
        {
            return Mapper.Map<User, UserDTO>(_userRepository.FindById(id, includeProperties: "Slides"));
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.Map<UserDTO, User>(userDTO);
                _userRepository.Insert(user);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return ResponseErrorUtil.CreateResponseError(Request, ModelState);
            }
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.Map<UserDTO, User>(userDTO);
                _userRepository.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return ResponseErrorUtil.CreateResponseError(Request, ModelState);
            }
        }

        // DELETE: api/User/5
        public void Delete(long id)
        {
            User user = _userRepository.FindById(id);
            _userRepository.Delete(user);
        }
    }
}
