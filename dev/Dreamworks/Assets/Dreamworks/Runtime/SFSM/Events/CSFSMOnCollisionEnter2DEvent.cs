/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnCollisionEnter2D")]
    public class CSFSMOnCollisionEnter2DEvent : CSFSMEvent
    {
        private void OnCollisionEnter2D(UnityEngine.Collision2D collision2D)
        {
            Owner.OnCollisionEnter2DEvent(collision2D);
        }
    }
} 
#endif