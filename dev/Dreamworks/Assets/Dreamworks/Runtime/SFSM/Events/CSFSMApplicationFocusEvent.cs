/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    public class CSFSMOnApplicationFocusEvent : CSFSMEvent
    {
        [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnApplicationFocuse")]
        private void OnApplicationFocus(bool focusState)
        {
            Owner.OnApplicationFocuseEvent(focusState);
        }
    }
}