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
    public class SlideController : ApiController
    {
        private MogoAbstractRepository<Slide, long> _slideRepository;

        public SlideController(MogoAbstractRepository<Slide, long> slideRepository)
        {
            _slideRepository = slideRepository;
        }

        // GET: api/Slide
        public IEnumerable<SlideDTO> Get()
        {
            return Mapper.Map<List<Slide>, List<SlideDTO>>(_slideRepository.Select().ToList());
        }

        // GET: api/Slide/5
        public SlideDTO Get(long id)
        {
            return Mapper.Map<Slide, SlideDTO>(_slideRepository.FindById(id));
        }

        // POST: api/Slide
        public HttpResponseMessage Post([FromBody]SlideDTO slideDTO)
        {
            if (ModelState.IsValid)
            {
                Slide slide = Mapper.Map<SlideDTO, Slide>(slideDTO);
                _slideRepository.Insert(slide);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return ResponseErrorUtil.CreateResponseError(Request, ModelState);
            }
        }

        // PUT: api/Slide/5
        public HttpResponseMessage Put(long id, [FromBody]SlideDTO slideDTO)
        {
            if (ModelState.IsValid)
            {
                Slide slide = Mapper.Map<SlideDTO, Slide>(slideDTO);
                _slideRepository.Update(slide);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return ResponseErrorUtil.CreateResponseError(Request, ModelState);
            }
        }

        // DELETE: api/Slide/5
        public void Delete(long id)
        {
            Slide slide = _slideRepository.FindById(id);
            _slideRepository.Delete(slide);
        }

    }
}
