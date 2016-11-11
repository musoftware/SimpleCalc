using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleCalc
{
    class EquationV2
    {

        public static double Compute(string expression)
        {
           
            var methodsGroup = typeof(Math).GetMethods();
            string[] methods = (from MethodInfo di in methodsGroup
                                select di.Name).ToArray();

            string updatedExpression = Regex.Replace(expression, @"(?<func>" +
                string.Join("|", methods) + @")\((?<arg>.*?)\)", (Match match) =>
            {
                string intFunc = match.Groups["func"].Value;

                MethodInfo currentMethod = null;

                foreach (var item in methodsGroup)
                    if (intFunc == item.Name)
                        currentMethod = item;

                if (currentMethod == null) return "0";

                object[] values = new object[0];
                if (match.Groups["arg"].Value.Contains(","))
                {
                    values = match.Groups["arg"].Value.Split(',').Cast<object>().ToArray();

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = ToType(values[i], (currentMethod.GetParameters()[i]).ParameterType);
                    }
                }
                else
                    values = new object[] { ToType(match.Groups["arg"].Value, currentMethod.GetParameters()[0].ParameterType) };

                return currentMethod.Invoke(null, values).ToString();

            }).ToString();
            var result = new DataTable().Compute(updatedExpression, null);
            return double.Parse(result.ToString());
        }

        private static object ToType(object p, Type t)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(t);
                if (converter.ConvertFrom(p) == null)
                {
                    return p;
                }
                else
                {
                    return converter.ConvertFrom(p);
                }
            }
            catch
            {
                return p;
            }
        }


    }
}
