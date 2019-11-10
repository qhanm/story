using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;

namespace story.App.CodeFirstEntity.Entities
{
    public class Category : PrivateKey<int>, Seo, SwichStatus, Date
    {
        public Category()
        {
            Stories = new List<Story>();
        }

        public Category(int id, string name, string image, string url, Status status, string seoAlias, string seoKeyword,
            string seoDescription, string seoTitle)
        {
            Id = id;
            Name = name;
            Image = image;
            Url = url;
            Status = status;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoKeyWord = seoKeyword;
            SeoDescription = seoDescription;
        }

        public Category(string name, string image, string url, Status status, string seoAlias, string seoKeyword,
            string seoDescription, string seoTitle)
        {
            Name = name;
            Image = image;
            Url = url;
            Status = status;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoKeyWord = seoKeyword;
            SeoDescription = seoDescription;
        }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public string SeoTitle { get; set; }
        public string SeoKeyWord { get; set; }
        public string SeoDescription { get; set; }
        public string SeoAlias { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}