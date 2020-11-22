using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagerTests.ControllersTests
{
    [TestClass]
    public class ProductControllerTests : AssemblyLoader
    {
        private const string TYPE_NAME = "productcontroller";

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
            var rightTypes = new List<Type>() { typeof(string), base.GetType("brand"), base.GetType("category"), typeof(decimal), typeof(decimal) };
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
        /// Vérifie que la méthode getall retourne un type list de product
        /// </summary>
        [TestMethod]
        public void MethodGetAllReturnTypeIsListOfBrand()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "getall")?.ReturnType.ToString().Contains($"List`1[{base.GetType("product").FullName}]") ?? false);
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
            var rightTypes = new List<Type>() { typeof(int), typeof(string), base.GetType("brand"), base.GetType("category"), typeof(decimal), typeof(decimal) };
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
            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m});

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });

            base.GetMethod(TYPE_NAME, "update").Invoke(controller, new object[] { 1, "test2", brand, category, 2m, 2m });

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

            var brand = CreateTestBrand(0, "test", "test", "test", "test", "test");
            var category = GetCategoryEnumValue();

            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });

            base.GetMethod(TYPE_NAME, "update").Invoke(controller, new object[] { 2, "test2", brand, category, 2m, 2m });


            var list = base.GetMethod(TYPE_NAME, "getall").Invoke(controller, null);

            var lastElement = ((IEnumerable<object>)list).Last();

            Assert.IsTrue(base.GetProperty(lastElement.GetType(), "name").GetValue(lastElement).ToString() == "test");
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée getallbybrand
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGetAllByBrand()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "getallbybrand"));
        }

        /// <summary>
        /// Vérifie que la méthode getallbybrand retourne un type list de product
        /// </summary>
        [TestMethod]
        public void MethodGetAllByBrandReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "getallbybrand")?.ReturnType.ToString().Contains($"List`1[{base.GetType("product").FullName}]") ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getallbybrand contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGetAllByBrandContainsOneParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "getallbybrand").Count == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getallbybrand ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetAllByBrandHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { typeof(int) };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "getallbybrand");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }

        /// <summary>
        /// Vérifie que la méthode getallbybrand avec id de brand retourne 2 éléments
        /// </summary>
        [TestMethod]
        public void MethodGetAllByBrandShouldReturnTwoElements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création d'un objet category
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même brand
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Apelle de la méthode avec id de brand
            var list = base.GetMethod(TYPE_NAME, "getallbybrand").Invoke(controller, new object[] { base.GetProperty(brand.GetType(), "id").GetValue(brand) });

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 2);
        }


        /// <summary>
        /// Vérifie que la méthode getallbybrand avec id de brand2 retourne 1 éléments
        /// </summary>
        [TestMethod]
        public void MethodGetAllByBrandShouldReturnOneElements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création d'un objet category
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même brand
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Apelle de la méthode avec id de brand2
            var list = base.GetMethod(TYPE_NAME, "getallbybrand").Invoke(controller, new object[] { base.GetProperty(brand2.GetType(), "id").GetValue(brand2) });

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getallbybrand avec id inexistant retourne 0 éléments
        /// </summary>
        [TestMethod]
        public void MethodGetAllByBrandShouldReturnNoElements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création d'un objet category
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même brand
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Apelle de la méthode avec id inexsitant
            var list = base.GetMethod(TYPE_NAME, "getallbybrand").Invoke(controller, new object[] { 6 });

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 0);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée getsumbybrand
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGetSumByBrand()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "getsumbybrand"));
        }

        /// <summary>
        /// Vérifie que la méthode getsumbybrand retourne un type decimal
        /// </summary>
        [TestMethod]
        public void MethodGetSumByBrandReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "getsumbybrand")?.ReturnType == typeof(decimal));
        }

        /// <summary>
        /// Vérifie que la méthode getsumbybrand contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGetSumByBrandContainsOneParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "getsumbybrand").Count == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getsumbybrand ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetSumByBrandHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { typeof(int) };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "getsumbybrand");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }

        /// <summary>
        /// Vérifie que la méthode getsumbybrand avec id brand retourne 8
        /// </summary>
        [TestMethod]
        public void MethodGetSumByBrandShouldReturn8()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création d'un objet category
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même brand
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 4m, 4m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 4m, 4m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Appel de la méthode avec id de brand
            var sum = decimal.Parse(base.GetMethod(TYPE_NAME, "getsumbybrand").Invoke(controller, new object[] { base.GetProperty(brand.GetType(), "id").GetValue(brand) }).ToString());

            Assert.IsTrue(sum == 8m);
        }

        /// <summary>
        /// Vérifie que la méthode getsumbybrand avec id brand2 retourne 2
        /// </summary>
        [TestMethod]
        public void MethodGetSumByBrandShouldReturn2()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création d'un objet category
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même brand
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 4m, 4m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 4m, 4m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Appel de la méthode avec id de brand2
            var sum = decimal.Parse(base.GetMethod(TYPE_NAME, "getsumbybrand").Invoke(controller, new object[] { base.GetProperty(brand2.GetType(), "id").GetValue(brand2) }).ToString());

            Assert.IsTrue(sum == 2m);
        }

        /// <summary>
        /// Vérifie que la méthode getsumbybrand avec id inexsitant retourne 0
        /// </summary>
        [TestMethod]
        public void MethodGetSumByBrandShouldReturn0()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création d'un objet category
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même brand
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 4m, 4m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 4m, 4m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Appel de la méthode avec id inexistant
            var sum = decimal.Parse(base.GetMethod(TYPE_NAME, "getsumbybrand").Invoke(controller, new object[] { 6 }).ToString());

            Assert.IsTrue(sum == 0m);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée getallbycategory
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGetAllByCategory()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "getallbycategory"));
        }

        /// <summary>
        /// Vérifie que la méthode getallbycategory retourne un type list de product
        /// </summary>
        [TestMethod]
        public void MethodGetAllByCategoryReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "getallbycategory")?.ReturnType.ToString().Contains($"List`1[{base.GetType("product").FullName}]") ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getallbycategory contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGetAllByCategoryContainsOneParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "getallbycategory").Count == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getallbycategory ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetAllByCategoryHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { base.GetType("category") };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "getallbycategory");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }

        /// <summary>
        /// Vérifie que la méthode getallbycategory avec category retourne 2 éléments
        /// </summary>
        [TestMethod]
        public void MethodGetAllByCategoryShouldReturnTwoElements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 4 category différents
            var category = GetCategoryEnumValue();
            var category1 = GetCategoryEnumValue(1);
            var category2 = GetCategoryEnumValue(2);
            var category3 = GetCategoryEnumValue(3);

            // creation de 1 brand
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
  
            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand, category1, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand, category2, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand, category3, 2m, 2m });

            // Apelle de la méthode avec id de brand
            var list = base.GetMethod(TYPE_NAME, "getallbycategory").Invoke(controller, new object[] { category });

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 2);
        }


        /// <summary>
        /// Vérifie que la méthode getallbycategory avec category1 retourne 1 éléments
        /// </summary>
        [TestMethod]
        public void MethodGetAllByCategoryShouldReturnOneElements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 4 category différents
            var category = GetCategoryEnumValue();
            var category1 = GetCategoryEnumValue(1);
            var category2 = GetCategoryEnumValue(2);
            var category3 = GetCategoryEnumValue(3);

            // creation de 1 brand
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand, category1, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand, category2, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand, category3, 2m, 2m });

            // Apelle de la méthode avec id de brand2
            var list = base.GetMethod(TYPE_NAME, "getallbycategory").Invoke(controller, new object[] { category1 });

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getallbycategory avec category inexsitant retourne 0 éléments
        /// </summary>
        [TestMethod]
        public void MethodGetAllByCategoryShouldReturnNoElements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 4 category différents
            var category = GetCategoryEnumValue();
            var category1 = GetCategoryEnumValue(1);
            var category2 = GetCategoryEnumValue(2);
            var category3 = GetCategoryEnumValue(3);

            // creation de 1 brand
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand, category1, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand, category2, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand, category3, 2m, 2m });

            // Apelle de la méthode avec category inexsitant
            var list = base.GetMethod(TYPE_NAME, "getallbycategory").Invoke(controller, new object[] { GetCategoryEnumValue(4) });

            Assert.IsTrue(((IEnumerable<object>)list).Count() == 0);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée groupallbybrand
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGroupAllByBrand()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "groupallbybrand"));
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrand retourne un type dictionnaire key: brand value: list de product
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandReturnTypeIsVoid()
        {

            var listType = typeof(List<>);
            var list = listType.MakeGenericType(GetType("product"));

            var dictionaryType = typeof(Dictionary<,>);
            var dictionary = dictionaryType.MakeGenericType(GetType("brand"), list);

            Assert.IsTrue(base.GetMethod(TYPE_NAME, "groupallbybrand")?.ReturnType == dictionary);
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrand contienne seulement 0 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandContainsNoParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "groupallbybrand").Count == 0);
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrand doit retourner un dictionary contant 4 élements et dont 1 contient 2 product
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandShouldReturn4ElementsAndOneValueShouldContain2Elements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 1 category 
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Apelle de la méthode
            var result = base.GetMethod(TYPE_NAME, "groupallbybrand").Invoke(controller, null);

            var dictionary = (result as IDictionary);
            Assert.IsTrue(dictionary.Count == 4);
            Assert.IsTrue((dictionary[brand] as IList).Count == 2);
            Assert.IsTrue((dictionary[brand2] as IList).Count == 1);
            Assert.IsTrue((dictionary[brand3] as IList).Count == 1);
            Assert.IsTrue((dictionary[brand4] as IList).Count == 1);
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrand doit retourner un dictionary contant 4 élements et toutes les valeurs contiennent 1 élément
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandShouldReturn4ElementsAndAllValueContainOnly1Element()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 1 category 
            var category = GetCategoryEnumValue();

            // creation de 4 brand différents
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");
            var brand2 = CreateTestBrand(2, "test2", "test", "test", "test", "test");
            var brand3 = CreateTestBrand(3, "test3", "test", "test", "test", "test");
            var brand4 = CreateTestBrand(4, "test4", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand2, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand3, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand4, category, 2m, 2m });

            // Apelle de la méthode
            var result = base.GetMethod(TYPE_NAME, "groupallbybrand").Invoke(controller, null);

            var dictionary = (result as IDictionary);
            Assert.IsTrue(dictionary.Count == 4);
            Assert.IsTrue((dictionary[brand] as IList).Count == 1);
            Assert.IsTrue((dictionary[brand2] as IList).Count == 1);
            Assert.IsTrue((dictionary[brand3] as IList).Count == 1);
            Assert.IsTrue((dictionary[brand4] as IList).Count == 1);
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrand doit retourner un dictionary contant 1 élements et sa valeur contient 4 éléments
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandShouldReturn1ElementAndValueContain4Elements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 1 category 
            var category = GetCategoryEnumValue();

            // creation de 1 brand
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand, category, 2m, 2m });

            // Apelle de la méthode
            var result = base.GetMethod(TYPE_NAME, "groupallbybrand").Invoke(controller, null);

            var dictionary = (result as IDictionary);
            Assert.IsTrue(dictionary.Count == 1);
            Assert.IsTrue((dictionary[brand] as IList).Count == 4);
        }


        /// <summary>
        /// Vérifie que le type contienne une méthode nommée groupallbybrandandorderbyprice
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGroupAllByBrandAndOrderByPriceAndOrderByPrice()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "groupallbybrandandorderbyprice"));
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrandandorderbyprice retourne un type dictionnaire key: brand value: list de product
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandAndOrderByPriceReturnTypeIsVoid()
        {

            var listType = typeof(List<>);
            var list = listType.MakeGenericType(GetType("product"));

            var dictionaryType = typeof(Dictionary<,>);
            var dictionary = dictionaryType.MakeGenericType(GetType("brand"), list);

            Assert.IsTrue(base.GetMethod(TYPE_NAME, "groupallbybrandandorderbyprice")?.ReturnType == dictionary);
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrandandorderbyprice contienne seulement 0 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandAndOrderByPriceContainsNoParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "groupallbybrandandorderbyprice").Count == 0);
        }

        /// <summary>
        /// Vérifie que la méthode groupallbybrandandorderbyprice doit retourner un dictionary contant 1 élements et sa valeur contient 4 éléments ordonné par la propriété price
        /// </summary>
        [TestMethod]
        public void MethodGroupAllByBrandAndOrderByPriceShouldReturn1ElementAndValueContain4ElementsOrdered()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 1 category 
            var category = GetCategoryEnumValue();

            // creation de 1 brand
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");

            // création de 5 product donc 2 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 8m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand, category, 2m, 20m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand, category, 2m, 5m });

            // Apelle de la méthode
            var result = base.GetMethod(TYPE_NAME, "groupallbybrandandorderbyprice").Invoke(controller, null);

            var dictionary = (result as IDictionary);
            var list = (dictionary[brand] as IList);
            Assert.IsTrue(dictionary.Count == 1);
            Assert.IsTrue(list.Count == 4);
            Assert.IsTrue((decimal)list[0].GetType().GetProperty("Price").GetValue(list[0]) == 2m);
            Assert.IsTrue((decimal)list[1].GetType().GetProperty("Price").GetValue(list[1]) == 5m);
            Assert.IsTrue((decimal)list[2].GetType().GetProperty("Price").GetValue(list[2]) == 8m);
            Assert.IsTrue((decimal)list[3].GetType().GetProperty("Price").GetValue(list[3]) == 20m);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée getallproductbycategoryunderprice
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGetAllProductByCategoyUnderPrice()
        {
            Assert.IsNotNull(base.GetMethod(TYPE_NAME, "getallproductbycategoryunderprice"));
        }

        /// <summary>
        /// Vérifie que la méthode getallproductbycategoryunderprice retourne un type list de product
        /// </summary>
        [TestMethod]
        public void MethodGetAllProductByCategoyUnderPriceReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetMethod(TYPE_NAME, "getallproductbycategoryunderprice")?.ReturnType.ToString().Contains($"List`1[{base.GetType("product").FullName}]") ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getallproductbycategoryunderprice contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethodGetAllProductByCategoyUnderPriceContainsOneParameter()
        {
            Assert.IsTrue(base.GetMethodParameters(TYPE_NAME, "getallproductbycategoryunderprice").Count == 2);
        }

        /// <summary>
        /// Vérifie que la méthode getallproductbycategoryunderprice ait les bons types de paramètres
        /// </summary>
        [TestMethod]
        public void MethodGetAllProductByCategoyUnderPriceHasRightParametersTypes()
        {
            bool check = true;
            var rightTypes = new List<Type>() { base.GetType("category"), typeof(decimal) };
            var paramTypes = base.GetMethodParametersTypes(TYPE_NAME, "getallproductbycategoryunderprice");

            for (int i = 0; i < rightTypes.Count; i++)
            {
                if (rightTypes[i] != paramTypes[i])
                    check = false;
            }
            Assert.IsTrue(check);
        }


        /// <summary>
        /// Vérifie que la méthode getallproductbycategoryunderprice doit retourner un dictionary contant 1 élements et sa valeur contient 4 éléments ordonné par la propriété price
        /// </summary>
        [TestMethod]
        public void MethodGetAllProductByCategoyUnderPriceShouldReturn2Elements()
        {
            var controller = Activator.CreateInstance(base.GetType(TYPE_NAME));

            // création de 4 category différents
            var category = GetCategoryEnumValue();
            var category1 = GetCategoryEnumValue(1);
            var category2 = GetCategoryEnumValue(2);
            var category3 = GetCategoryEnumValue(3);

            // creation de 1 brand
            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test");

            // création de 6 product donc 3 ont le même category
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test", brand, category, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 5m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test2", brand, category, 2m, 20m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test3", brand, category1, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test4", brand, category2, 2m, 2m });
            base.GetMethod(TYPE_NAME, "create").Invoke(controller, new object[] { "test5", brand, category3, 2m, 2m });

            // Apelle de la méthode
            var result = base.GetMethod(TYPE_NAME, "getallproductbycategoryunderprice").Invoke(controller, new object[] { category , 10m});

            var list = (result as IList);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue((decimal)list[0].GetType().GetProperty("Price").GetValue(list[0]) == 2m);
            Assert.IsTrue((decimal)list[1].GetType().GetProperty("Price").GetValue(list[1]) == 5m);
        }


        private object CreateTestBrand(params object[] parameters)
        {
            return base.GetConstructorByTypes("brand", new List<Type>() { typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) })
                .Invoke(new object[] { parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5] });
        }

        private object GetCategoryEnumValue(int index = 0)
        {
            return base.GetType("category").GetEnumValues().GetValue(index);
        }
    }
}
