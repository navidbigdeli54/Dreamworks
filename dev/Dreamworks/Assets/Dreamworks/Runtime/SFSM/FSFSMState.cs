/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using System.Threading.Tasks;
using DreamMachineGameStudio.Dreamworks.SFSM.Core;

namespace DreamMachineGameStudio.Dreamworks.SFSM
{
    public abstract class FSFSMState<TBrain> : ISFSMState<TBrain> where TBrain : ISFSMBrain<TBrain>
    {
        #region Property
        protected TBrain Owner { get; }
        #endregion

        #region Constructor
        public FSFSMState(TBrain brain) => this.Owner = brain;
        #endregion

        #region Method
        protected void PushState<TState>() where TState : ISFSMState<TBrain> => Owner.PushState<TState>();

        protected void ChangeState<TState>() where TState : ISFSMState<TBrain> => Owner.ChangeState<TState>();

        protected void PopState() => Owner.PopState();

        protected virtual void OnEnterEvent() { }

        protected virtual void OnExitEvent() { }

        protected virtual Task PreInitializeEventAsync() => Task.CompletedTask;

        protected virtual Task InitializeEventAsync() => Task.CompletedTask;

        protected virtual Task BeginPlayEventAsync() => Task.CompletedTask;

        protected virtual Task UninitializeEventAsync() => Task.CompletedTask;

        protected virtual void TickEvent(float deltaTime) { }

        protected virtual void LateTickEvent(float deltaTime) { }

        protected virtual void FixedTickEvent(float deltaTime) { }

        protected virtual void OnAnimatorIKEvent() { }

        protected virtual void OnAnimatorMoveEvent() { }

        protected virtual void OnApplicationFocuseEvent(bool focuseStatus) { }

        protected virtual void OnApplicationPauseEvent(bool pauseStatus) { }

        protected virtual void OnApplicationQuitEvent() { }

        protected virtual void OnAudioFilterReadEvent(float[] data, int channels) { }

        protected virtual void OnBecameInvisibleEvent() { }

        protected virtual void OnBecameVisibleEvent() { }

        protected virtual void OnParticleCollisionEvent(GameObject other) { }

        protected virtual void OnParticleTriggerEvent() { }

        protected virtual void OnDestroyEvent() { }

        protected virtual void OnDisableEvent() { }

        protected virtual void OnEnableEvent() { }

        protected virtual void OnGUIEvent() { }

        protected virtual void OnPostRenderEvent() { }

        protected virtual void OnPreRenderEvent() { }

        protected virtual void OnPreCullEvent() { }

        protected virtual void OnRenderImageEvent(RenderTexture source, RenderTexture destination) { }

        protected virtual void OnRenderObjectEvent() { }

        protected virtual void OnWillRenderObjectEvent() { }

        protected virtual void OnTransformChildrenChangedEvent() { }

        protected virtual void OnTransformParentChangedEvent() { }

#if UNITY_EDITOR
        protected virtual void OnValidateEvent() { }

        protected virtual void ResetEvent() { }

        protected virtual void OnDrawGizmosEvent() { }

        protected virtual void OnDrawGizmosSelectedEvent() { }
#endif

#if PHYSIC_3D
        protected virtual void OnCollisionEnterEvent(Collision collision) { }

        protected virtual void OnCollisionExitEvent(Collision collision) { }

        protected virtual void OnCollisionStayEvent(Collision collision) { }

        protected virtual void OnTriggerEnterEvent(Collider other) { }

        protected virtual void OnTriggerExitEvent(Collider other) { }

        protected virtual void OnTriggerStayEvent(Collider other) { }

        protected virtual void OnControllerColliderHitEvent(ControllerColliderHit hit) { }

        protected virtual void OnJointBreakEvent(float breakForce) { }
#endif

#if PHYSIC_2D

        protected virtual void OnCollisionEnter2DEvent(Collision2D collision2D) { }

        protected virtual void OnCollisionExit2DEvent(Collision2D collision2D) { }

        protected virtual void OnCollisionStay2DEvent(Collision2D collision2D) { }

        protected virtual void OnJointBreak2DEvent(Joint2D brokenJoint) { }

        protected virtual void OnTriggerEnter2DEvent(Collider2D other) { }

        protected virtual void OnTriggerExit2DEvent(Collider2D other) { }

        protected virtual void OnTriggerStay2DEvent(Collider2D other) { }
#endif

#if PHYSIC_2D || PHYSIC_3D
        protected virtual void OnPointerClickHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }
        protected virtual void OnPointerEnterHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }
        protected virtual void OnPointerExitHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }
        protected virtual void OnPointerUpHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }
        protected virtual void OnPointerDownHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) { }
