using Microsoft.AspNet.Identity;
using Models.Ratings;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RBPServer.Controllers
{
    [RoutePrefix("api/Rating")]
    [Authorize]
    public class RatingController : ApiController
    {
        [Route("Liquor")]
        public IHttpActionResult Post(CreateLiquorRating rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.CreateLiquorRating(rating))
                return InternalServerError();

            return Ok();
        }
        [Route("Recipe")]
        public IHttpActionResult Post(CreateRecipeRating rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.CreateRecipeRating(rating))
                return InternalServerError();

            return Ok();
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var RatingService = new RatingService(userId);
            return RatingService;
        }

    }
}