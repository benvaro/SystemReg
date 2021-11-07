using Microsoft.Win32;
using System;

namespace SystemReg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Registry
            // RegistryKey

            RegistryKey key = Registry.CurrentUser;
            var newKey = key.CreateSubKey("Test");

            newKey = key.OpenSubKey("Test", true);
            var subKey = newKey.CreateSubKey("Config");
            subKey.SetValue("login", "admin");
            subKey.SetValue("password", 5666);
            newKey.SetValue("Hello", "World");
            subKey.Close();
            newKey.Close();

            // PrintKeyInformation(key);

            var run = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            var items = run.GetValueNames();
            foreach (var item in items)
            {
                if (item.Contains("Viber"))
                {
                    run.DeleteValue(item);
                    continue;
                }

                Console.WriteLine($"{item, -25}{run.GetValueKind(item), -25}{run.GetValue(item)}");
            }
        }

        private static void PrintKeyInformation(RegistryKey key)
        {
            string[] names = key.GetSubKeyNames();//.ToList();
            Console.WriteLine($"Subkey of {key.Name}:");

            Array.ForEach(names, (x) => Console.WriteLine(x));
            //names.ForEach((x) => Console.WriteLine(x)); // names must be a List

            //foreach (var item in names)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
