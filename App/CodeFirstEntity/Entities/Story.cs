using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Stories")]
    public class Story : PrivateKey<int>, Seo, Date, SwichStatus
    {
        public Story()
        {
            Chapters = new List<Chapter>();
        }

        public Story(int id, string name, string image, string url, int? countView, int? countLike, int? countHeart,
                        bool hotFlag, bool newFlag, int? homeFlag, string description, string content, int categoryId,
                        Status status, string seoAlias, string seoTitle, string seoDescription, string seoKeyword,
                        int kindStoryId, int countryId, Guid userId
                    )
        {
            Id = id;
            Name = name;
            Image = image;
            Url = url;
            CountView = countView;
            CountLike = countLike;
            CountHeart = countHeart;
            HotFlag = hotFlag;
            NewFlag = newFlag;
            HomeFlag = homeFlag;
            Description = description;
            Content = content;
            CategoryId = categoryId;
            Status = status;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoDescription = seoDescription;
            SeoKeyWord = seoKeyword;
            KindStoryId = kindStoryId;
            CountryId = countryId;
            UserId = userId;
        }

        public Story(string name, string image, string url, int? countView, int? countLike, int? countHeart,
                bool hotFlag, bool newFlag, int? homeFlag, string description, string content, int categoryId,
                Status status, string seoAlias, string seoTitle, string seoDescription, string seoKeyword,
                int kindStoryId, int countryId, Guid userId
            )
        {
            Name = name;
            Image = image;
            Url = url;
            CountView = countView;
            CountLike = countLike;
            CountHeart = countHeart;
            HotFlag = hotFlag;
            NewFlag = newFlag;
            HomeFlag = homeFlag;
            Description = description;
            Content = content;
            CategoryId = categoryId;
            Status = status;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoDescription = seoDescription;
            SeoKeyWord = seoKeyword;
            KindStoryId = kindStoryId;
            CountryId = countryId;
            UserId = userId;
        }

        [StringLength(300)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [DefaultValue(0)]
        public int? CountView { get; set; }

        [DefaultValue(0)]
        public int? CountLike { get; set; }

        [DefaultValue(0)]
        public int? CountHeart { get; set; }

        [DefaultValue(false)]
        public bool HotFlag { get; set; }

        [DefaultValue(false)]
        public bool NewFlag { get; set; }

        [DefaultValue(0)]
        public int? HomeFlag { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int KindStoryId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public string SeoDescription { get; set; }
        public string SeoAlias { get; set; }

        [ForeignKey("KindStoryId")]
        public virtual KindStory KindStory { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}