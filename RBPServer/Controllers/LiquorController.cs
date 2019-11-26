using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models.Liquor;
using Models.Recipe;
using Services;

namespace RBPServer.Controllers
{
    [Authorize]
    public class LiquorController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            LiquorService liquorService = CreateLiquorService();
            var liquors = liquorService.GetLiquors();
            return Ok(liquors);
        }

        public IHttpActionResult GetAllFavorites()
        {
            LiquorService liquorService = CreateLiquorService();
            var faveliquors = liquorService.GetFaveLiquors();
            return Ok(faveliquors);
        }

        public IHttpActionResult GetLiquorById(int id)
        {
            LiquorService liquorService = CreateLiquorService();
            var liquors = liquorService.GetLiquorById(id);
            return Ok(liquors);
        }

        public IHttpActionResult Post(LiquorCreate liquor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLiquorService();

            if (!service.CreateLiquor(liquor))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LiquorEdit liquor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLiquorService();

            if (!service.UpdateLiquor(liquor))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLiquorService();

            if (!service.DeleteLiquor(id))
                return InternalServerError();

            return Ok();
        }

        private LiquorService CreateLiquorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var LiquorService = new LiquorService(userId);
            return LiquorService;
        }
    }
}