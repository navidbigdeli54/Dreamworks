/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnApplicationPause")]
    public class CSFSMOnApplicationPauseEvent : CSFSMEvent
    {
        private void OnApplicationPause(bool pauseState)
        {
            Owner.OnApplicationPauseEvent(pauseState);
        }
    }
}