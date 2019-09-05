/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnCollisionStay2D")]
    public class CSFSMOnCollisionStay2DEvent : CSFSMEvent
    {
        private void OnCollisionStay2D(UnityEngine.Collision2D collision2D)
        {
            Owner.OnCollisionStay2DEvent(collision2D);
        }
    }
} 
#endif