/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if UNITY_EDITOR
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/Reset")]
    public class CSFSMResetEvent : CSFSMEvent
    {
        private void Reset()
        {
            Owner.ResetEvent();
        }
    }
} 
#endif