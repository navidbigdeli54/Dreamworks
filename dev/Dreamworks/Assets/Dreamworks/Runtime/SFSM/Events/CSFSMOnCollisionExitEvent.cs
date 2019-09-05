/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnCollisionExit")]
    public class CSFSMOnCollisionExitEvent : CSFSMEvent
    {
        private void OnCollisionExit(UnityEngine.Collision collision)
        {
            Owner.OnCollisionExitEvent(collision);
        }
    }
} 
#endif