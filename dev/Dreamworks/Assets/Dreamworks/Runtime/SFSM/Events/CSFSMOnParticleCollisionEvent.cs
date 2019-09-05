/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.SFSM.Event
{
    [UnityEngine.AddComponentMenu("DreamMachineGameStudio/SFSM/Event/OnParticleCollision")]
    public class CSFSMOnParticleCollisionEvent : CSFSMEvent
    {
        private void OnParticleCollision(UnityEngine.GameObject other)
        {
            Owner.OnParticleCollisionEvent(other);
        }
    }
}