#endif

        #endregion

        #region IFSMState Implementation
        TBrain ISFSMState<TBrain>.Owner => Owner;

        void ISFSMState<TBrain>.OnEnterEvent() => OnEnterEvent();

        void ISFSMState<TBrain>.OnExitEvent() => OnExitEvent();

        Task ISFSMState<TBrain>.PreInitializeEventAsync() => PreInitializeEventAsync();

        Task ISFSMState<TBrain>.InitializeEventAsync() => InitializeEventAsync();

        Task ISFSMState<TBrain>.BeginPlayEventAsync() => BeginPlayEventAsync();

        Task ISFSMState<TBrain>.UninitializeEventAsync() => UninitializeEventAsync();

        void ISFSMState<TBrain>.TickEvent(float deltaTime) => TickEvent(deltaTime);

        void ISFSMState<TBrain>.LateTickEvent(float deltaTime) => LateTickEvent(deltaTime);

        void ISFSMState<TBrain>.FixedTickEvent(float deltaTime) => FixedTickEvent(deltaTime);

        void ISFSMState<TBrain>.OnDisableEvent() => OnDisableEvent();

        void ISFSMState<TBrain>.OnEnableEvent() => OnEnableEvent();

        void ISFSM.OnAnimatorIKEvent() => OnAnimatorIKEvent();

        void ISFSM.OnAnimatorMoveEvent() => OnAnimatorMoveEvent();

        void ISFSM.OnApplicationFocuseEvent(bool focuseStatus) => OnApplicationFocuseEvent(focuseStatus);

        void ISFSM.OnApplicationPauseEvent(bool pauseStatus) => OnApplicationPauseEvent(pauseStatus);

        void ISFSM.OnApplicationQuitEvent() => OnApplicationQuitEvent();

        void ISFSM.OnAudioFilterReadEvent(float[] data, int channels) => OnAudioFilterReadEvent(data, channels);

        void ISFSM.OnBecameInvisibleEvent() => OnBecameInvisibleEvent();

        void ISFSM.OnBecameVisibleEvent() => OnBecameVisibleEvent();

        void ISFSM.OnParticleCollisionEvent(GameObject other) => OnParticleCollisionEvent(other);

        void ISFSM.OnParticleTriggerEvent() => OnParticleTriggerEvent();

        void ISFSM.OnPostRenderEvent() => OnPostRenderEvent();

        void ISFSM.OnPreCullEvent() => OnPreCullEvent();

        void ISFSM.OnPreRenderEvent() => OnPreRenderEvent();

        void ISFSM.OnRenderImageEvent(RenderTexture source, RenderTexture destination) => OnRenderImageEvent(source, destination);

        void ISFSM.OnRenderObjectEvent() => OnRenderObjectEvent();

        void ISFSM.OnTransformChildrenChangedEvent() => OnTransformChildrenChangedEvent();

        void ISFSM.OnTransformParentChangedEvent() => OnTransformChildrenChangedEvent();

        void ISFSM.OnWillRenderObjectEvent() => OnWillRenderObjectEvent();

#if UNITY_EDITOR
        void ISFSM.ResetEvent() => ResetEvent();

        void ISFSM.OnValidateEvent() => OnValidateEvent();

        void ISFSM.OnDrawGizmosEvent() => OnDrawGizmosEvent();

        void ISFSM.OnDrawGizmosSelectedEvent() => OnDrawGizmosSelectedEvent();

        void ISFSM.OnGUIEvent() => OnGUIEvent();
#endif

#if PHYSIC_3D

        void ISFSM.OnCollisionEnterEvent(Collision collision) => OnCollisionEnterEvent(collision);

        void ISFSM.OnCollisionExitEvent(Collision collision) => OnCollisionExitEvent(collision);

        void ISFSM.OnCollisionStayEvent(Collision collision) => OnCollisionStayEvent(collision);

        void ISFSM.OnControllerColliderHitEvent(ControllerColliderHit hit) => OnControllerColliderHitEvent(hit);

        void ISFSM.OnTriggerEnterEvent(Collider other) => OnTriggerEnterEvent(other);

        void ISFSM.OnTriggerExitEvent(Collider other) => OnTriggerExitEvent(other);

        void ISFSM.OnTriggerStayEvent(Collider other) => OnTriggerStayEvent(other);

        void ISFSM.OnJointBreakEvent(float breakForce) => OnJointBreakEvent(breakForce);
#endif

#if PHYSIC_2D
        void ISFSM.OnCollisionEnter2DEvent(Collision2D collision2D) => OnCollisionEnter2DEvent(collision2D);

        void ISFSM.OnCollisionExit2DEvent(Collision2D collision2D) => OnCollisionExit2DEvent(collision2D);

        void ISFSM.OnTriggerExit2DEvent(Collider2D other) => OnTriggerExit2DEvent(other);

        void ISFSM.OnCollisionStay2DEvent(Collision2D collision2D) => OnCollisionStay2DEvent(collision2D);

        void ISFSM.OnTriggerStay2DEvent(Collider2D other) => OnTriggerStay2DEvent(other);

        void ISFSM.OnTriggerEnter2DEvent(Collider2D other) => OnTriggerEnter2DEvent(other);

        void ISFSM.OnJointBreak2DEvent(Joint2D brokenJoint) => OnJointBreak2DEvent(brokenJoint);
#endif

#if PHYSIC_2D || PHYSIC_3D
        void ISFSM.OnPointerClickHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => OnPointerClickHandlerEvent(eventData);

        void ISFSM.OnPointerEnterHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => OnPointerEnterHandlerEvent(eventData);

        void ISFSM.OnPointerExitHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => OnPointerExitHandlerEvent(eventData);

        void ISFSM.OnPointerUpHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => OnPointerUpHandlerEvent(eventData);

        void ISFSM.OnPointerDownHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => OnPointerDownHandlerEvent(eventData);
#endif

        #endregion
    }
}