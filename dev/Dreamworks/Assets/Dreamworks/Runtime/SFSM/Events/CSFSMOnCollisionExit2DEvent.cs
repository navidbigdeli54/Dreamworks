/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnCollisionExit2D")]
    public class CSFSMOnCollisionExit2DEvent : CSFSMEvent
    {
        private void OnCollisionExit2D(UnityEngine.Collision2D collision2D)
        {
            Owner.OnCollisionExit2DEvent(collision2D);
        }
    }
} 
#endif