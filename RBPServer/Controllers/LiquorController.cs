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
    [RoutePrefix("api/Liquors")]
    public class LiquorController : ApiController
    {
        [Route ("AllLiquors")]
        public IHttpActionResult GetAll()
        {
            LiquorService liquorService = new LiquorService();
            var liquors = liquorService.GetLiquors();
            return Ok(liquors);
        }

        [Route("Favorites")]
        public IHttpActionResult GetAllFavorites()
        {
            LiquorService liquorService = new LiquorService();
            var faveliquors = liquorService.GetFaveLiquors();
            return Ok(faveliquors);
        }

        public IHttpActionResult GetLiquorById(int id)
        {
            LiquorService liquorService = new LiquorService();
            var liquors = liquorService.GetLiquorById(id);
            return Ok(liquors);
        }
        [Route("Create")]
        public IHttpActionResult Post(LiquorCreate liquor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new LiquorService();

            if (!service.CreateLiquor(liquor))
                return InternalServerError();

            return Ok();
        }

        [Route("Edit")]
        public IHttpActionResult Put(LiquorEdit liquor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new LiquorService();

            if (!service.UpdateLiquor(liquor))
                return InternalServerError();

            return Ok();
        }
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var service = new LiquorService();

            if (!service.DeleteLiquor(id))
                return InternalServerError();

            return Ok();
        }
    }
}