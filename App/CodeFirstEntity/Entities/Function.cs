using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System.ComponentModel.DataAnnotations.Schema;

namespace story.App.CodeFirstEntity.Entities
{
    [Table("Functions")]
    public class Function : PrivateKey<int>, SwichStatus
    {
        public Function()
        {
        }

        public Function(int id, string name, string url, string iconCss, int sortOrder, Status status, int? parentId)
        {
            Id = id;
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = status;
            ParentId = parentId;
        }

        public Function(string name, string url, string iconCss, int sortOrder, Status status, int? parentId)
        {
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = status;
            ParentId = parentId;
        }

        public string Name { get; set; }

        public string Url { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public int? ParentId { get; set; }
        public Status Status { get; set; }
    }
}