using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteWarehouse.Extensions
{
    public static class IEnumberableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T> (this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem //this is a real function type
                   {
                       Text = item.GetPropertyValue("Name"), //Reflection to get the property
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString()) // in the other class ReflectionExtension.cs
                   };
        }
    }
}
