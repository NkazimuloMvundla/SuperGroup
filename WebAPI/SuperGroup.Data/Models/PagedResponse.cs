using System;
using System.Collections.Generic;
using System.Text;

namespace SuperGroup.Data.Models
{
    public class PagedResponse<TResponse>
    {
        public PagedResponse(int total, IReadOnlyCollection<TResponse> results)
        {
            Total = total;
            Results = results;
        }

        public int Total { get; private set; }

        public IReadOnlyCollection<TResponse> Results { get; private set; }
    }
}
