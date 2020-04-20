using System;
using System.Reflection;
using System.Text;

namespace Reflexion_Quete_1
{
    public class ReflectedClass
    {
        private Int32 _id;
        private String Name { get; set; }
        public Int32 Code { get; set; }

        public ReflectedClass()
        {
            _id = 0;
            Name = String.Empty;
        }

        private void DoSomething()
        {
            Console.WriteLine("I am doing something ...");
        }
    }


    class ClassInspector
    {
        static void Main(string[] args)
        {
            Type objectType = typeof(ReflectedClass);
            GetAllProperties(objectType);
            GetAllFields(objectType);
            GetAllMethods(objectType);
            
        }

        private static void GetAllProperties(Type objectType)
        {
            Console.WriteLine("***** Properties *****");
            PropertyInfo[] pi = objectType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo prop in pi)
                Console.WriteLine("->{0} \n \t", prop.Name);
            Console.WriteLine("");

        }

        private static void GetAllFields(Type objectType)
        {
            Console.WriteLine("***** Fields *****");
            FieldInfo[] fi = objectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fi)
                Console.WriteLine("->{0} \n \t Private ? {1} \n \t Public ? {2} \n \t Static ? {3}", field.Name, field.IsPrivate, field.IsPublic, field.IsStatic);
            Console.WriteLine("");
        }

        private static void GetAllMethods(Type objectType)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = objectType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo m in mi)
                Console.WriteLine("->{0} \n \t Private ? {1} \n \t Public ? {2} \n \t Static ? {3}", m.Name, m.IsPrivate, m.IsPublic, m.IsStatic);
            Console.WriteLine("");
        }


        /*private static void DisplayAllAttributes(object reflected)
        {
            Type objectType = reflected.GetType();

            PropertyInfo[] properties = objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = objectType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fields = objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("Properties");
            foreach (var p in properties)
            {
                Console.WriteLine("\t" + p);
            }
            Console.WriteLine("Methods");
            foreach (var m in methods)
            {
                Console.WriteLine("\t" + m);
            }
            Console.WriteLine("Fields");
            foreach (var f in fields)
            {
                Console.WriteLine("\t" + f);
            }
        }*/
    }
}