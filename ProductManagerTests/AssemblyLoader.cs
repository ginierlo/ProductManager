using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTests
{
    public class AssemblyLoader
    {
        private Assembly _assembly;
        public AssemblyLoader()
        {
            _assembly = Assembly.Load("ProductManager");
        }

        public Type GetType(string typeName)
        {
            return 
                _assembly
                    .GetTypes()
                    .FirstOrDefault(t => t.Name.ToLower().Contains(typeName));
        }

        public ConstructorInfo GetConstructorByTypes(string typeName, List<Type> types)
        {
            return
                GetType(typeName)
                    ?.GetConstructor(types.ToArray());
        }

        public PropertyInfo GetProperty(string typeName, string propertyName)
        {
            return
                GetType(typeName)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name.ToLower() == propertyName);
        }

        public PropertyInfo GetProperty(Type type, string propertyName)
        {
            return
                type
                    .GetProperties()
                    .FirstOrDefault(p => p.Name.ToLower() == propertyName);
        }

        public Type GetPropertyType(string typeName, string propertyName)
        {
            return
                GetType(typeName)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name.ToLower() == propertyName)
                    ?.PropertyType;
        }

        public object GetPropertyValue(string typeName, string propertyName, object obj)
        {
            return
                GetType(typeName)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name.ToLower() == propertyName)
                    ?.GetValue(obj);
        }

        public object GetImplementedInterface(string typeName, string interfaceName)
        {
            return
                GetType(typeName)
                    .GetInterfaces()
                    .FirstOrDefault(i => i.Name.ToLower() == interfaceName);
        }

        public MethodInfo GetMethod(string typeName, string methodName)
        {
            return
                GetType(typeName)
                    .GetMethods()
                    .FirstOrDefault(i => i.Name.ToLower() == methodName);
        }
        public MethodInfo GetMethodByParametersTypes(string typeName, string methodName, List<Type> types)
        {
            return
                GetType(typeName)
                    .GetMethod(methodName, types.ToArray());
        }

        public List<ParameterInfo> GetMethodParameters(string typeName, string methodName)
        {
            return
                GetMethod(typeName, methodName)
                    .GetParameters()
                    .ToList();
        }

        public MethodInfo GetRuntimeMethod(string typeName, string methodName)
        {
            return
                GetType(typeName)
                    .GetRuntimeMethods()
                    .FirstOrDefault(i => i.Name.ToLower() == methodName);
        }

        public MethodInfo GetRuntimeMethod(Type type, string methodName)
        {
            return
                type
                    .GetRuntimeMethods()
                    .FirstOrDefault(i => i.Name.ToLower() == methodName);
        }

        public MethodInfo GetRuntimeMethodByParametersTypes(string typeName, string methodName, List<Type> types)
        {
            return
                GetType(typeName)
                    .GetRuntimeMethod(methodName, types.ToArray());
        }

        public List<ParameterInfo> GetRuntimeMethodParameters(string typeName, string methodName)
        {
            return
                GetRuntimeMethod(typeName, methodName)
                    .GetParameters()
                    .ToList();
        }

        public FieldInfo GetPrivateRuntimeField(string typeName, string fieldName)
        {
            return
                GetType(typeName)
                    ?.GetRuntimeFields()
                    .FirstOrDefault(f => f.IsPrivate && f.Name.Contains(fieldName));
        }

        public FieldInfo GetPrivateRuntimeField(Type type, string fieldName)
        {
            return
                type
                    ?.GetRuntimeFields()
                    .FirstOrDefault(f => f.IsPrivate && f.Name.Contains(fieldName));
        }

        public Type MakeGenericType(string typeName, string genericTypeName)
        {
            return GetType(typeName).MakeGenericType(GetType(genericTypeName));
        }
    }
}
