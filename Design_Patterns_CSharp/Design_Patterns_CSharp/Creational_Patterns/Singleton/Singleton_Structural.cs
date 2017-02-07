using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_CSharp.Singleton
{
    class Singleton_Structural
    {
        ///// <summary>
        ///// MainApp startup class for Structural
        ///// Singleton Design Pattern.
        ///// </summary>
        //class MainApp
        //{
        //    /// <summary>
        //    /// Entry point into console application.
        //    /// </summary>
        //    static void Main()
        //    {
        //        // Constructor is protected -- cannot use new
        //        Singleton s1 = Singleton.Instance();
        //        Singleton s2 = Singleton.Instance();

        //        // Test for same instance
        //        if (s1 == s2)
        //        {
        //            Console.WriteLine("Objects are the same instance");
        //        }

        //        // Wait for user
        //        Console.ReadKey();
        //    }
        //}

        /// <summary>
        /// The 'Singleton' class
        /// </summary>
        class Singleton
        {
            private static Singleton _instance;

            // Constructor is 'protected'
            protected Singleton()
            {
            }

            public static Singleton Instance()
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (_instance == null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }
    }
}
