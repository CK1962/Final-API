using System;
using FosterCareAPI.Core.Models;

namespace FosterCareAPI.ApiModels
{
    public class ChildrenModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dob { get; set; }

        public string MoveInDate { get; set; }
    }
}
