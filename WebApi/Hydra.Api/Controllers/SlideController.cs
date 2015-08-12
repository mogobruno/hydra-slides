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
    public class SlideController : ApiController
    {
        private MogoAbstractRepository<Slide, long> _slideRepository;

        public SlideController(MogoAbstractRepository<Slide, long> slideRepository)
        {
            _slideRepository = slideRepository;
        }

        // GET: api/Slide
        public IEnumerable<Slide> Get()
        {
            return _slideRepository.Select();
        }

        // GET: api/Slide/5
        public Slide Get(long id)
        {
            return _slideRepository.FindById(id);
        }

        // POST: api/Slide
        public HttpResponseMessage Post([FromBody]Slide slide)
        {
            try
            {
                _slideRepository.Insert(slide);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/Slide/5
        public void Put(long id, [FromBody]Slide slide)
        {
            slide.Id = id;
            _slideRepository.Update(slide);
        }

        // DELETE: api/Slide/5
        public void Delete(long id)
        {
            Slide slide = _slideRepository.FindById(id);
            _slideRepository.Delete(slide);
        }
    }
}
