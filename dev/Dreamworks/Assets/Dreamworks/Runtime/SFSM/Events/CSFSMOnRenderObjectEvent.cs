/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnRenderObject")]
    public class CSFSMOnRenderObjectEvent : CSFSMEvent
    {
        private void OnRenderObject()
        {
            Owner.OnRenderObjectEvent();
        }
    }
}