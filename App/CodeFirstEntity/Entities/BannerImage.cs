using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("BannerImages")]
    public class BannerImage: PrivateKey<int>
    {

        [Required]
        public int ImageId { get; set; }

        [Required]
        public int BannerId { get; set; }

        [DefaultValue(0)]
        public int Position { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        [ForeignKey("BannerId")]
        public virtual Banner Banner { get; set; }
    }
}
