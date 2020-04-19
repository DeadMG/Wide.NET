using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wide.Util
{
    public static class Equality
    {
        public interface ReferenceEqual {}

        public static bool DeepEqual<T>(T obj1, T obj2)
        {
            if (obj1.GetType() != obj2.GetType())
                return false;

            if (Object.ReferenceEquals(obj1, obj2))
                return true;

            if (typeof(T).Namespace.StartsWith("System"))
                return obj1.Equals(obj2);

            if (typeof(T).GetInterfaces().Any(t => t == typeof(ReferenceEqual)))
                return false;

            var props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanRead);
            return props.All(p => DeepEqual(p.GetValue(obj1), p.GetValue(obj2)));
        }
    }
}
