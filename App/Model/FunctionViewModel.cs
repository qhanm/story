using story.App.CodeFirstEntity.Constant;
using System;
using System.ComponentModel.DataAnnotations;

namespace story.App.Model
{
    public class FunctionViewModel
    {
        public FunctionViewModel(){}

        public FunctionViewModel(string id, string name, string url, string iconCss, int sortOrder, string parentId, Status status)
        {
            Id = id;
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            ParentId = parentId;
            Status = status;
        }

        public FunctionViewModel(string name, string url, string iconCss, int sortOrder, string parentId, Status status)
        {
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            ParentId = parentId;
            Status = status;
        }

        public string Id {get; set;}

        public string Name { get; set; }

        public string Url { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public string ParentId { get; set; }
        
        public Status Status { get; set; }
    }
}