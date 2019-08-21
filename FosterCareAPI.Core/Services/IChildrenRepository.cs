using System;
using System.Collections.Generic;
using FosterCareAPI.Core.Models;

namespace FosterCareAPI.Core.Services
{
    public interface IChildrenRepository
    {

        Children Add(Children children);
        Children Update(Children children);
        Children Get(int id);
        IEnumerable<Children> GetAll();
        void Remove(int id);
    }
}
