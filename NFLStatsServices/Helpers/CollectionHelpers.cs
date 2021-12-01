using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Services.Helpers
{
    public static class CollectionHelpers
    {
        public static IEnumerable<T> SortRecords<T>(this IEnumerable<T> unsorted, string sortBy, bool ascending = false)
        {
            if (unsorted is null || !unsorted.Any()) return new List<T>();

            return ascending
                ? unsorted.OrderBy(r => r.GetType().GetProperty(sortBy).GetValue(r))
                : unsorted.OrderByDescending(r => r.GetType().GetProperty(sortBy).GetValue(r));


        }

        public static IEnumerable<T> PageRecords<T>(this IEnumerable<T> unpaged, int pageSize, int pageNumber)
        {
            if (unpaged is null || !unpaged.Any()) return new List<T>();

            var skipRecords = (pageNumber - 1) * pageSize;

            return unpaged.Skip(skipRecords).Take(pageSize);

        }
    }
}
