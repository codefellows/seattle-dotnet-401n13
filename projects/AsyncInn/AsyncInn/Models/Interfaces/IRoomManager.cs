using AsyncInn.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
   public interface IRoomManager
    {
        Task<RoomDTO> CreateRoom(RoomDTO room);

        Task UpdateRoom(RoomDTO room);

        Task DeleteRoom(int id);

        Task<List<RoomDTO>> GetRooms();

        Task<RoomDTO> GetRoom(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmenityFromRoom(int roomId, int amenityId);

    }
}
