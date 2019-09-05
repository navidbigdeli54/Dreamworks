/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if UNITY_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnTriggerStay")]
    public class CSFSMOnTriggerStayEvent : CSFSMEvent
    {
        private void OnTriggerStay(UnityEngine.Collider other)
        {
            Owner.OnTriggerStayEvent(other);
        }
    }
} 
#endif