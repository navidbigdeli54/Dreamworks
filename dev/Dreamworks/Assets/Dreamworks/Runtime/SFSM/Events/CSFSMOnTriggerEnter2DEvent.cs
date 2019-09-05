/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnTriggerEnter2D")]
    public class CSFSMOnTriggerEnter2DEvent : CSFSMEvent
    {
        private void OnTriggerEnter2D(UnityEngine.Collider2D other)
        {
            Owner.OnTriggerEnter2DEvent(other);
        }
    }
} 
#endif