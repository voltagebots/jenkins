using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrocedyAPI.Helpers
{
    public static class AsyncList
    {
        public static async Task<bool> AnyAsync<T>(
            this IEnumerable<T> source, Func<T, Task<bool>> func)
        {
            foreach (var element in source)
            {
                if (await func(element))
                    return true;
            }
            return false;
        }
    }
}
