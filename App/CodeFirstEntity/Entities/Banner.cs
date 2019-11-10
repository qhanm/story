using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Banners")]
    public class Banner: PrivateKey<int>, SwichStatus
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [DefaultValue(Status.DeActive)]
        public Status Status { get; set; }
    }
}
