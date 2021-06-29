using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        Task<Hotel> CreateHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);

    }
}
