using System;
using FosterCareAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI.ApiModels
{
    public static class ChildrenMappingExtensions
    {
        public static ChildrenModel ToApiModel(this Children children)
        {
            return new ChildrenModel
            {
                Id = children.Id,
                Name = children.Name,
                Dob = children.Dob,
                MoveInDate = children.MoveInDate,
            };
        }

        public static Children ToDomainModel(this ChildrenModel childrenModel)
        {
            return new Children
            {
                Id = childrenModel.Id,
                Name = childrenModel.Name,
                Dob = childrenModel.Dob,
                MoveInDate = childrenModel.MoveInDate,
            };
        }

        public static IEnumerable<ChildrenModel> ToApiModels(this IEnumerable<Children> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Children> ToDomainModels(this IEnumerable<ChildrenModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
