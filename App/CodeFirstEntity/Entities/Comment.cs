using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.Entities
{
    public class Comment : PrivateKey<int>, Date, SwichStatus
    {
        public Comment() { }

        public Comment(int id, string name, string email, string content, int? countLike, int? countDisLike, Status status,
            int? parentId, Guid? userId, int storyId)
        {
            Id = id;
            Name = name;
            Email = email;
            Content = content;
            CountLike = countLike;
            CountDisLike = countDisLike;
            Status = status;
            ParentId = parentId;
            UserId = userId;
            StoryId = storyId;
        }

        public Comment(string name, string email, string content, int? countLike, int? countDisLike, Status status,
            int? parentId, Guid? userId, int storyId)
        {
            Name = name;
            Email = email;
            Content = content;
            CountLike = countLike;
            CountDisLike = countDisLike;
            Status = status;
            ParentId = parentId;
            UserId = userId;
            StoryId = storyId;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public int? CountLike { get; set; }

        public int? CountDisLike { get; set; }

        public int? ParentId { get; set; }

        public Guid? UserId { get; set; }

        public Status Status {get; set;}
        public DateTime DateCreated {get; set;}
        public DateTime DateUpdated {get; set;}

        [Required]
        public int StoryId { get; set; }

        [ForeignKey("StoryId")]
        public virtual Story Story { get; set; }
    }
}
