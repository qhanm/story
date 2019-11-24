using story.App.CodeFirstEntity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Model
{
    public class AppRoleViewModel
    {
        public AppRoleViewModel() { }

        public AppRoleViewModel(Guid id, string name, string description, Status status, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            DateCreted = dateCreated;
            DateUpdated = dateUpdated;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreted { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
