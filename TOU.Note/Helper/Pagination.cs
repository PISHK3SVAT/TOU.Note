using System.Collections;

namespace TOU.Note.Helper
{
    public static class Pagination
    {
        public static IEnumerable<T> ToPage<T>(this IEnumerable<T> source,int page, int size)
        {
            return source.Skip((page-1)*size).Take(size);
        }
    }
}
