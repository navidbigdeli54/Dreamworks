/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using DreamMachineGameStudio.Dreamworks.ServiceLocator;
using DreamMachineGameStudio.Dreamworks.EventManagement;
using DreamMachineGameStudio.Dreamworks.SceneManagement;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/14/2019</CreationDate>
    public class SStartup : SScriptableObject, IStartup
    {
        #region Method
        protected virtual void Configuration() { }
        #endregion

        #region IStartup Implementation
        void IStartup.Configuration()
        {
            Screen.sleepTimeout = 0;
            Application.targetFrameRate = 60;

            MDreamwork[] existedInstances = FindObjectsOfType<MDreamwork>();
            if (existedInstances != null && existedInstances.Length > 0)
            {
                for (int i = 0; i < existedInstances.Length; ++i)
                {
                    Destroy(existedInstances[i].gameObject);
                }
            }

            new GameObject().AddComponent<MDreamwork>();

            FServiceLocator.Register<IEventManagement>(new GameObject().AddComponent<CEventManagement>());

            FServiceLocator.Register<ISceneManagement>(new GameObject().AddComponent<CSceneManagement>());

            Configuration();

            MDreamwork.Instance.StartUp();
        }
        #endregion
    }
}