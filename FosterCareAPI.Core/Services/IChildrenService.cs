using System;
using System.Collections.Generic;
using FosterCareAPI.Core.Models;

namespace FosterCareAPI.Core.Services
{
    interface IChildrenService
    {
        Children Add(Children newChildren);
        Children Update(Children updatedChildren);
        Children Get(int id);
        IEnumerable<Children> GetAll();
        void Remove(int id);
    }
}
