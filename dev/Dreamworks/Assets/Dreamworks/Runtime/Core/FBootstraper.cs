/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

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
                FLog.LogError("Can't read framework configuration.", null, CLASS_TYPE.Name);

                return;
            }

            if (configuration.DontLoadFramework)
            {
                FLog.Log("DontLoadFramework is true.", null, CLASS_TYPE.Name);

                return;
            }

            Type startupType = FReflectionUtility.GetType(configuration.StartupClass);

            if (startupType == null)
            {
                FLog.LogError("Startup type has not been selected, Please select a startup type in framework's configuration.", null, CLASS_TYPE.Name);

                return;
            }

            if (startupType.IsSubclassOf(typeof(SStartup)) == false)
            {
                FLog.LogError("Startup class should be a subclass of `SStartup`.", null, CLASS_TYPE.Name);

                return;
            }


            if ((ScriptableObject.CreateInstance(startupType) is IStartup startup))
            {
                startup.Configuration();
            }
            else
            {
                FLog.LogError("Can't instantiate startup object.", null, CLASS_TYPE.Name);

                return;
            }

        }
        #endregion
    }
}