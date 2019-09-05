/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using DreamMachineGameStudio.Dreamworks.ServiceLocator;
using DreamMachineGameStudio.Dreamworks.Test.Dummy.ServiceLocator;
using System.Text.RegularExpressions;

namespace DreamMachineGameStudio.Dreamworks.Test.ServiceLocator
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/14/2019</CreationDate>
    public class UT_ServiceLocator
    {
        [Test]
        public void Register_Null_Service_Test()
        {
            LogAssert.Expect(LogType.Error, new Regex("Service instance can't be null."));
            FServiceLocator.Register<IDummyService>(null);
        }

        [Test]
        public void Register_Service_That_Has_Not_Implement_Given_Interface_Test()
        {
            LogAssert.Expect(LogType.Error, new Regex("Service instance doesn't implemented"));
            FServiceLocator.Register<IDummyService>(new GameObject(nameof(CDummyServiceNotImplementedInterface)).AddComponent<CDummyServiceNotImplementedInterface>());
        }

        [Test]
        public void Register_Service_Twice_Test()
        {
            FServiceLocator.Register<IDummyService>(new GameObject(nameof(CDummyService)).AddComponent<CDummyService>());
            CDummyService service = FServiceLocator.Resolve<IDummyService>() as CDummyService;
            Assert.IsNotNull(service);

            LogAssert.Expect(LogType.Warning, new Regex("service is already registered."));
            FServiceLocator.Register<IDummyService>(new GameObject(nameof(CDummyService)).AddComponent<CDummyService>());
        }

        [Test]
        public void Register_Service_Test()
        {
            LogAssert.Expect(LogType.Log, new Regex("service has been registered."));
            FServiceLocator.Register<IDummyService>(new GameObject(nameof(CDummyService)).AddComponent<CDummyService>());

            CDummyService service = FServiceLocator.Resolve<IDummyService>() as CDummyService;
            Assert.IsNotNull(service);
        }
    }
}
