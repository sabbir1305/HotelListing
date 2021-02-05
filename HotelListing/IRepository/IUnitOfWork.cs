using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> CoutiresRepo { get; }
        IGenericRepository<Hotel> HotelsRepo { get; }
        IGenericRepository<Room> RoomsRepo { get; }
        Task Save();
    }
}
