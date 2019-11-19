using System;

namespace Superheros.API.DTO
{
    public class UpdateHeroRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
    }
}