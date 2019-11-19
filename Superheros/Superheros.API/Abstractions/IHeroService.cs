using Superheros.API.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Superheros.API.Abstractions
{
    public interface IHeroService
    {
        Task<HeroResponse> GetHeroAsync(GetHeroRequest request);
        Task<IEnumerable<HeroResponse>> GetHerosAsync();
        Task<Guid> CreateHeroAsync(CreateHeroRequest request);
        Task<bool> UpdateHeroAsync(UpdateHeroRequest request);
        Task<bool> DeleteHeroAsync(DeleteHeroRequest request);
    }
}
