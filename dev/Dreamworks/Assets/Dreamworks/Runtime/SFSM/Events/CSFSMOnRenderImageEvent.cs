/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    public class CSFSMOnRenderImageEvent : CSFSMEvent
    {
        [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnRenderImage")]
        private void OnRenderImage(UnityEngine.RenderTexture source, UnityEngine.RenderTexture destination)
        {
            Owner.OnRenderImageEvent(source, destination);
        }
    }
}