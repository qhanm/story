using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("KindStories")]
    public class KindStory : PrivateKey<int>, Seo, Date, SwichStatus
    {
        public KindStory()
        {
            Stories = new List<Story>();
        }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public string SeoDescription { get; set; }
        public string SeoAlias { get; set; }

        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}