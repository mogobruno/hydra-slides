using AutoMapper;
using Hydra.Api.DTO;
using Hydra.Api.Identity;
using Hydra.Domain;
using Microsoft.AspNet.Identity;
using Mogo.Repository.Generic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity.Owin;

namespace Hydra.Api.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "GET,PUT,POST,DELETE")]
    public class UserController : ApiController
    {
        private MogoAbstractRepository<User, int> _userRepository;

        public UserController(MogoAbstractRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        public IEnumerable<UserDTO> Get()
        {
            return Mapper.Map<List<User>, List<UserDTO>>(_userRepository.Select(includeProperties: "Slides").ToList());
        }

        // GET: api/User/5
        public UserDTO Get(int id)
        {
            return Mapper.Map<User, UserDTO>(_userRepository.FindById(id, includeProperties: "Slides"));
        }

        // POST: api/User
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody]UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.Map<UserDTO, User>(userDTO);
                HydraIdentityUser userIdentity = new HydraIdentityUser
                {
                    Email = user.Email,
                    UserName = user.Email,
                };
                HydraUserManager manager = Request.GetOwinContext().GetUserManager<HydraUserManager>();
                IdentityResult result = manager.Create(userIdentity, user.Password);
                if (result.Succeeded)
                {
                    _userRepository.Insert(user);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    if (result.Errors != null)
                    {
                        result.Errors.ToList().ForEach(error =>
                        {
                            ModelState.AddModelError("",error);
                        });
                    }
                    return ResponseErrorUtil.CreateResponseError(Request, ModelState);
                }
            }
            else
            {
                return ResponseErrorUtil.CreateResponseError(Request, ModelState);
            }
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]UserUpdateDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.Map<UserUpdateDTO, User>(userDTO);
                _userRepository.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return ResponseErrorUtil.CreateResponseError(Request, ModelState);
            }
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            User user = _userRepository.FindById(id);
            _userRepository.Delete(user);
        }
    }
}
