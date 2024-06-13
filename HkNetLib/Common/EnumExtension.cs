using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HkNetLib.Common
{
    public static class EnumExtension
    {
        public static string GetDesc<T>(this T em) where T : Enum
        {
            Type type = em.GetType();
            FieldInfo fd = type.GetField(em.ToString());

            var num = Convert.ToInt32(em);
            if (fd == null)
            {
                return $"{num}";
            }                
            var firstAttr = fd.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            if(firstAttr == null) return $"{num}";

            return (firstAttr as DescriptionAttribute).Description;            
        }
    }
}
