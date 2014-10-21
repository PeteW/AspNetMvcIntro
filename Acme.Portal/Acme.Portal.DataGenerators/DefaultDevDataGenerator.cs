using Acme.Portal.Core.Configuration;
using Acme.Portal.Core.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Extensions = Acme.Portal.Core.Utils.Extensions;

namespace Acme.Portal.DataGenerators
{
    [TestClass]
    public class DefaultDevDataGenerator
    {
        /// <summary>
        /// call this to clean out the appcontext databasecontext
        /// </summary>
        public static void ResetDatabaseContext()
        {
            //reset the CallContext to ensure a new database context is created with each test
            CallContext.SetData("AbilityPortalDbContext", null);
        }

        /// <summary>
        /// Execute sql non-query
        /// </summary>
        /// <param name="sql">The SQL.</param>
        public static void RunSql(string sql)
        {
            sql += "\n";//added by pete: we need to make sure there is a newline at the end of the file otherwise sql server gets confused on GO statements
            using (var connection = new SqlConnection(SettingsManager.MyAbilityConnectionString))
            {
                connection.Open();
                var sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.ExecuteNonQuery();
            }
            //call this to ensure the DBContext will be forcibly refreshed
            ResetDatabaseContext();
        }

        /// <summary>
        /// Run an embedded SQL script
        /// </summary>
        /// <param name="resourcePath"></param>
        public void RunScript(string resourcePath)
        {
            var sql = Extensions.GetStringFromEmbeddedResource(resourcePath, typeof(DefaultDevDataGenerator).Assembly);
            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] subScripts = sql.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            foreach (string subScript in subScripts)
            {
                try
                {
                    RunSql(subScript);
                }
                catch (Exception exp)
                {
                    throw new Exception(string.Format("Failure in script [{0}]: {1}", resourcePath, exp.ToString()));
                }
            }
        }

        /// <summary>
        /// Drop all database objects
        /// </summary>
        public void DeleteSchema()
        {
            RunScript("Acme.Portal.DataGenerators.SqlScripts.DestroyDatabase.sql");
        }

        /// <summary>
        /// Create Tables
        /// </summary>
        public void CreateSchema()
        {
            RunScript("Acme.Portal.DataGenerators.SqlScripts.CreateSchema.sql");
        }

        [TestMethod]
        public void BuildDatabase()
        {
            //1. call the delete database script
            DeleteSchema();

            //2. call the create database script
            CreateSchema();

            //3. populate the new database with objects
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Npi.Add(new Npi { Name = "Acura" });
                    context.Npi.Add(new Npi { Name = "BMW" });
                    context.Npi.Add(new Npi { Name = "Cadillac" });
                    context.Npi.Add(new Npi { Name = "Dodge" });
                    context.Npi.Add(new Npi { Name = "Ford" });
                    context.Npi.Add(new Npi { Name = "Honda" });
                    context.Npi.Add(new Npi { Name = "Infinity" });
                    context.Npi.Add(new Npi { Name = "Lexus" });
                    context.Npi.Add(new Npi { Name = "Mazda" });
                    context.Npi.Add(new Npi { Name = "Nissan" });
                    context.Npi.Add(new Npi { Name = "Porsche" });
                    context.Npi.Add(new Npi { Name = "Scion" });
                    context.Npi.Add(new Npi { Name = "Toyota" });
                    context.Npi.Add(new Npi { Name = "VW" });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
