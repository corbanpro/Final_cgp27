using Final_cgp27.Models.Data;
using System.Linq;

namespace Final_cgp27.Models
{
    public interface IEntertainmentRepository
    {
        IQueryable<Entertainers> Entertainers { get; }

        public void AddEntertainer(Entertainers newEntry);
        public void EditEntertainer(Entertainers entertainer);
        public void DeleteEntertainer(Entertainers entertainer);


    }
}
