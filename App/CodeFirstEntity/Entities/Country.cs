using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Countries")]
    public class Country : PrivateKey<int>
    {
        public Country()
        {
            Stories = new List<Story>();
        }

        public Country(int id, string name, string iSoCode, string slug)
        {
            Id = id;
            Name = name;
            IsoCode = iSoCode;
            Slug = slug;
        }

        public Country(string name, string iSoCode, string slug)
        {
            Name = name;
            IsoCode = iSoCode;
            Slug = slug;
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}