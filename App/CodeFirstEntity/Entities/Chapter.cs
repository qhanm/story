using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Chapters")]
    public class Chapter : PrivateKey<int>, Seo, Date, SwichStatus
    {
        public Chapter() { }
        public Chapter(int id, string stringName, int? intName, bool isShow, Status status, string seoAlias, string seoKeyword,
            string seoDescription, string seoTitle, int storyId)
        {
            Id = id;
            StringName = stringName;
            IntName = intName;
            IsShow = isShow;
            Status = status;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoKeyWord = seoKeyword;
            SeoDescription = seoDescription;
            StoryId = storyId;
        }

        public Chapter(string stringName, int? intName, bool isShow, Status status, string seoAlias, string seoKeyword,
            string seoDescription, string seoTitle, int storyId)
        {
            StringName = stringName;
            IntName = intName;
            IsShow = isShow;
            Status = status;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoKeyWord = seoKeyword;
            SeoDescription = seoDescription;
            StoryId = storyId;
        }

        [StringLength(250)]
        public string StringName { get; set; } // is IsShow == true

        public int? IntName { get; set; } // if IsShow == false

        public bool IsShow { get; set; }

        [DefaultValue(Status.Active)]
        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public string SeoDescription { get; set; }
        public string SeoAlias { get; set; }

        public int StoryId { get; set; }

        [ForeignKey("StoryId")]
        public virtual Story Story { get; set; }
    }
}