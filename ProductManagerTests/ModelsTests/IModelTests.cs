using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductManagerTests.ModelsTests
{
    [TestClass]
    public class IModelTests : AssemblyLoader
    {
        private const string TYPE_NAME = "imodel";

        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsNotNull(base.GetType(TYPE_NAME));
        }

        /// <summary>
        /// Vérifie si le type est une interface
        /// </summary>
        [TestMethod]
        public void TypeIsInterface()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.IsInterface ?? false);
        }

        /// <summary>
        /// Vérifie si la propriété id existe
        /// </summary>
        [TestMethod]
        public void PropertyIdExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "id"));
        }

        /// <summary>
        /// Vérifie si la propriété id est de type int
        /// </summary>
        [TestMethod]
        public void PropertyIdIsTypeInt()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "id") == typeof(int));
        }
    }
}
