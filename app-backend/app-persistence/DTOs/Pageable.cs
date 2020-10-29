using AppPersistence.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.DTOs
{
    public class Pageable
    {
        public Pageable(
            int pageNumber,
            int pageSize,
            OrderDirection orderDirection = OrderDirection.Ascending
        )
        {
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be equal to or greater than zero");
            }

            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page size must be greater than zero");
            }

            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderDirection = orderDirection;
        }

        /// <summary>
        /// Zero based page number
        /// </summary>
        public int PageNumber { get; }
        /// <summary>
        /// Numbr of items per page
        /// </summary>
        public int PageSize { get; }
        /// <summary>
        /// Order direction
        /// </summary>
        public OrderDirection OrderDirection { get; }
    }
}
