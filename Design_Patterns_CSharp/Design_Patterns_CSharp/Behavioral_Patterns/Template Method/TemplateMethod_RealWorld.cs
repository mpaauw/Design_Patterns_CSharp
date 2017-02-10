using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Design_Patterns_CSharp.Behavioral_Patterns.Template_Method
{
    class TemplateMethod_RealWorld
    {
        ///// <summary>
        ///// MainApp startup class for Real-World 
        ///// Template Design Pattern.
        ///// </summary>
        //class MainApp
        //{
        //    /// <summary>
        //    /// Entry point into console application.
        //    /// </summary>
        //    static void Main()
        //    {
        //        DataAccessObject daoCategories = new Categories();
        //        daoCategories.Run();

        //        DataAccessObject daoProducts = new Products();
        //        daoProducts.Run();

        //        // Wait for user
        //        Console.ReadKey();
        //    }
        //}

        /// <summary>
        /// The 'AbstractClass' abstract class
        /// </summary>
        abstract class DataAccessObject
        {
            protected string connectionString;
            protected DataSet dataSet;

            public virtual void Connect()
            {
                // Make sure mdb is available to app
                connectionString =
                  "provider=Microsoft.JET.OLEDB.4.0; " +
                  "data source=..\\..\\..\\db1.mdb";
            }

            public abstract void Select();
            public abstract void Process();

            public virtual void Disconnect()
            {
                connectionString = "";
            }

            // The 'Template Method' 
            public void Run()
            {
                Connect();
                Select();
                Process();
                Disconnect();
            }
        }

        /// <summary>
        /// A 'ConcreteClass' class
        /// </summary>
        class Categories : DataAccessObject
        {
            public override void Select()
            {
                string sql = "select CategoryName from Categories";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
                  sql, connectionString);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Categories");
            }

            public override void Process()
            {
                Console.WriteLine("Categories ---- ");

                DataTable dataTable = dataSet.Tables["Categories"];
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["CategoryName"]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// A 'ConcreteClass' class
        /// </summary>
        class Products : DataAccessObject
        {
            public override void Select()
            {
                string sql = "select ProductName from Products";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
                  sql, connectionString);

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Products");
            }

            public override void Process()
            {
                Console.WriteLine("Products ---- ");
                DataTable dataTable = dataSet.Tables["Products"];
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["ProductName"]);
                }
                Console.WriteLine();
            }
        }
    }
}
