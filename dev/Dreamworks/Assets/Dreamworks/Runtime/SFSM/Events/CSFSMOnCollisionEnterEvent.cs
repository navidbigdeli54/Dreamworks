/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    public class CSFSMOnCollisionEnterEvent : CSFSMEvent
    {
        [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnCollisionEnter")]
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            Owner.OnCollisionEnterEvent(collision);
        }
    }
} 
#endif