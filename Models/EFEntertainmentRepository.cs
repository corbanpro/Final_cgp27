using Final_cgp27.Models.Data;
using System.Linq;

namespace Final_cgp27.Models
{
    public class EFEntertainmentRepository : IEntertainmentRepository
    {
        private EntertainmentAgencyExampleContext _context { get; set; }

        public EFEntertainmentRepository(EntertainmentAgencyExampleContext temp) => _context = temp;

        public IQueryable<Entertainers> Entertainers => _context.Entertainers;

        public void AddEntertainer(Entertainers newEntry)
        {
            newEntry.EntertainerId = _context.Entertainers.OrderBy(x => x.EntertainerId).Last().EntertainerId + 1;
            _context.Entertainers.Add(newEntry);
            
            _context.SaveChanges();

        }

        public void EditEntertainer(Entertainers entertainer)
        {
            _context.Entertainers.Update(entertainer);
            _context.SaveChanges();

        }

        public void DeleteEntertainer(Entertainers entertainer)
        {
            _context.Entertainers.Remove(entertainer);
            _context.SaveChanges();

        }
    }
}
