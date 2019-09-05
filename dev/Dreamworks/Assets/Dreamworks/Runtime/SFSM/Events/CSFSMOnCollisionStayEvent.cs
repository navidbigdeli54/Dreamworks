/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnCollisionStay")]
    public class CSFSMOnCollisionStayEvent : CSFSMEvent
    {
        private void OnCollisionStay(UnityEngine.Collision collision)
        {
            Owner.OnCollisionStayEvent(collision);
        }
    }
} 
#endif