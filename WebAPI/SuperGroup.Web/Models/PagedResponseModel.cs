using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Web.Models
{
    public class PagedResponseModel<TResponse>
    {
        public PagedResponseModel(int total, IReadOnlyCollection<TResponse> results)
        {
            Total = total;
            Results = results;
        }

        public int Total { get; private set; }

        public IReadOnlyCollection<TResponse> Results { get; private set; }
    }
}
