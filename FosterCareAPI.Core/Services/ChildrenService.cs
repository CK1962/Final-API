using System;
using FosterCareAPI.Core.Models;
using System.Collections.Generic;

namespace FosterCareAPI.Core.Services
{
    public class ChildrenService : IChildrenService
    {
        private readonly IChildrenRepository _childrenRepository;

        // TODO: inject IChildrenRepository
        public ChildrenService(IChildrenRepository ChildrenRepository)
        {
            _childrenRepository = ChildrenRepository;
        }

        public Children Add(Children newChildren)
        {
            return _childrenRepository.Add(newChildren);
        }

        public Children Get(int id)
        {
            return _childrenRepository.Get(id);
        }

        public IEnumerable<Children> GetAll()
        {
            return _childrenRepository.GetAll();
        }

        public void Remove(int id)
        {
            _childrenRepository.Remove(id);
        }

        public Children Update(Children updatedChildren)
        {
            return _childrenRepository.Update(updatedChildren);
        }
    }
}
