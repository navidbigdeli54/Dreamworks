/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// FBootstraper is starting point of framework. It's responsible to instantiate startup class that has been selected in framework's configuration file.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/14/2019</CreationDate>
    internal static class FBootstraper
    {
        #region Property
        private static Type CLASS_TYPE => typeof(FBootstraper);
        #endregion

        #region Method
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void StartUp()
        {
            SFrameworkConfiguration configuration = Resources.Load<SFrameworkConfiguration>(nameof(SFrameworkConfiguration));

            if (configuration == null)
            {
                FLog.Error(CLASS_TYPE.Name, "Can't read framework configuration.");

                return;
            }

            if (configuration.DontLoadFramework)
            {
                FLog.Log(CLASS_TYPE.Name, "DontLoadFramework is true.");

                return;
            }

            Type startupType = FReflectionUtility.GetType(configuration.StartupClass);

            if (startupType == null)
            {
                FLog.Error(CLASS_TYPE.Name, "Startup type has not been selected, Please select a startup type in framework's configuration.");

                return;
            }

            if (startupType.IsSubclassOf(typeof(SStartup)) == false)
            {
                FLog.Error(CLASS_TYPE.Name, "Startup class should be a subclass of `SStartup`.");

                return;
            }


            if ((ScriptableObject.CreateInstance(startupType) is IStartup startup))
            {
                startup.Configuration();
            }
            else
            {
                FLog.Error(CLASS_TYPE.Name, "Can't instantiate startup object.");

                return;
            }

        }
        #endregion
    }
}