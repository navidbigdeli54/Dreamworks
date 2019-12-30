/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using System.Linq;
using UnityEngine;
using NUnit.Framework;
using System.Reflection;
using UnityEngine.TestTools;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DreamMachineGameStudio.Dreamworks.Utility;
using DreamMachineGameStudio.Dreamworks.Test.Dummy.Core;
using DreamMachineGameStudio.Dreamworks.Test.Dummy.Utility;

namespace DreamMachineGameStudio.Dreamworks.Test.Utility
{
    /// <summary>
    /// FReflectionUtility test class.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/15/2018</CreationDate>
    public class UT_FReflectionUtility
    {
        [Test]
        public void Has_Define_Attribute_Test()
        {
            bool result = FReflectionUtility.HasDefinedAttribute(typeof(FReflectionDummy), typeof(TReflectionDummy));
            Assert.IsTrue(result);
        }

        [Test]
        public void Has_Not_Define_Attribute_Test()
        {
            bool result = FReflectionUtility.HasDefinedAttribute(typeof(CDummy), typeof(TReflectionDummy));
            Assert.IsFalse(result);
        }

        [Test]
        public void Has_Define_Attribute_With_Class_Type_Null_Test()
        {
            LogAssert.Expect(LogType.Error, new Regex("Class type should not be null."));
            bool result = FReflectionUtility.HasDefinedAttribute(null, typeof(TReflectionDummy));
            Assert.False(result);
        }

        [Test]
        public void Has_Define_Attribute_With_Attribute_Type_Null_Test()
        {
            LogAssert.Expect(LogType.Error, new Regex("Attribute type should not be null."));
            bool result = FReflectionUtility.HasDefinedAttribute(typeof(FReflectionDummy), null);
            Assert.False(result);
        }

        [Test]
        public void Has_Define_Attribute_With_Not_Attribute_Class_Test()
        {
            LogAssert.Expect(LogType.Error, new Regex("is not subtype of"));
            bool result = FReflectionUtility.HasDefinedAttribute(typeof(FReflectionDummy), typeof(CDummy));
            Assert.False(result);
        }

        [Test]
        public void Get_SubTypes_Of_Test()
        {
            IEnumerable<Type> subClasses = FReflectionUtility.GetSubTypesOf<FReflectionDummyBase>();
            Assert.IsNotNull(subClasses);
            Assert.AreEqual(1, subClasses.Count());
            Assert.IsTrue(subClasses.Select(x => x.Name).Contains(nameof(FReflectionDummyDriven)));
        }

        [Test]
        public void Get_Attribute_Property_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();
            string name = FReflectionUtility.GetAttributeProperty<string>(dummy, typeof(TReflectionDummy), nameof(TReflectionDummy.Name));
            Assert.AreEqual(nameof(TReflectionDummy), name);
        }

        [Test]
        public void Get_Attribute_Property_With_Instance_Null_Test()
        {
            LogAssert.Expect(LogType.Error, new Regex("Instance should not be null."));
            string name = FReflectionUtility.GetAttributeProperty<string>(null, typeof(TReflectionDummy), nameof(TReflectionDummy.Name));
            Assert.IsNull(name);
        }

