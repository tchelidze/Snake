using System.Collections.Generic;

namespace Assets
{
    public static class IListExtensions
    {
        public static void Move<T>(this IList<T> @in, int from, int to)
        {
            var which = @in[from];
            @in.RemoveAt(from);
            @in.Insert(to, which);
        }

        public static void AddFirst<T>(this IList<T> @in, T what)
        {
            @in.Insert(0, what);
        }
    }
}