using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductManagerTests.ModelsTests
{
    [TestClass]
    public class ProductTests : AssemblyLoader
    {
        private const string TYPE_NAME = "product";
        private const string INTERFACE_NAME = "imodel";

        private List<Type> _constructorTypes; 
        public ProductTests()
        {
            _constructorTypes = new List<Type>() { typeof(int), typeof(string), base.GetType("brand"), base.GetType("category"), typeof(decimal), typeof(decimal) };
        }

        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsNotNull(base.GetType(TYPE_NAME));
        }

        /// <summary>
        /// Vérifie si le constructeur exis^te avec les bon paramètres
        /// </summary>
        [TestMethod]
        public void ConstructorExist()
        {
            Assert.IsNotNull(base.GetConstructorByTypes(TYPE_NAME, _constructorTypes));
        }

        /// <summary>
        /// Vérifie si le type implémente l'intzerface imodel
        /// </summary>
        [TestMethod]
        public void TypeImplementInterfaceIModel()
        {
            Assert.IsNotNull(base.GetImplementedInterface(TYPE_NAME, INTERFACE_NAME));
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

        /// <summary>
        /// Vérifie si la propriété name existe
        /// </summary>
        [TestMethod]
        public void PropertyNameExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "name"));
        }

        /// <summary>
        /// Vérifie si la propriété name est de type string
        /// </summary>
        [TestMethod]
        public void PropertyNameIsTypeString()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "name") == typeof(string));
        }

        /// <summary>
        /// Vérifie si la propriété brand existe
        /// </summary>
        [TestMethod]
        public void PropertyBrandExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "brand"));
        }

        /// <summary>
        /// Vérifie si la propriété brand est de type brand
        /// </summary>
        [TestMethod]
        public void PropertyBrandIsTypeBrand()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "brand") == base.GetType("brand"));
        }

        /// <summary>
        /// Vérifie si la propriété category existe
        /// </summary>
        [TestMethod]
        public void PropertyCategoryExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "category"));
        }

        /// <summary>
        /// Vérifie si la propriété category est de type category
        /// </summary>
        [TestMethod]
        public void PropertyCategoryIsTypeCategory()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "category") == base.GetType("category"));
        }

        /// <summary>
        /// Vérifie si la propriété weight existe
        /// </summary>
        [TestMethod]
        public void PropertyWeightExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "weight"));
        }

        /// <summary>
        /// Vérifie si la propriété id weight de type decimal
        /// </summary>
        [TestMethod]
        public void PropertyWeightIsTypedecimal()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "weight") == typeof(decimal));
        }

        /// <summary>
        /// Vérifie si la propriété price existe
        /// </summary>
        [TestMethod]
        public void PropertyPriceExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "price"));
        }

        /// <summary>
        /// Vérifie si la propriété price est de type decimal
        /// </summary>
        [TestMethod]
        public void PropertyPriceIsTypeDecimal()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "price") == typeof(decimal));
        }

        /// <summary>
        /// Vérifie si la propriété id est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyIdCorrectlyInitialized()
        {
            int id = 1;
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { id, "test", null, null, 0m, 0m });
            Assert.IsTrue((int)GetPropertyValue(TYPE_NAME, "id", obj) == id);
        }

        /// <summary>
        /// Vérifie si la propriété name est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyNameCorrectlyInitialized()
        {
            string name = "test";
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, name, null, null, 0m, 0m });
            Assert.IsTrue((string)GetPropertyValue(TYPE_NAME, "name", obj) == name);
        }

        /// <summary>
        /// Vérifie si la propriété brand est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyBrandCorrectlyInitialized()
        {
            var brand = base.GetConstructorByTypes("brand", new List<Type>() { typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) }).Invoke(new object[] { 1, "test", "test", "test", "test", "test" });
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", brand, null, 0m, 0m });
            Assert.IsTrue(GetPropertyValue(TYPE_NAME, "brand", obj) == brand);
        }

        /// <summary>
        /// Vérifie si la propriété category est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyCategoryCorrectlyInitialized()
        {
            var category = base.GetType("category").GetEnumValues().GetValue(0);
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", null, category, 0m, 0m });
            Assert.IsTrue(GetPropertyValue(TYPE_NAME, "category", obj).ToString() == category.ToString());
        }

        /// <summary>
        /// Vérifie si la propriété weight est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyWeightCorrectlyInitialized()
        {
            decimal weight = 1.1m;
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", null, null, weight, 0m });
            Assert.IsTrue((decimal)GetPropertyValue(TYPE_NAME, "weight", obj) == weight);
        }

        /// <summary>
        /// Vérifie si la propriété price est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyPriceCorrectlyInitialized()
        {
            decimal price = 1.1m;
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", null, null, 0m, price });
            Assert.IsTrue((decimal)GetPropertyValue(TYPE_NAME, "price", obj) == price);
        }
    }
}
