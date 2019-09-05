/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnTriggerStay2D")]
    public class CSFSMOnTriggerStay2DEvent : CSFSMEvent
    {
        private void OnTriggerStay2D(UnityEngine.Collider2D other)
        {
            Owner.OnTriggerStay2DEvent(other);
        }
    }
} 
#endif