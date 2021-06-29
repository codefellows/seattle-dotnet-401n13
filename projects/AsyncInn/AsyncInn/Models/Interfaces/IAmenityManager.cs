using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenityManager
    {
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);
        Task DeleteAmentity(int id);
        Task<List<AmenityDTO>> GetAmenities();
        Task<AmenityDTO> GetAmentity(int id);
    }
}
