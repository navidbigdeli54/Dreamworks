﻿/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnTriggerEnter")]
    public class CSFSMOnTriggerEnterEvent : CSFSMEvent
    {
        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            Owner.OnTriggerEnterEvent(other);
        }
    }
} 
#endif