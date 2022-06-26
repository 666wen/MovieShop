using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PagedResultSetModel<T> where T : class
    {
        public PagedResultSetModel(int pageNumber, int totalRecords,  int pageSize, IEnumerable<T> pagedData)
        {
            PageNumber = pageNumber;
            TotalRecords = totalRecords;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalRecords/(double)pageSize);
            PagedData = pagedData;
        }

        public int PageNumber { get;}
        public int TotalRecords { get;}
        public int PageSize { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public IEnumerable<T> PagedData { get; set; }
    }
}
