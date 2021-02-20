using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Informatiz.ControleEstoque.Comum.Extencoes
{
    public static class CloneExtension
    {
       
        public static T Clone<T>(this T S)
        {
            T newObj = Activator.CreateInstance<T>();

            foreach (PropertyInfo i in newObj.GetType().GetProperties())
            {

                //"EntitySet" is specific to link and this conditional logic is optional/can be ignored
                if (i.CanWrite && i.PropertyType.Name.Contains("EntitySet") == false)
                {
                    object value = S.GetType().GetProperty(i.Name).GetValue(S, null);
                    i.SetValue(newObj, value, null);
                }
            }

            return newObj;
        }
    }
}
