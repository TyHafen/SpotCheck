
using Microsoft.AspNetCore.Mvc;
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
    }
}