        [Test]
        public void Get_Attribute_Property_With_Attribute_Type_Null_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            LogAssert.Expect(LogType.Error, new Regex("Attribute type should not be null."));
            string name = FReflectionUtility.GetAttributeProperty<string>(dummy, null, nameof(TReflectionDummy.Name));
            Assert.IsNull(name);
        }

        [Test]
        public void Get_Attribute_Property_With_Propery_Name_Null_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            LogAssert.Expect(LogType.Error, new Regex("Property name should not be null or empty"));
            string name = FReflectionUtility.GetAttributeProperty<string>(dummy, typeof(TReflectionDummy), null);
            Assert.IsNull(name);
        }

        [Test]
        public void Get_Attribute_Property_With_Non_Attribute_Type_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            LogAssert.Expect(LogType.Error, new Regex("is not subtype of"));
            string name = FReflectionUtility.GetAttributeProperty<string>(dummy, typeof(CDummy), nameof(TReflectionDummy.Name));
            Assert.IsNull(name);
        }

        [Test]
        public void Get_Attribute_Property_With_Non_Define_Type_Test()
        {
            FDummy dummy = new FDummy();

            LogAssert.Expect(LogType.Error, new Regex("does not defined"));
            string name = FReflectionUtility.GetAttributeProperty<string>(dummy, typeof(TReflectionDummy), nameof(TReflectionDummy.Name));
            Assert.IsNull(name);
        }

        [Test]
        public void Get_Attribute_Property_With_Wrong_Property_Name_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            LogAssert.Expect(LogType.Error, new Regex("There is no"));
            string name = FReflectionUtility.GetAttributeProperty<string>(dummy, typeof(TReflectionDummy), nameof(FDummy));
            Assert.IsNull(name);
        }

        [Test]
        public void Get_Attribute_Property_With_Wrong_Return_Type_Name_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            LogAssert.Expect(LogType.Error, new Regex("cast"));
            int? name = FReflectionUtility.GetAttributeProperty<int?>(dummy, typeof(TReflectionDummy), nameof(TReflectionDummy.Name));
            Assert.IsNull(name);
        }

        [Test]
        public void Set_Property_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            FReflectionUtility.SetProperty(dummy, nameof(FReflectionDummy.PublicPropertyPublicPrivate), "Hello");
            Assert.AreEqual("Hello", dummy.PublicPropertyPublicPrivate);
        }

        [Test]
        public void Set_Property_With_Null_Instance()
        {
            LogAssert.Expect(LogType.Error, new Regex("Instance should not be null."));
            FReflectionUtility.SetProperty(null, string.Empty, string.Empty);
        }

        [Test]
        public void Set_Property_With_Null_Name()
        {
            FDummy dummy = new FDummy();

            LogAssert.Expect(LogType.Error, new Regex("Property name should not be null or empty."));
            FReflectionUtility.SetProperty(dummy, null as string, string.Empty);
        }

        [Test]
        public void Set_Property_With_Empty_Name()
        {
            FDummy dummy = new FDummy();

            LogAssert.Expect(LogType.Error, new Regex("Property name should not be null or empty."));
            FReflectionUtility.SetProperty(dummy, string.Empty, string.Empty);
        }

        [Test]
        public void Set_Property_Does_Not_Exist_Test()
        {
            FDummy dummy = new FDummy();

            LogAssert.Expect(LogType.Error, new Regex("property doesn't exist in"));
            FReflectionUtility.SetProperty(dummy, "ExecutionOrder", 10);
        }

        [Test]
        public void Set_Property_MissMatch_Type_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            LogAssert.Expect(LogType.Error, new Regex("Can not assign"));
            FReflectionUtility.SetProperty(dummy, nameof(FReflectionDummy.PublicPropertyPublicPrivate), 10);
        }

        [Test]
        public void Set_Property_With_Property_Info_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            Type type = dummy.GetType();
            PropertyInfo propertyInfo = type.GetProperty(nameof(FReflectionDummy.PublicPropertyPublicPrivate), BindingFlags.Public | BindingFlags.Instance);

            FReflectionUtility.SetProperty(dummy, propertyInfo, "Hello");
            Assert.AreEqual("Hello", dummy.PublicPropertyPublicPrivate);
        }

        [Test]
        public void Set_Property_With_Property_Info_And_Null_Instance()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            Type type = dummy.GetType();
            PropertyInfo propertyInfo = type.GetProperty(nameof(FReflectionDummy.PublicPropertyPublicPrivate), BindingFlags.Public | BindingFlags.Instance);

            LogAssert.Expect(LogType.Error, new Regex("Instance should not be null."));
            FReflectionUtility.SetProperty(null, propertyInfo, string.Empty);
        }

        [Test]
        public void Set_Property_With_Property_Info_Does_Not_Exist_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            Type type = dummy.GetType();
            PropertyInfo propertyInfo = type.GetProperty(nameof(FReflectionDummy.PublicPropertyPublicPrivate), BindingFlags.Public | BindingFlags.Instance);

            LogAssert.Expect(LogType.Error, new Regex("property doesn't belong to"));
            FReflectionUtility.SetProperty(new FDummy(), propertyInfo, string.Empty);
        }

        [Test]
        public void Set_Property_With_Property_Info_MissMatch_Type_Test()
        {
            FReflectionDummy dummy = new FReflectionDummy();

            Type type = dummy.GetType();
            PropertyInfo propertyInfo = type.GetProperty(nameof(FReflectionDummy.PublicPropertyPublicPrivate), BindingFlags.Public | BindingFlags.Instance);

            LogAssert.Expect(LogType.Error, new Regex("Can not assign"));
            FReflectionUtility.SetProperty(dummy, propertyInfo, 10);
        }
    }
}