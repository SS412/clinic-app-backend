using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.DTOs
{
        public class Page<TItem>
        {
            public Page(
                IReadOnlyList<TItem> items,
                int totalPages
            )
            {
                Items = items;
                TotalPages = totalPages;
            }

            public IReadOnlyList<TItem> Items { get; }
            public int TotalPages { get; }
        }
}
