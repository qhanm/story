using story.App.CodeFirstEntity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.Extensions.Constants
{
    public static class StatusConstant
    {
        public const string Deactive = "DeActive";

        public const string Active = "Active";

        public const string All = "All";

        public static Status GetStatus(string status)
        {

            switch (status)
            {
                case Active:
                    return Status.Active;
                case Deactive:
                    return Status.DeActive;
            }


            return Status.All;
        }
    }
}
