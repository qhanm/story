using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("ImageMetas")]
    public class ImageMeta : PrivateKey<int>, Date
    {
        public ImageMeta() { }

        public ImageMeta(int id, int tableId, int imageId, int typeId, Guid? userId, int position)
        {
            Id = id;
            TableId = tableId;
            ImageId = imageId;
            TypeId = typeId;
            UserId = userId;
            Position = position;
        }

        public ImageMeta(int tableId, int imageId, int typeId, Guid? userId, int position)
        {
            TableId = tableId;
            ImageId = imageId;
            TypeId = typeId;
            UserId = userId;
            Position = position;
        }

        public int TableId { get; set; }

        public int ImageId { get; set; }

        public Guid? UserId;

        [DefaultValue(0)]
        public int Position { get; set; }

        public int TypeId { get; set; }
        public DateTime DateCreated {get; set;}
        public DateTime DateUpdated {get; set;}
    }
}
