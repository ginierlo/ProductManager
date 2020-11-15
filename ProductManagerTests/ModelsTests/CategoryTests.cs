using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductManagerTests.ModelsTests
{
    [TestClass]
    public class CategoryTests : AssemblyLoader
    {
        private const string TYPE_NAME = "category";

        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsNotNull(base.GetType(TYPE_NAME));
        }

        /// <summary>
        /// Vérifie si c'est un enum
        /// </summary>
        [TestMethod]
        public void TypeIsEnum()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.IsEnum ?? false);
        }

        /// <summary>
        /// Vérifie si'il contient au moins 6 valeurs
        /// </summary>
        [TestMethod]
        public void ContainsAtLeast6Values()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.GetEnumValues()?.Length >= 6);
        }
    }
}
