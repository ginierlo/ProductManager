using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagerTests.ControllersTests
{
    [TestClass]
    public class BrandControllerTests : AssemblyLoader
    {
        private const string TYPE_NAME = "brandcontroller";

        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsNotNull(base.GetType(TYPE_NAME));
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée create
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodCreate()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "create"));
        }

        /// <summary>
        /// Vérifie que la méthode create retourne un type void
        /// </summary>
        [TestMethod]
        public void MethodCreateReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "create")?.ReturnType == typeof(void));
        }

        /// <summary>
        /// Vérifie que la méthode create contienne seulement 5 paramètre
        /// </summary>
        [TestMethod]
        public void MethodCreateContainsFiveParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "create").Count == 5);
        }

        /// <summary>
        /// Vérifie que la méthode create ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodCreateHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "create");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée getall
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGetAll()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "getall"));
        }

        /// <summary>
        /// Vérifie que la méthode getall retourne un type list de brand
        /// </summary>
        [TestMethod]
        public void MethodGetAllReturnTypeIsListOfBrand()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "getall")?.ReturnType.ToString().Contains($"List`1[{base.GetType("brand").FullName}]") ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getall contienne 0 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGetAllontainsNoParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "getall").Count == 0);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée update
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodUpdate()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "update"));
        }

        /// <summary>
        /// Vérifie que la méthode update retourne un type void
        /// </summary>
        [TestMethod]
        public void MethodUpdateReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "update")?.ReturnType == typeof(void));
        }

        /// <summary>
        /// Vérifie que la méthode update contienne seulement 5 paramètre
        /// </summary>
        [TestMethod]
        public void MethodUpdateContainsFiveParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "update").Count == 6);
        }

        /// <summary>
        /// Vérifie que la méthode update ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodUpdateHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "update");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée delete
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodDelete()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "delete"));
        }

        /// <summary>
        /// Vérifie que la méthode delete retourne un type void
        /// </summary>
        [TestMethod]
        public void MethodDeleteReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "delete")?.ReturnType == typeof(void));
        }

        /// <summary>
        /// Vérifie que la méthode delete contienne seulement 5 paramètre
        /// </summary>
        [TestMethod]
        public void MethodDeleteContainsFiveParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "delete").Count == 1);
        }

        /// <summary>
        /// Vérifie que la méthode delete ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodDeleteHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { typeof(int) };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "delete");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }


        /// <summary>
        /// Vérifie qu'arpès l'appel de la méthode create, la liste contient 1 élément
        /// </summary>
        [TestMethod]
        public void InvokeMethodCreateShouldAddOneElementToList()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] {"test", "test", "test", "test", "test" });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 1);
        }

        /// <summary>
        /// Vérifie qu'arpès l'ajout d'un élément déjà existant la liste contienne qu'un seul élément
        /// </summary>
        [TestMethod]
        public void CreateExistingElementShouldNotBeAddedToList()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] {"test", "test", "test", "test", "test" });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] {"test", "test", "test", "test", "test" });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 1);
        }

        /// <summary>
        /// Vérifie qu'arpès l'ajout de 2 éléments le 2ème ait l'id 2
        /// </summary>
        [TestMethod]
        public void Create2ElementsShouldIncrementId()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] {"test", "test", "test", "test", "test" });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] {"test2", "test2", "test2", "test2", "test2" });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            var lastElement = ((IEnumerable<object>)list).Last();

            Assert.IsTrue((int)base.GetProperty(lastElement.GetType(), "id").GetValue(lastElement) == 2);
        }

        /// <summary>
        /// Vérifie que la supression d'un élément existant fonctionne
        /// </summary>
        [TestMethod]
        public void DeleteExistingElementShouldReturnEmptyList()
        {
            int id = 1;
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", "test", "test", "test", "test" });

            base.GetMethod(TYPE_NAME, "delete").Invoke(controller, new object[] { id });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 0);
        }

        /// <summary>
        /// Vérifie que la liste contienne toujours un élément après la suppression d'un id inexistant
        /// </summary>
        [TestMethod]
        public void DeleteNonExistingElementShouldReturnListWithOneElement()
        {
            int id = 2;
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", "test", "test", "test", "test" });

            base.GetMethod(TYPE_NAME, "delete").Invoke(controller, new object[] { id });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 1);
        }

        /// <summary>
        /// vérifie que la liste contienne 0 élément lorsque l'on supprimer et que la liste est vide
        /// </summary>
        [TestMethod]
        public void DeleteWithEmptyListShouldReturnEmptyList()
        {
            int id = 1;
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            base.GetMethod(TYPE_NAME, "delete").Invoke(controller, new object[] { id });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 0);
        }

        /// <summary>
        /// Vérifie que la méthode getall retourn 1 élément après l'ajout d'un élément
        /// </summary>
        [TestMethod]
        public void GetAllShouldReturn1ElementWithOneEWlementInList()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", "test", "test", "test", "test" });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getall retourn 0 quand le liste est vide
        /// </summary>
        [TestMethod]
        public void GetAllShouldReturn0ElementWithEmptyList()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 0);
        }

        /// <summary>
        /// Modification de l'élément avec id existant est bien effectuée
        /// </summary>
        [TestMethod]
        public void UpdateElementWithExistingIdShouldBeEffective()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", "test", "test", "test", "test" });

            base.GetMethod(TYPE_NAME, "update").Invoke(controller, new object[] { 1, "test2", "test2", "test2", "test2", "test2" });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            var lastElement = ((IEnumerable<object>)list).Last();

            Assert.IsTrue(base.GetProperty(lastElement.GetType(), "name").GetValue(lastElement).ToString() == "test2");
        }

        /// <summary>
        /// Modification de l'élément avec id existant n'est pas effectuée
        /// </summary>
        [TestMethod]
        public void UpdateElementWithNonExistingIdShouldNotBeEffective()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", "test", "test", "test", "test" });

            base.GetMethod(TYPE_NAME, "update").Invoke(controller, new object[] { 2, "test2", "test2", "test2", "test2", "test2" });

            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            var lastElement = ((IEnumerable<object>)list).Last();

            Assert.IsTrue(base.GetProperty(lastElement.GetType(), "name").GetValue(lastElement).ToString() == "test");
        }
    }
}
