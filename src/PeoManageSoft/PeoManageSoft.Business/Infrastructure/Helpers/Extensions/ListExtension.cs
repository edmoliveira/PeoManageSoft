namespace PeoManageSoft.Business.Infrastructure.Helpers.Extensions
{
    /// <summary>
    /// Provides a extension of the List<T> class.
    /// </summary>
    public static class ListExtension
    {
        #region Methods public

        /// <summary>
        /// Adds an object to the end of the System.Collections.Generic.List`1.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="source">Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.</param>
        /// <param name="predicate">A function to test if the item can be added.</param>
        /// <param name="item">The object to be added to the end of the System.Collections.Generic.List`1. The value can be null for reference types.</param>
        /// <returns>The object List[T]</returns>
        public static List<T> AddIf<T>(this List<T> source, Func<bool> predicate, T item)
        {
            if (predicate()) 
            {
                source.Add(item);
            }

            return source;
        }

        #endregion
    }
}

