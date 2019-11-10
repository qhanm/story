using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Images")]
    public class Image : PrivateKey<int>, Date
    {
        public Image(int id, string name, string url, string slug, string alt, string caption, string description,
            int size, string type, string extension)
        {
            Id = id;
            Name = name;
            Url = url;
            Slug = slug;
            Alt = alt;
            Caption = caption;
            Description = description;
            Size = size;
            Type = type;
            Extension = extension;
        }

        public Image(string name, string url, string slug, string alt, string caption, string description,
            int size, string type, string extension)
        {
            Name = name;
            Url = url;
            Slug = slug;
            Alt = alt;
            Caption = caption;
            Description = description;
            Size = size;
            Type = type;
            Extension = extension;
        }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [StringLength(250)]
        public string Alt { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public int Size { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(100)]
        public string Extension { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}