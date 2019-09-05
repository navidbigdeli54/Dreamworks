/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnTriggerExit2D")]
    public class CSFSMOnTriggerExit2DEvent : CSFSMEvent
    {
        private void OnTriggerExit2D(UnityEngine.Collider2D other)
        {
            Owner.OnTriggerExit2DEvent(other);
        }
    }
} 
#endif