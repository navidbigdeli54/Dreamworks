using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.SFSM.Core
{
    public abstract class CSFSMBrainNonGeneric : CComponent, ISFSM
    {
        #region IFSMState Implementation
        void ISFSM.OnAnimatorIKEvent() { }

        void ISFSM.OnAnimatorMoveEvent() { }

        void ISFSM.OnApplicationFocuseEvent(bool focuseStatus) { }

        void ISFSM.OnApplicationPauseEvent(bool pauseStatus) { }

        void ISFSM.OnApplicationQuitEvent() { }

        void ISFSM.OnAudioFilterReadEvent(float[] data, int channels) { }

        void ISFSM.OnBecameInvisibleEvent() { }

        void ISFSM.OnBecameVisibleEvent() { }

        void ISFSM.OnParticleCollisionEvent(GameObject other) { }

        void ISFSM.OnParticleTriggerEvent() { }

        void ISFSM.OnPostRenderEvent() { }

        void ISFSM.OnPreCullEvent() { }

        void ISFSM.OnPreRenderEvent() { }

        void ISFSM.OnRenderImageEvent(RenderTexture source, RenderTexture destination) { }

        void ISFSM.OnRenderObjectEvent() { }

        void ISFSM.OnTransformChildrenChangedEvent() { }

        void ISFSM.OnTransformParentChangedEvent() { }

        void ISFSM.OnWillRenderObjectEvent() { }

#if UNITY_EDITOR
        void ISFSM.OnValidateEvent() { }

        void ISFSM.OnDrawGizmosEvent() { }

        void ISFSM.OnDrawGizmosSelectedEvent() { }

        void ISFSM.ResetEvent() { }

        void ISFSM.OnGUIEvent() { }
#endif

#if PHYSIC_3D
        void ISFSM.OnCollisionEnterEvent(Collision collision) { }

        void ISFSM.OnCollisionExitEvent(Collision collision) { }

        void ISFSM.OnTriggerStayEvent(Collider other) { }

        void ISFSM.OnTriggerEnterEvent(Collider other) { }

        void ISFSM.OnTriggerExitEvent(Collider other) { }

        void ISFSM.OnCollisionStayEvent(Collision collision) { }

        void ISFSM.OnControllerColliderHitEvent(ControllerColliderHit hit) { }

        void ISFSM.OnJointBreakEvent(float breakForce) { }
#endif

#if PHYSIC_2D
        void ISFSM.OnCollisionEnter2DEvent(Collision2D collision2D) { }

        void ISFSM.OnCollisionExit2DEvent(Collision2D collision2D) { }

        void ISFSM.OnCollisionStay2DEvent(Collision2D collision2D) { }

        void ISFSM.OnTriggerEnter2DEvent(Collider2D other) { }

        void ISFSM.OnTriggerExit2DEvent(Collider2D other) { }

        void ISFSM.OnTriggerStay2DEvent(Collider2D other) { }

        void ISFSM.OnJointBreak2DEvent(Joint2D brokenJoint) { }
#endif

#if PHYSIC_2D || PHYSIC_3D
        void ISFSM.OnPointerClickHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }

        void ISFSM.OnPointerEnterHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }

        void ISFSM.OnPointerExitHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }

        void ISFSM.OnPointerUpHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }

        void ISFSM.OnPointerDownHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }
#endif

        #endregion
    }
}