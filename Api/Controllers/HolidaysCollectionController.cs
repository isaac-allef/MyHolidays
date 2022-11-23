using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyHolidays.Models;
using MyHolidays.Repositories;
using MyHolidays.UseCases;

namespace MyHolidays.Controllers
{
    [Route("holidays-collection")]
    [ApiController]
    public class HolidaysCollectionController : ControllerBase
    {
        private readonly IHolidaysCollectionsRepository HolidaysCollectionsRepository;
        private readonly ICheckHolidaysUseCase CheckHolidaysUseCase;

        public HolidaysCollectionController(IHolidaysCollectionsRepository holidaysCollectionsRepository,
                                    ICheckHolidaysUseCase checkHolidaysUseCase) {
            HolidaysCollectionsRepository = holidaysCollectionsRepository;
            CheckHolidaysUseCase = checkHolidaysUseCase;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Create([FromBody] HolidaysCollection holidaysCollection)
        {
            await HolidaysCollectionsRepository.Insert(holidaysCollection);
            return Created("/", holidaysCollection.Name);
        }

        [HttpGet]
        [Route("search/{name}")]
        public async Task<IActionResult> Search([FromRoute] string name, [FromQuery] int page = 1)
        {
            const int PAGE_SIZE = 5;
            var holidaysCollections = await HolidaysCollectionsRepository.Search(name, PAGE_SIZE, page);

            return Ok(holidaysCollections);
        }

        [HttpGet]
        [Route("check-holidays")]
        public async Task<IActionResult> CheckIsHoliday(
            [FromQuery] DateTime? date,
            [FromQuery(Name = "holidays-collection-name")] [Required] HashSet<string> holidaysCollectionsNames)
        {
            var holidays = await CheckHolidaysUseCase.ExecuteAsync(holidaysCollectionsNames, date);
            return Ok(holidays);
        }
    }
}