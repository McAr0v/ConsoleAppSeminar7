using System.IO.Pipes;
using System.Reflection;
using System.Text;

namespace ConsoleAppSeminar7
{
    internal class Program
    {
 
        static void Main(string[] args)
        {
                      
            char[] someArr = { 'a', 'b', 'c' };
            var n3 = MakeTestClass(6, "Текст 1", 1, someArr);

            Console.WriteLine(ObjectToString(n3));

            string temp = ObjectToString(n3);           

        }
                
        public static object StringToObject(string s) 
        {
            string[]arr = s.Split('|');
            string[]array = arr[0].Split(",");
            
            object some = Activator.CreateInstance( null, array[0]);

            if (array.Length > 1 && some != null)
            {
                var type = some.GetType();
                for (int i = 1; i < array.Length; i++)
                {
                    string[] nameAndValue = array[i].Split(":");
                    
                    var p = type.GetProperty(nameAndValue[0]);

                    if (p != null) {

                        if (p.PropertyType == typeof(string))
                        {
                            p.SetValue(some, nameAndValue[1]);
                        }
                        else if (p.PropertyType == typeof(int))
                        {
                            p.SetValue(some, int.Parse(nameAndValue[1]));
                        }
                        else if (p.PropertyType == typeof(decimal))
                        {
                            p.SetValue(some, decimal.Parse(nameAndValue[1]));

                        }
                        else if (p.PropertyType == typeof(char[]))
                        {
                            p.SetValue(some, nameAndValue[1].ToCharArray());
                        }

                    }
                }
            }

            return some;
            
        }
        static string ObjectToString(object o) 
        {
            Type type = o.GetType();
            
            StringBuilder res = new StringBuilder();

            //res = res.Append(type.AssemblyQualifiedName + ":");
            //res = res.Append(type.Name + "|");
            
            var properties = type.GetProperties();
            
            foreach (var item in properties)
            {
                var temp = item.GetValue(o);
                var customNameAttr = item.GetCustomAttribute<CustomNameAttribute>();

                if (customNameAttr != null)
                {
                    res.Append(customNameAttr.CustomFieldName + ':');
                }
                else
                {
                    res.Append(item.Name + ':');
                }

                if (item.PropertyType == typeof(char[]))
                {
                    res.Append(new string(temp as char[]) + '|');
                }
                else
                {
                    res = res.Append(temp);
                    res = res.Append('|');
                }
            }
            return res.ToString();
        }

        public static TestClass MakeTestClass()
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass) as TestClass;
        }

        public static TestClass MakeTestClass(int i)
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass, new object[] { i }) as TestClass;
        }

        public static TestClass MakeTestClass(int i, string s, decimal d, char[] c)
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass, new object[] { i, s, d, c }) as TestClass;
        }

    }
}