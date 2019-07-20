using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Helpers
{
    public static class ConvertCollectionToDictionary
    {
        public static IDictionary<string, string> ToDictionary(this IFormCollection col)
        {
            var dict = new Dictionary<string, string>();

            foreach (var key in col.Keys)
            {
                dict.Add(key, col[key]);
            }

            return dict;
        }
    }
}
