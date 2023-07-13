using HomeFindManagement.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HomeFindManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeFinderController : ControllerBase
    {
        private readonly IHomeFinderService _homeFinderService;
        private readonly ILogger<HomeFinderController> _logger;

        public HomeFinderController(IHomeFinderService homeFinderService, ILogger<HomeFinderController> logger )
        {
         
            _homeFinderService = homeFinderService;

            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetHomeFinder([Required] int homeId)
        {
            try
            {
                if(homeId <= 0)
                {
                    return BadRequest("The ID must to be natural and more than 0.");
                }
                decimal totalPrice = await _homeFinderService.GetHomeFinderTotalPrice(homeId);

                if(totalPrice == 0)
                {
                    _logger.LogError($"Introduced home ID: {homeId}, ERROR: not found home with this ID.");
                    return BadRequest($"Can't process the petition for the home with ID {homeId}");

                }
                else
                {
                    return Ok($"The total priece of the house with ID {homeId} is {totalPrice}");
                }

            }catch(Exception ex)
            {
                _logger.LogError($"Exception happended, {ex.Message}.");
                return StatusCode(500, "Unexpected error happended."); 

            }
             
        }
    }
}
