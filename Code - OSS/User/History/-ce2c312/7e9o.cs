
namespace System.Linq
{
    public static class Enumerable3
    {
                public static IEnumerable<TSource> Out<TSource>(
                    this IEnumerable<TSource> source,
                    Func<IEnumerable<TSource>,object> predicate,
                    out object val
                ){
                    val = predicate(source);
                    return source;
                }
    }
}