using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductManagerTests.ModelsTests
{
    [TestClass]
    public class BrandTests : AssemblyLoader
    {
        private const string TYPE_NAME = "brand";
        private const string INTERFACE_NAME = "imodel";

        private List<Type> _constructorTypes;
        public BrandTests()
        {
            _constructorTypes = new List<Type>() { typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
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
        /// Vérifie si le type implémente l'intzerface imodel
        /// </summary>
        [TestMethod]
        public void TypeImplementInterfaceIModel()
        {
            Assert.IsNotNull(base.GetImplementedInterface(TYPE_NAME, INTERFACE_NAME));
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
        /// Vérifie si la propriété street existe
        /// </summary>
        [TestMethod]
        public void PropertyStreetExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "street"));
        }

        /// <summary>
        /// Vérifie si la propriété street est de type string
        /// </summary>
        [TestMethod]
        public void PropertyStreetIsTypeString()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "street") == typeof(string));
        }

        /// <summary>
        /// Vérifie si la propriété zip existe
        /// </summary>
        [TestMethod]
        public void PropertyZipExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "zip"));
        }

        /// <summary>
        /// Vérifie si la propriété zip est de type string
        /// </summary>
        [TestMethod]
        public void PropertyZipIsTypeString()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "zip") == typeof(string));
        }

        /// <summary>
        /// Vérifie si la propriété locality existe
        /// </summary>
        [TestMethod]
        public void PropertyLocalityExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "locality"));
        }

        /// <summary>
        /// Vérifie si la propriété locality est de type string
        /// </summary>
        [TestMethod]
        public void PropertyLocalityIsTypeString()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "locality") == typeof(string));
        }

        /// <summary>
        /// Vérifie si la propriété country existe
        /// </summary>
        [TestMethod]
        public void PropertyCountryExist()
        {
            Assert.IsNotNull(base.GetProperty(TYPE_NAME, "country"));
        }

        /// <summary>
        /// Vérifie si la propriété country est de type string
        /// </summary>
        [TestMethod]
        public void PropertyCountryIsTypeString()
        {
            Assert.IsTrue(base.GetPropertyType(TYPE_NAME, "country") == typeof(string));
        }

        /// <summary>
        /// Vérifie si la propriété id est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyIdCorrectlyInitialized()
        {
            int id = 1;
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { id, "test", "test", "test", "test", "test" });
            Assert.IsTrue((int)GetPropertyValue(TYPE_NAME, "id", obj) == id);
        }

        /// <summary>
        /// Vérifie si la propriété name est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyNameCorrectlyInitialized()
        {
            string name = "test";
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, name, "test", "test", "test", "test" });
            Assert.IsTrue((string)GetPropertyValue(TYPE_NAME, "name", obj) == name);
        }

        /// <summary>
        /// Vérifie si la propriété street est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyStreetCorrectlyInitialized()
        {
            string street = "street";
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", street, "test", "test", "test" });
            Assert.IsTrue((string)GetPropertyValue(TYPE_NAME, "street", obj) == street);
        }

        /// <summary>
        /// Vérifie si la propriété zip est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyZipCorrectlyInitialized()
        {
            string zip = "zip";
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", "test", zip, "test", "test" });
            Assert.IsTrue((string)GetPropertyValue(TYPE_NAME, "zip", obj) == zip);
        }

        /// <summary>
        /// Vérifie si la propriété locality est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyLocalityCorrectlyInitialized()
        {
            string locality = "locality";
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", "test", "test", locality, "test" });
            Assert.IsTrue((string)GetPropertyValue(TYPE_NAME, "locality", obj) == locality);
        }

        /// <summary>
        /// Vérifie si la propriété country est correctement initialisée
        /// </summary>
        [TestMethod]
        public void PropertyCountryCorrectlyInitialized()
        {
            string country = "country";
            var obj = base.GetConstructorByTypes(TYPE_NAME, _constructorTypes).Invoke(new object[] { 1, "test", "test", "test", "test", country });
            Assert.IsTrue((string)GetPropertyValue(TYPE_NAME, "country", obj) == country);
        }


    }
}
