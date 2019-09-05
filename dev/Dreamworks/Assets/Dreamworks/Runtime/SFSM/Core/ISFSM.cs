/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using UnityEngine.EventSystems;

namespace DreamMachineGameStudio.Dreamworks.SFSM.Core
{
    public interface ISFSM
    {
        #region Method
        void OnAnimatorIKEvent();

        void OnAnimatorMoveEvent();

        void OnApplicationFocuseEvent(bool focuseStatus);

        void OnApplicationPauseEvent(bool pauseStatus);

        void OnApplicationQuitEvent();

        void OnAudioFilterReadEvent(float[] data, int channels);

        void OnBecameInvisibleEvent();

        void OnBecameVisibleEvent();

        void OnPostRenderEvent();

        void OnPreRenderEvent();

        void OnPreCullEvent();

        void OnRenderImageEvent(RenderTexture source, RenderTexture destination);

        void OnRenderObjectEvent();

        void OnWillRenderObjectEvent();

        void OnTransformChildrenChangedEvent();

        void OnTransformParentChangedEvent();

        void OnParticleTriggerEvent();

        void OnParticleCollisionEvent(GameObject other);

#if UNITY_EDITOR
        void OnValidateEvent();

        void OnDrawGizmosSelectedEvent();

        void OnDrawGizmosEvent();

        void ResetEvent();

        void OnGUIEvent();
#endif

#if PHYSIC_3D
        void OnCollisionEnterEvent(Collision collision);

        void OnCollisionExitEvent(Collision collision);

        void OnCollisionStayEvent(Collision collision);

        void OnTriggerEnterEvent(Collider other);

        void OnTriggerExitEvent(Collider other);

        void OnTriggerStayEvent(Collider other);

        void OnControllerColliderHitEvent(ControllerColliderHit hit);

        void OnJointBreakEvent(float breakForce);
#endif

#if PHYSIC_2D
        void OnCollisionEnter2DEvent(Collision2D collision2D);

        void OnCollisionExit2DEvent(Collision2D collision2D);

        void OnCollisionStay2DEvent(Collision2D collision2D);

        void OnJointBreak2DEvent(Joint2D brokenJoint);

        void OnTriggerEnter2DEvent(Collider2D other);

        void OnTriggerExit2DEvent(Collider2D other);

        void OnTriggerStay2DEvent(Collider2D other);
#endif

#if PHYSIC_2D || PHYSIC_3D
        void OnPointerClickHandlerEvent(PointerEventData eventData);

        void OnPointerEnterHandlerEvent(PointerEventData eventData);

        void OnPointerExitHandlerEvent(PointerEventData eventData);

        void OnPointerUpHandlerEvent(PointerEventData eventData);

        void OnPointerDownHandlerEvent(PointerEventData eventData);
#endif

        #endregion
    }
}