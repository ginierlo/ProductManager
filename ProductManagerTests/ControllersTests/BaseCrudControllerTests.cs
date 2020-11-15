using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductManagerTests.ControllersTests
{
    [TestClass]
    public class BaseCrudControllerTests : AssemblyLoader 
    {
        private const string TYPE_NAME = "basecrudcontroller";

        /// <summary>
        /// Vérifie si le type existe
        /// </summary>
        [TestMethod]
        public void TypeExist()
        {
            Assert.IsNotNull(base.GetType(TYPE_NAME));
        }

        /// <summary>
        /// Vérifie si le type est générique
        /// </summary>
        [TestMethod]
        public void TypeIsGeneric()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.IsGenericType ?? false);
        }

        /// <summary>
        /// vérifie si le type contient uniquement 1 argument générique
        /// </summary>
        [TestMethod]
        public void ContainsOnlyOneGenricArg()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.GetGenericArguments().Count() == 1);
        }

        /// <summary>
        /// vérifie si le nom du paramètre générique est t
        /// </summary>
        [TestMethod]
        public void GenricParameterNameT()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.GetGenericArguments().First().Name.ToLower() == "t");
        }

        /// <summary>
        /// vérifie si le paramètre généric implémente l'interface imdoel
        /// </summary>
        [TestMethod]
        public void GenricParameteImplementImdoel()
        {
            Assert.IsNotNull(base.GetType(TYPE_NAME)?.GetGenericArguments().First().GetInterfaces().FirstOrDefault(i => i.Name.ToLower() == "imodel"));
        }

        /// <summary>
        /// vérifie si le type contient un membre privée
        /// </summary>
        [TestMethod]
        public void PrivateMemberExist()
        {
            Assert.IsTrue(base.GetType(TYPE_NAME)?.GetRuntimeFields().Where(f => f.IsPrivate).Count() == 1);
        }

        /// <summary>
        /// vérifie que le membre privé contienne le nom objs
        /// </summary>
        [TestMethod]
        public void PrivateMemberNamedObjs()
        {
            Assert.IsNotNull(base.GetPrivateRuntimeField(TYPE_NAME, "objs"));
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée create
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodCreate()
        {
            Assert.IsNotNull(base.GetRuntimeMethod(TYPE_NAME, "create"));
        }

        /// <summary>
        /// Vérifie que la méthode create soit protected
        /// </summary>
        [TestMethod]
        public void MethodCreateIsProtected()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "create")?.IsFamily ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode create retourne un type void
        /// </summary>
        [TestMethod]
        public void MethodCreateReturnTypeIsVoid()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "create")?.ReturnType == typeof(void));
        }

        /// <summary>
        /// Vérifie que la méthode create contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethodCreateContainsOnlyOneParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "create").Count == 1);
        }

        /// <summary>
        /// Vérifie que le paramètre de la méthode create soit de type générique
        /// </summary>
        [TestMethod]
        public void MethodCreateHasGenericParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "create").First().ParameterType.IsGenericParameter);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée getall
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodGetAll()
        {
            Assert.IsNotNull(base.GetRuntimeMethod(TYPE_NAME, "getall"));
        }

        /// <summary>
        /// Vérifie que la méthode getall soit protected
        /// </summary>
        [TestMethod]
        public void MethodGetAllIsProtected()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "getall")?.IsFamily ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getall retourne un type list
        /// </summary>
        [TestMethod]
        public void MethodGetAllReturnTypeIsList()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "getall")?.ReturnType.Name.ToLower().Contains("list") ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getall retourne un type list de type générique
        /// </summary>
        [TestMethod]
        public void MethodGetAllReturnTypeIsGenericList()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "getall")?.ReturnType.IsGenericType ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode getall contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethoGetAllContainsNoParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "getall").Count == 0);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée update
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodUpdate()
        {
            Assert.IsNotNull(base.GetRuntimeMethod(TYPE_NAME, "update"));
        }

        /// <summary>
        /// Vérifie que la méthode update soit protected
        /// </summary>
        [TestMethod]
        public void MethodUpdateIsProtected()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "update")?.IsFamily ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode update retourne un type list
        /// </summary>
        [TestMethod]
        public void MethodUpdateReturnTypeIsList()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "update")?.ReturnType == typeof(void));
        }

        /// <summary>
        /// Vérifie que la méthode update contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethoUpdateContainsNoParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "update").Count == 1);
        }

        /// <summary>
        /// Vérifie que le paramètre de la méthode update soit de type générique
        /// </summary>
        [TestMethod]
        public void MethodUpdateHasGenericParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "update").First().ParameterType.IsGenericParameter);
        }

        /// <summary>
        /// Vérifie que le type contienne une méthode nommée delete
        /// </summary>
        [TestMethod]
        public void TypeContainsMethodDelete()
        {
            Assert.IsNotNull(base.GetRuntimeMethod(TYPE_NAME, "delete"));
        }

        /// <summary>
        /// Vérifie que la méthode delete soit protected
        /// </summary>
        [TestMethod]
        public void MethodDeleteIsProtected()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "delete")?.IsFamily ?? false);
        }

        /// <summary>
        /// Vérifie que la méthode delete retourne un type list
        /// </summary>
        [TestMethod]
        public void MethodDeleteReturnTypeIsList()
        {
            Assert.IsTrue(base.GetRuntimeMethod(TYPE_NAME, "delete")?.ReturnType == typeof(void));
        }

        /// <summary>
        /// Vérifie que la méthode delete contienne seulement 1 paramètre
        /// </summary>
        [TestMethod]
        public void MethoDeleteContainsNoParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "delete").Count == 1);
        }

        /// <summary>
        /// Vérifie que le paramètre de la méthode delete soit de type générique
        /// </summary>
        [TestMethod]
        public void MethodDeleteHasGenericParameter()
        {
            Assert.IsTrue(base.GetRuntimeMethodParameters(TYPE_NAME, "delete").First().ParameterType == typeof(int));
        }

        /// <summary>
        /// Vérifie qu'arpès l'appel de la méthode create, la liste contient 1 élément
        /// </summary>
        [TestMethod]
        public void InvokeMethodCreateShouldAddOneElementToList()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var instance = Activator.CreateInstance(genericType);

            var product = CreateTestProduct(0, "test", null, null, 0m, 0m);
            base.GetRuntimeMethod(genericType, "create").Invoke(instance, new object[] { product });

            var list = base.GetPrivateRuntimeField(genericType, "objs");

            Assert.IsTrue(((IEnumerable<object>)list.GetValue(instance)).Count() == 1);
        }

        /// <summary>
        /// Vérifie qu'arpès l'ajout d'un élément déjà existant la liste contienne qu'un seul élément
        /// </summary>
        [TestMethod]
        public void CreateExistingElementShouldNotBeAddedToList()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var instance = Activator.CreateInstance(genericType);

            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test", "test");

            var category = GetCategoryEnumValue();

            var product = CreateTestProduct(0, "test", brand, category, 0m, 0m);
            base.GetRuntimeMethod(genericType, "create").Invoke(instance, new object[] { product });
            product = CreateTestProduct(0, "test", brand, category, 0m, 0m);
            base.GetRuntimeMethod(genericType, "create").Invoke(instance, new object[] { product });

            var list = base.GetPrivateRuntimeField(genericType, "objs");

            Assert.IsTrue(((IEnumerable<object>)list.GetValue(instance)).Count() == 1);
        }

        /// <summary>
        /// Vérifie qu'arpès l'ajout de 2 éléments le 2ème ait l'id 2
        /// </summary>
        [TestMethod]
        public void Create2ElementsShouldIncrementId()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var instance = Activator.CreateInstance(genericType);

            var product = CreateTestProduct(0, "test", null, null, 0m, 0m);
            base.GetRuntimeMethod(genericType, "create").Invoke(instance, new object[] { product });
            product = CreateTestProduct(0, "test2", null, null, 0m, 0m);
            base.GetRuntimeMethod(genericType, "create").Invoke(instance, new object[] { product });

            var list = base.GetPrivateRuntimeField(genericType, "objs");
            var elements = list.GetValue(instance) as IEnumerable<object>;
            var lastElement = elements.Last();

            Assert.IsTrue((int)base.GetProperty(lastElement.GetType(), "id").GetValue(lastElement) == 2);
        }

        /// <summary>
        /// Vérifie que la supression d'un élément existant fonctionne
        /// </summary>
        [TestMethod]
        public void DeleteExistingElementShouldReturnEmptyList()
        {
            int id = 1;
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test", "test");

            var category = GetCategoryEnumValue();

            var product = CreateTestProduct(id, "test", brand, category, 0m, 0m);

            var instance = AddProductToList(genericType, product);

            base.GetRuntimeMethod(genericType, "delete").Invoke(instance, new object[] { id });

            Assert.IsTrue((base.GetPrivateRuntimeField(genericType, "objs").GetValue(instance) as IEnumerable<object>).Count() == 0);
        }

        /// <summary>
        /// Vérifie que la liste contienne toujours un élément après la suppression d'un id inexistant
        /// </summary>
        [TestMethod]
        public void DeleteNonExistingElementShouldReturnListWithOneElement()
        {
            int id = 1;
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test", "test");

            var category = GetCategoryEnumValue();

            var product = CreateTestProduct(id, "test", brand, category, 0m, 0m);

            var instance = AddProductToList(genericType, product);

            base.GetRuntimeMethod(genericType, "delete").Invoke(instance, new object[] { id + 1 });

            Assert.IsTrue((base.GetPrivateRuntimeField(genericType, "objs").GetValue(instance) as IEnumerable<object>).Count() == 1);
        }

        /// <summary>
        /// vérifie que la liste contienne 0 élément lorsque l'on supprimer et que la liste est vide
        /// </summary>
        [TestMethod]
        public void DeleteWithEmptyListShouldReturnEmptyList()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var instance = Activator.CreateInstance(genericType);

            base.GetRuntimeMethod(genericType, "delete").Invoke(instance, new object[] { 1 });

            Assert.IsTrue((base.GetPrivateRuntimeField(genericType, "objs").GetValue(instance) as IEnumerable<object>).Count() == 0);
        }

        /// <summary>
        /// Vérifie que la méthode getall retourn 1 élément après l'ajout d'un élément
        /// </summary>
        [TestMethod]
        public void GetAllShouldReturn1ElementWithOneEWlementInList()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test", "test");

            var category = GetCategoryEnumValue();

            var product = CreateTestProduct(0, "test", brand, category, 0m, 0m);

            var instance = AddProductToList(genericType, product);

            var list = base.GetRuntimeMethod(genericType, "getall").Invoke(instance, null);

            Assert.IsTrue((list as IEnumerable<object>).Count() == 1);
        }

        /// <summary>
        /// Vérifie que la méthode getall retourn 0 quand le liste est vide
        /// </summary>
        [TestMethod]
        public void GetAllShouldReturn0ElementWithEmptyList()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var instance = Activator.CreateInstance(genericType);

            var list = base.GetRuntimeMethod(genericType, "getall").Invoke(instance, null);

            Assert.IsTrue((list as IEnumerable<object>).Count() == 0);
        }

        /// <summary>
        /// Modification de l'élément avec id existant est bien effectuée
        /// </summary>
        [TestMethod]
        public void UpdateElementWithExistingIdShouldBeEffective()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test", "test");

            var category = GetCategoryEnumValue();

            var product = CreateTestProduct(1, "test", brand, category, 0m, 0m);

            var instance = AddProductToList(genericType, product);

            var productModified = CreateTestProduct(1, "test", brand, category, 200m, 200m);

            base.GetRuntimeMethod(genericType, "update").Invoke(instance, new object[] { productModified });

            Assert.IsTrue((base.GetPrivateRuntimeField(genericType, "objs").GetValue(instance) as IEnumerable<object>).First() == productModified);
        }

        /// <summary>
        /// Modification de l'élément avec id existant n'est pas effectuée
        /// </summary>
        [TestMethod]
        public void UpdateElementWithNonExistingIdShouldNotBeEffective()
        {
            var genericType = base.MakeGenericType(TYPE_NAME, "product");

            var brand = CreateTestBrand(1, "test", "test", "test", "test", "test", "test");

            var category = GetCategoryEnumValue();

            var product = CreateTestProduct(1, "test", brand, category, 0m, 0m);

            var instance = AddProductToList(genericType, product);

            var productModified = CreateTestProduct(2, "test", brand, category, 200m, 200m);

            base.GetRuntimeMethod(genericType, "update").Invoke(instance, new object[] { productModified });

            Assert.IsTrue((base.GetPrivateRuntimeField(genericType, "objs").GetValue(instance) as IEnumerable<object>).First() == product);
        }

        private object CreateTestProduct(params object[] parameters)
        {
            return base.GetConstructorByTypes("product", new List<Type>() { typeof(int), typeof(string), base.GetType("brand"), base.GetType("category"), typeof(decimal), typeof(decimal) })
                .Invoke(new object[] { parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5] });
        }

        private object AddProductToList(Type genericType, object product)
        {
            var instance = Activator.CreateInstance(genericType);

            var genericList = Type.GetType("System.Collections.Generic.List`1").MakeGenericType(base.GetType("product"));
            var instanceList = Activator.CreateInstance(genericList);
            genericList.GetMethod("Add").Invoke(instanceList, new object[] { product });

            base.GetPrivateRuntimeField(genericType, "objs").SetValue(instance, instanceList);

            return instance;
        }

        private object CreateTestBrand(params object[] parameters)
        {
            return base.GetConstructorByTypes("brand", new List<Type>() { typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) })
                .Invoke(new object[] { parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5] });
        }

        private object GetCategoryEnumValue()
        {
            return base.GetType("category").GetEnumValues().GetValue(0);
        }

    }
}
