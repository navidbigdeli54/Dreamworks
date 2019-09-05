/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

#if UNITY_EDITOR
namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnDrawGizmosSelected")]
    public class CSFSMOnDrawGizmosSelectedEvent : CSFSMEvent
    {
        private void OnDrawGizmosSelected()
        {
            Owner.OnDrawGizmosSelectedEvent();
        }
    }
} 
#endif