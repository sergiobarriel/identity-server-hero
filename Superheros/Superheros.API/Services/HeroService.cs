using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Superheros.API.Abstractions;
using Superheros.API.DTO;
using Superheros.API.Models;

namespace Superheros.API.Services
{
    public class HeroService : IHeroService
    {
        private readonly HeroContext _context;
        private readonly IMapper _mapper;

        public HeroService(HeroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HeroResponse> GetHeroAsync(GetHeroRequest request)
        {
            return await _context.Heros
                .Where(x => x.Id == request.Id)
                .ProjectTo<HeroResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HeroResponse>> GetHerosAsync()
        {
            return await _context.Heros
                .ProjectTo<HeroResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Guid> CreateHeroAsync(CreateHeroRequest request)
        {
            var hero = _mapper.Map<Hero>(request);

            await _context.AddAsync(hero);
            await _context.SaveChangesAsync();

            return hero.Id;
        }

        public async Task<bool> UpdateHeroAsync(UpdateHeroRequest request)
        {
            var hero = await GetHeroAsync(request.Id);

            if (hero == null) return false;

            hero.RealName = request.RealName;
            hero.Name = request.Name;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteHeroAsync(DeleteHeroRequest request)
        {
            var hero = await GetHeroAsync(request.Id);

            if (hero == null) return false;

            _context.Remove(hero);

            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<Hero> GetHeroAsync(Guid id) => await _context.Heros.FirstOrDefaultAsync(x => x.Id == id);
    }
}
