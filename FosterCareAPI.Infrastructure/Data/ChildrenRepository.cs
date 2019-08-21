using FosterCareAPI.Core.Models;
using FosterCareAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI.Infrastructure.Data
{
    public class ChildrenRepository : IChildrenRepository
    {
        private readonly FosterDbContext _dbContext;

        public ChildrenRepository(FosterDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Children> GetAll()
        {
            return _dbContext.Child
               // .Include(c => c.House)
              //  .Include(c => c.Appointments)
                .ToList();
        }


        public Children Get(int id)
        {
            return _dbContext.Child
               //  .Include(c => c.House)
              //  .Include(c => c.Appointments)
                 .SingleOrDefault(c => c.Id == id);
        }

        public Children Add(Children Children)
        {
            _dbContext.Child.Add(Children);
            _dbContext.SaveChanges();
            return Children;
        }

        public Children Update(Children updatedChildren)
        {
            var currentChild = _dbContext.Child.Find(updatedChildren.Id);
            if (currentChild == null) return null;
            _dbContext.Entry(currentChild)
                .CurrentValues
                .SetValues(updatedChildren);

            _dbContext.Child.Update(currentChild);
            _dbContext.SaveChanges();
            return currentChild;
        }

        public void Remove(int id)
        {
            var childToDelete = Get(id);

            // TODO: remove blog
            _dbContext.Child.Remove(childToDelete);
            _dbContext.SaveChanges();
        }
    }
}
