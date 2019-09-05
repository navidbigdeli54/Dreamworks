/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System.Threading.Tasks;
using UnityEngine;
using DreamMachineGameStudio.Dreamworks.SFSM.Core;

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    public class CSFSMEvent : MonoBehaviour
    {
        #region Property
        protected ISFSM Owner { get; private set; }
        #endregion

        #region Method
        private void Start()
        {
            Owner = GetComponent<CSFSMBrainNonGeneric>();
        }
        #endregion
    }
}