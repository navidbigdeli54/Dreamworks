/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.Persistent
{
    /// <summary>
    /// Make an game object persist between levels.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/26/2019</CreationDate>
    [DisallowMultipleComponent]
    public class CPersistent : MonoBehaviour
    {
        #region Property
        public static Type CLASS_TYPE { get; } = typeof(CPersistent);
        #endregion

        #region MonoBehaviours
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Method
        protected void OnDestroyComponent()
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Persist a game object that means it will not destroy between levels.
        /// </summary>
        /// <param name="gameObject">Desire game object to make it persistent.</param>
        public static void MakePersistent(GameObject gameObject)
        {
            if (gameObject == null)
            {
                FLog.LogError($"Given game object to making it persistent is null. it is not accepted.", null, CLASS_TYPE.Name);
                return;
            }

            if (gameObject.GetComponent<CPersistent>() != null)
            {
                FLog.LogWarning($"`{gameObject.name}` has marked as persistent already.", null, CLASS_TYPE.Name);
                return;
            }

            gameObject.AddComponent<CPersistent>();
        }

        /// <summary>
        /// Make a game object transient that means it will destroy when level has been unloaded.
        /// </summary>
        /// <param name="gameObject">Desire game object to make it transient</param>
        public static void MakeTransient(GameObject gameObject)
        {
            if (gameObject == null)
            {
                FLog.LogError($"Given game object to making it persistent is null. it is not accepted.", null, CLASS_TYPE.Name);
                return;
            }

            CPersistent component = gameObject.GetComponent<CPersistent>();

            if (component == null)
            {
                FLog.LogWarning($"`{gameObject.name}` has marked as transient already.", null, CLASS_TYPE.Name);
                return;
            }

            Destroy(component);
        }
        #endregion
    }
}