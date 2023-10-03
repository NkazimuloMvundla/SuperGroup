using System;
using System.Collections.Generic;
using System.Text;

namespace SuperGroup.Data.Models
{
    public abstract class PagedQuery<TResponse> : IQuery<PagedResponse<TResponse>>
    {
        protected PagedQuery()
        {
            CurrentPage = 1;
            RowsPerPage = 10;
        }

        public int CurrentPage { get; set; }

        public int RowsPerPage { get; set; }

        public int RowsToSkip => (CurrentPage - 1) * RowsPerPage;
    }

    public interface IQuery<TResponse> : IQuery
    {
    }

    public interface IQuery
    {
    }
}
