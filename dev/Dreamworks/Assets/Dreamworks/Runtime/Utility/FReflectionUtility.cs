/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Utility
{
    /// <summary>
    /// Reflection Utility provide easy to use System.Reflection methods.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/24/2018</CreationDate>
    public static class FReflectionUtility
    {
        #region Field
        private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

        private static readonly IDictionary<Assembly, Type[]> assemblies = new Dictionary<Assembly, Type[]>();
        #endregion

        #region Property
        public static Type CLASS_TYPE { get; } = typeof(FReflectionUtility);
        #endregion

        #region Constructor
        static FReflectionUtility()
        {
            CacheAssemblies();
        }

        private static void CacheAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                assemblies.Add(assembly, assembly.GetTypes());
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Is given class type defines following attributes on it self?
        /// </summary>
        /// <param name="classType">Type of the class that you want to check.</param>
        /// <param name="attributeType">Type of attribute that you want to check.</param>
        /// <returns></returns>
        public static bool HasDefinedAttribute(Type classType, Type attributeType)
        {
            if (classType == null)
            {
                FLog.LogError("Class type should not be null.", null, CLASS_TYPE.Name);
                return false;
            }

            if (attributeType == null)
            {
                FLog.LogError("Attribute type should not be null.", null, CLASS_TYPE.Name);
                return false;
            }

            if (attributeType.IsSubclassOf(typeof(Attribute)) == false)
            {
                FLog.LogError($"{attributeType.Name} is not subtype of {nameof(Attribute)} class.", null, CLASS_TYPE.Name);
                return false;
            }

            return classType.IsDefined(attributeType);
        }

        /// <summary>
        /// Get all types in given assembly that inherited from given type.
        /// </summary>
        /// <typeparam name="T">Desire type</typeparam>
        /// <param name="assemblyName">Desire assembly</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesOf<T>()
        {
            Type desireType = typeof(T);

            List<Type> result = new List<Type>();

            foreach (var assemblyTypes in assemblies.Values)
            {
                if (desireType.IsInterface)
                {
                    result.AddRange(assemblyTypes.Where(row => row.GetInterface(desireType.Name) != null));
                }
                else
                {
                    result.AddRange(assemblyTypes.Where(row => row.IsSubclassOf(desireType)));
                }
            }

            return result;
        }

        public static Type GetType(string typeName)
        {
            foreach (var assemblyTypes in assemblies.Values)
            {
                Type desireType = assemblyTypes.Where(x => x.FullName.Equals(typeName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                if (desireType != null) return desireType;
            }

            return null;
        }

        /// <summary>
        /// If given instance's class has defines given attribute, return desire property.
        /// </summary>
        /// <returns>Value of desire property in given attribute</returns>
        public static T GetAttributeProperty<T>(object instance, Type attributeType, string propertyName)
        {
            if (instance == null)
            {
                FLog.LogError("Instance should not be null.", null, CLASS_TYPE.Name);
                return default;
            }

            if (attributeType == null)
            {
                FLog.LogError("Attribute type should not be null.", null, CLASS_TYPE.Name);
                return default;
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                FLog.LogError("Property name should not be null or empty", null, CLASS_TYPE.Name);
                return default;
            }

            if (attributeType.IsSubclassOf(typeof(Attribute)) == false)
            {
                FLog.LogError($"{attributeType.Name} is not subtype of {nameof(Attribute)}", null, CLASS_TYPE.Name);
                return default;
            }

            Type instanceType = instance.GetType();

            if (HasDefinedAttribute(instanceType, attributeType) == false)
            {
                FLog.LogError($"{instance.GetType().Name} does not defined {attributeType.Name} attribute.", null, CLASS_TYPE.Name);
                return default;
            }

            PropertyInfo propertyInfo = attributeType.GetProperty(propertyName, bindingFlags);

            if (propertyInfo == null)
            {
                FLog.LogError($"There is no {propertyName} property in {attributeType.Name} attribute.", null, CLASS_TYPE.Name);
                return default;
            }

            try
            {
                return (T)propertyInfo.GetValue(instanceType.GetCustomAttribute(attributeType));
            }
            catch (InvalidCastException exception)
            {
                FLog.LogError(exception.Message, null, CLASS_TYPE.Name);

                return default;
            }
        }

        /// <summary>
        /// Set given value to the given property name in desire instance.
        /// </summary>
        /// <param name="instance">Desire instance</param>
        /// <param name="propertyName">The name of desire property</param>
        /// <param name="value">Desire value for given property.</param>
        public static void SetProperty(object instance, string propertyName, object value)
        {
            if (instance == null)
            {
                FLog.LogError("Instance should not be null.", null, CLASS_TYPE.Name);
                return;
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                FLog.LogError("Property name should not be null or empty.", null, CLASS_TYPE.Name);
                return;
            }

            Type instanceType = instance.GetType();

            PropertyInfo propertyInfo = instanceType.GetProperty(propertyName, bindingFlags);

            if (propertyInfo == null)
            {
                FLog.LogError($"{propertyName} property doesn't exist in {instanceType.Name} class.", null, CLASS_TYPE.Name);
                return;
            }

            if (propertyInfo.PropertyType.IsAssignableFrom(value.GetType()) == false)
            {
                FLog.LogError($"Can not assign {value.GetType().Name} type to {propertyInfo.PropertyType.Name} type.", null, CLASS_TYPE.Name);
                return;
            }

            if (propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(instance, value);
                return;
            }

            Type DeclaringType = propertyInfo.DeclaringType;

            PropertyInfo declaringPropertyInfo = DeclaringType.GetProperty(propertyName, bindingFlags);

            if (declaringPropertyInfo == null)
            {
                FLog.LogError($"Unexpected Error", null, CLASS_TYPE.Name);
                return;
            }

            try
            {
                declaringPropertyInfo.SetValue(instance, value);
            }
            catch (Exception exception)
            {
                FLog.LogError(exception.Message, null, CLASS_TYPE.Name);
            }
        }

        /// <summary>
        /// Set given value to the given property in desire instance.
        /// </summary>
        /// <param name="instance">Desire instance</param>
        /// <param name="propertyInfo">The property info of desire property</param>
        /// <param name="value">Desire value for given property.</param>
        public static void SetProperty(object instance, PropertyInfo propertyInfo, object value)
        {
            if (instance == null)
            {
                FLog.LogError($"Instance should not be null.", null, CLASS_TYPE.Name);
                return;
            }

            if (propertyInfo == null)
            {
                FLog.LogError($"Property info should not be null.", null, CLASS_TYPE.Name);
                return;
            }

            if (propertyInfo.DeclaringType != instance.GetType())
            {
                FLog.LogError($"{propertyInfo.Name} property doesn't belong to {instance.GetType().Name} type.", null, CLASS_TYPE.Name);
                return;
            }

            if (propertyInfo.PropertyType.IsAssignableFrom(value.GetType()) == false)
            {
                FLog.LogError($"Can not assign {value.GetType().Name} type to {propertyInfo.PropertyType.Name} type.", null, CLASS_TYPE.Name);
                return;
            }

            if (propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(instance, value);
                return;
            }

            Type DeclaringType = propertyInfo.DeclaringType;

            PropertyInfo declaringPropertyInfo = DeclaringType.GetProperty(propertyInfo.Name, bindingFlags);

            if (declaringPropertyInfo == null)
            {
                FLog.LogError($"{propertyInfo} dose not exist in {instance.GetType().Name} class.", null, CLASS_TYPE.Name);
                return;
            }

            try
            {
                declaringPropertyInfo.SetValue(instance, value);
            }
            catch (Exception exception)
            {
                FLog.LogError(exception.Message, null, CLASS_TYPE.Name);
            }
        }

        /// <summary>
        /// Set given value to the given field name in desire instance.
        /// </summary>
        /// <param name="instance">Desire instance</param>
        /// <param name="fieldName">The name of desire property</param>
        /// <param name="value">Desire value for given property.</param>
        public static void SetField(object instance, string fieldName, object value)
        {
            if (instance == null)
            {
                FLog.LogError($"Instance parameter is null, it is not accepted.", null, CLASS_TYPE.Name);
                return;
            }

            if (string.IsNullOrEmpty(fieldName))
            {
                FLog.LogError($"Property name parameter is null, it is not accepted.", null, CLASS_TYPE.Name);
                return;
            }

            Type instanceType = instance.GetType();

            FieldInfo fieldInfo = instanceType.GetField(fieldName, bindingFlags);

            if (fieldInfo == null)
            {
                FLog.LogError($"{fieldName} dose not exist in {instanceType.Name} class.", null, CLASS_TYPE.Name);
                return;
            }

            try
            {
                fieldInfo.SetValue(instance, value);
            }
            catch (Exception exception)
            {
                FLog.LogError(exception.Message, null, CLASS_TYPE.Name);
            }
        }

        /// <summary>
        /// Set given value to the given field in desire instance.
        /// </summary>
        /// <param name="instance">Desire instance</param>
        /// <param name="fieldInfo">The field info of desire property</param>
        /// <param name="value">Desire value for given property.</param>
        public static void SetField(object instance, FieldInfo fieldInfo, object value)
        {
            if (instance == null)
            {
                FLog.LogError($"Instance parameter is null, it is not accepted.", null, CLASS_TYPE.Name);
                return;
            }

            if (fieldInfo == null)
            {
                FLog.LogError($"Property name parameter is null, it is not accepted.", null, CLASS_TYPE.Name);
                return;
            }

            try
            {
                fieldInfo.SetValue(instance, value);
            }
            catch (Exception exception)
            {
                FLog.LogError(exception.Message, null, CLASS_TYPE.Name);
            }
        }

        /// <summary>
        /// Returns all properties of given object.(Any access level).
        /// </summary>
        public static IEnumerable<PropertyInfo> GetAllProperties(object obj)
        {
            Type type = obj.GetType();

            return type.GetProperties(bindingFlags);
        }

        /// <summary>
        /// Returns all fields of given object.(Any access level).
        /// </summary>
        public static IEnumerable<FieldInfo> GetAllFields(object obj)
        {
            Type type = obj.GetType();

            return type.GetFields(bindingFlags);
        }

        /// <summary>
        /// Returns all interfaces of given object.
        /// </summary>
        public static IEnumerable<Type> GetAllInterfaces(object obj)
        {
            Type type = obj.GetType();

            return type.GetInterfaces();
        }

        /// <summary>
        /// Returns all interfaces of given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllInterfaces(Type type)
        {
            return type.GetInterfaces();
        }
        #endregion
    }
}