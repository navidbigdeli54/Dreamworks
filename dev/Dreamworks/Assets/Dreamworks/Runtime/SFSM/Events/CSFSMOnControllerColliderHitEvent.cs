/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    public class CSFSMOnControllerColliderHitEvent : CSFSMEvent
    {
        [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnControllerColliderHit")]
        private void OnControllerColliderHit(UnityEngine.ControllerColliderHit hit)
        {
            Owner.OnControllerColliderHitEvent(hit);
        }
    }
} 
#endif