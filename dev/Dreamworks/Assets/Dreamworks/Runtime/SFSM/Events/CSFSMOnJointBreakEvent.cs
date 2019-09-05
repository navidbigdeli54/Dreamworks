/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_3D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    public class CSFSMOnJointBreakEvent : CSFSMEvent
    {
        [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnJointBreak")]
        private void OnJointBreak(float breakForce)
        {
            Owner.OnJointBreakEvent(breakForce);
        }
    }
} 
#endif