/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if PHYSIC_2D
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnJointBreak2D")]
    public class CSFSMOnJointBreak2DEvent : CSFSMEvent
    {
        private void OnJointBreak2D(UnityEngine.Joint2D brokenJoint)
        {
            Owner.OnJointBreak2DEvent(brokenJoint);
        }
    }
} 
#endif