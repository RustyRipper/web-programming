using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7
{
    class Ex4
    {
        public static void test()
        {
            Console.WriteLine("\n4)\n");
            

            Department department2 = new Department(8, "WIZ");

            Object department = new Object[] { 4, "123"};

            System.Reflection.MethodInfo methodInfo = department.GetType().GetMethod("helloDepartment", new Type[] { typeof(string), typeof(string) });
            Object result = methodInfo.Invoke(department, new object[] { "Jan", "Kowalski" });
            Console.WriteLine($"Result = {result}");

            System.Reflection.MethodInfo methodInfo2 = department2.GetType().GetMethod("helloDepartment", new Type[] { typeof(string), typeof(string) });
            string result2 = (string)methodInfo2.Invoke(department2, new object[] { "Kuba", "Kowalski" });
            Console.WriteLine($"Result = {result2}");



        }
    }
}
