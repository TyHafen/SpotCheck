
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotCheck.Models;
using SpotCheck.Services;

namespace SpotCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SpotsController : ControllerBase
    {
        private readonly SpotsService _spotsService;

        public SpotsController(SpotsService spotsService)
        {
            _spotsService = spotsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Spot>> Create([FromBody] Spot data)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                data.CreatorId = userInfo.Id;
                data.Creator = userInfo;
                Spot spot = _spotsService.Create(data);
                return Ok(spot);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        [HttpGet]
        public ActionResult<List<SpotsController>> GetAll()
        {
            try
            {
                List<Spot> spots = _spotsService.GetAll();
                return Ok(spots);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}