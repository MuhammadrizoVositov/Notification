using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Infrustructure.Application.Common.Notification.Model.Querying
{
    public class FilterPagination
    {
        public uint PageSize { get; set; } = 10;

        public uint PageToken { get; set; } = 1;
    }
}
