/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnTriggerExit")]
    public class CSFSMOnTriggerExitEvent : CSFSMEvent
    {
        private void OnTriggerExit(UnityEngine.Collider other)
        {
            Owner.OnTriggerExitEvent(other);
        }
    }
} 
#endif