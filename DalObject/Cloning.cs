using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DalObject

{
    static class Cloning
    {
        internal static T Clone <T> (this T original)
        {
            T target = (T)Activator.CreateInstance(original.GetType());
            PropertyInfo[] propertyInfo = original.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo property in propertyInfo)
            {
                if (property.CanWrite)
                {
                    //לבדוק בהרצה שתנאי מתקיים עבור ENUM
                    if (property.PropertyType.IsValueType || property.PropertyType.Equals(typeof(string)))
                    {
                        property.SetValue(target, property.GetValue(original, null), null);
                    }
                    //if is refernce type or complex types 
                    else
                    {
                        T temp = (T)property.GetValue(original, null);
                        if (temp == null)
                        {
                            property.SetValue(target, null, null);
                        }
                        else
                        {
                            property.SetValue(target, temp.Clone(), null);
                        }
                    }
                }
            }
            return target;
        }
    }
}
