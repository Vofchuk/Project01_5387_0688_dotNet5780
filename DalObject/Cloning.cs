using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dal

{
    static class Cloning
    {
        internal static T Clone <T> (this T original)
        {
            T target = (T)Activator.CreateInstance(original.GetType());
            var Infos = original.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var info in Infos)
            {
                    //לבדוק בהרצה שתנאי מתקיים עבור ENUM
                    if (info.FieldType.IsValueType || info.FieldType.Equals(typeof(string)))
                    {
                        info.SetValue(target, info.GetValue(original));
                    }
                    //if is refernce type or complex types 
                    else
                    {
                        T temp = (T)info.GetValue(original);
                        if (temp == null)
                        {
                            info.SetValue(target, null);
                        }
                        else
                        {
                            info.SetValue(target, temp.Clone());
                        }
                    }
            }
            return target;
        }
    }
}
