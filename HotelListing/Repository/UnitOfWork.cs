using HotelListing.Data;
using HotelListing.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
         
        public IGenericRepository<Country> CoutiresRepo =>_countries?? new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> HotelsRepo => _hotels??new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool v)
        {
            _context.Dispose();
        }

        public async Task Save()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
