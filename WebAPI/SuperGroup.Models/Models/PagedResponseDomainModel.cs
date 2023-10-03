using System;
using System.Collections.Generic;
using System.Text;

namespace SuperGroup.Models.Models
{
    public class PagedResponseDomainModel<TResponse>
    {
        public PagedResponseDomainModel(int total, IReadOnlyCollection<TResponse> results)
        {
            Total = total;
            Results = results;
        }

        public int Total { get; private set; }

        public IReadOnlyCollection<TResponse> Results { get; private set; }
    }
}
