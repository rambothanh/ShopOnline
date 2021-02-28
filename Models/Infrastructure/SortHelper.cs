using System;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Linq.Dynamic.Core
//using System.Linq.Dynamic;

namespace Models.Infrastructure
{
    public class SortHelper<T> : ISortHelper<T>
    {
        public IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString)
        {
            if (!entities.Any())
                return entities;

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return entities;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;
                //Order By Format: Property, Property2 ASC, Property2 DESC"
                var sortingOrder = param.ToLower().EndsWith(" desc") ? "DESC" : "ASC";
                //Console.WriteLine(sortingOrder);
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");

            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            //EX. OrderBy("Property1 ASC,Property2 DESC");
            // entities.OrderBy(x => x.Name).ThenByDescending(o => o.DateOfBirth);
            return entities.OrderBy(orderQuery);
        }

    }
}