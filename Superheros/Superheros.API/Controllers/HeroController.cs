using Microsoft.AspNetCore.Mvc;
using Superheros.API.Abstractions;
using Superheros.API.DTO;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Superheros.API.Controllers
{
    
    [Route("api/[controller]")]
    [Authorize]
    public class HeroController : Controller
    {
        private readonly IHeroService _heroService;
        private readonly IMapper _mapper;

        public HeroController(IHeroService heroService, IMapper mapper)
        {
            _heroService = heroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHerosAsync()
        {
            return Ok(await _heroService.GetHerosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroAsync([FromRoute] Guid id)
        {
            return Ok(await _heroService.GetHeroAsync(_mapper.Map<GetHeroRequest>(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHeroAsync([FromBody] CreateHeroRequest request)
        {
            return Ok(await _heroService.CreateHeroAsync(request));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHeroAsync([FromRoute] Guid id, [FromBody] UpdateHeroRequest request)
        {
            return Ok(await _heroService.UpdateHeroAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroAsync([FromRoute] Guid id)
        {
            return Ok(await _heroService.DeleteHeroAsync(_mapper.Map<DeleteHeroRequest>(id)));
        }
}
}
