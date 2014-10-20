using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Portal.Core.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Portal.DataGenerators
{
    [TestClass]
    public class DefaultDevDataGenerator
    {
        [TestMethod]
        public void BuildDatabase()
        {
            //1. call the delete database script
            //2. call the create database script
            //3. populate the new database with objects
            using (var context = new DatabaseContext())
            {
                context.Npis.Add(new Npi() {Name = "foo"});
                context.Npis.Add(new Npi() {Name = "bar"});
                context.SaveChanges();
            }
        }
    }
}
