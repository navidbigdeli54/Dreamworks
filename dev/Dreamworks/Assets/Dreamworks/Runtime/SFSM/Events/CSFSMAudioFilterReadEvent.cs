/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnAudioFilterRead")]
    public class CSFSMOnAudioFilterReadEvent : CSFSMEvent
    {
        private void OnAudioFilterRead(float[] data, int channels)
        {
            Owner.OnAudioFilterReadEvent(data, channels);
        }
    }
}