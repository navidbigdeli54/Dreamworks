/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Debug;
using DreamMachineGameStudio.Dreamworks.SFSM.Core;

namespace DreamMachineGameStudio.Dreamworks.SFSM
{
    public abstract class CSFSMBrain<TBrain> : CSFSMBrainNonGeneric, ISFSMBrain<TBrain>, ISFSM where TBrain : ISFSMBrain<TBrain>
    {
        #region Field
        private Stack<ISFSMState<TBrain>> states = new Stack<ISFSMState<TBrain>>();

        private Dictionary<Type, ISFSMState<TBrain>> statePool = new Dictionary<Type, ISFSMState<TBrain>>();
        #endregion

        #region Properties
        /*
        * TODO:
        * @navidbigdeli54
        * It may be better if we cache current state when we going to change stack. Needs some performance check.
        */
        protected ISFSMState<TBrain> CurrentState => states.Count > 0 ? states?.Peek() : null;
        #endregion

        #region Method
        public void PushState<TState>()
        {
            Type type = typeof(TState);

            if (statePool.ContainsKey(type))
            {
                if (states.Count > 0)
                    CurrentState?.OnExitEvent();

                ISFSMState<TBrain> cachedState = statePool[type];

                cachedState.OnEnterEvent();

                states.Push(cachedState);
            }
        }

        public void PopState()
        {
            CurrentState?.OnExitEvent();

            states.Pop();

            CurrentState?.OnEnterEvent();
        }

        public void ChangeState<TState>()
        {
            PopState();

            PushState<TState>();
        }

        protected async override Task PreInitializeComponenetAsync()
        {
            await base.PreInitializeComponenetAsync();

            try
            {
                RegisterEvents();
            }
            catch (Exception exception)
            {
                FLog.LogError(exception, null, CLASS_TYPE.Name);
            }

            try
            {
                RegisterStates(statePool);
            }
            catch (Exception exception)
            {
                FLog.LogError(exception, null, CLASS_TYPE.Name);
            }

            foreach (var state in statePool)
            {
                try
                {
                    await state.Value.PreInitializeEventAsync();
                }
                catch (Exception exception)
                {
                    FLog.LogError(exception, null, CLASS_TYPE.Name);
                }
            }
        }

        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            foreach (var state in statePool)
            {
                try
                {
                    await state.Value.InitializeEventAsync();
                }
                catch (Exception exception)
                {
                    FLog.LogError(exception, null, CLASS_TYPE.Name);
                }
            }
        }

        protected async override Task BeginPlayAsync()
        {
            await base.BeginPlayAsync();

            foreach (var state in statePool)
            {
                try
                {
                    await state.Value.BeginPlayEventAsync();
                }
                catch (Exception exception)
                {
                    FLog.LogError(exception, null, CLASS_TYPE.Name);
                }
            }
        }

        protected async override Task UninitializeCompoonentAsync()
        {
            await base.UninitializeCompoonentAsync();

            foreach (var state in statePool)
            {
                try
                {
                    await state.Value.UninitializeEventAsync();
                }
                catch (Exception exception)
                {
                    FLog.LogError(exception, null, CLASS_TYPE.Name);
                }
            }
        }

        protected override void TickComponent(float deltaTime)
        {
            base.TickComponent(deltaTime);

            CurrentState?.TickEvent(deltaTime);
        }

        protected override void LateTickComponent(float deltaTime)
        {
            base.LateTickComponent(deltaTime);

            CurrentState?.LateTickEvent(deltaTime);
        }

        protected override void FixedTickComponent(float deltaTime)
        {
            base.FixedTickComponent(deltaTime);

            CurrentState?.FixedTickEvent(deltaTime);
        }

        protected override void OnEnableComponenet()
        {
            base.OnEnableComponenet();

            CurrentState?.OnEnableEvent();
        }

        protected override void OnDisableComponent()
        {
            base.OnDisableComponent();

            CurrentState?.OnDisableEvent();
        }

        protected virtual void RegisterStates(Dictionary<Type, ISFSMState<TBrain>> statePool) { }

        protected virtual void RegisterEvents() { }
        #endregion

        #region IFSMBrain Implementation
        ISFSMState<TBrain> ISFSMBrain<TBrain>.CurrentState => CurrentState;

        void ISFSMBrain<TBrain>.PushState<TState>() => PushState<TState>();

        void ISFSMBrain<TBrain>.PopState() => PopState();

        void ISFSMBrain<TBrain>.ChangeState<TState>() => ChangeState<TState>();
        #endregion

        #region ISFMS Implementation
        void ISFSM.OnAnimatorIKEvent() => CurrentState?.OnAnimatorIKEvent();

        void ISFSM.OnAnimatorMoveEvent() => CurrentState?.OnAnimatorMoveEvent();

        void ISFSM.OnApplicationFocuseEvent(bool focuseStatus) => CurrentState?.OnApplicationFocuseEvent(focuseStatus);

        void ISFSM.OnApplicationPauseEvent(bool pauseStatus) => CurrentState?.OnApplicationPauseEvent(pauseStatus);

        void ISFSM.OnApplicationQuitEvent() => CurrentState?.OnApplicationQuitEvent();

        void ISFSM.OnAudioFilterReadEvent(float[] data, int channels) => CurrentState?.OnAudioFilterReadEvent(data, channels);

        void ISFSM.OnBecameInvisibleEvent() => CurrentState?.OnBecameInvisibleEvent();

        void ISFSM.OnBecameVisibleEvent() => CurrentState?.OnBecameVisibleEvent();

        void ISFSM.OnParticleCollisionEvent(GameObject other) => CurrentState?.OnParticleCollisionEvent(other);

        void ISFSM.OnParticleTriggerEvent() => CurrentState?.OnParticleTriggerEvent();

        void ISFSM.OnPostRenderEvent() => CurrentState?.OnPostRenderEvent();

        void ISFSM.OnPreCullEvent() => CurrentState?.OnPreCullEvent();

        void ISFSM.OnPreRenderEvent() => CurrentState?.OnPreRenderEvent();

        void ISFSM.OnRenderImageEvent(RenderTexture source, RenderTexture destination) => CurrentState?.OnRenderImageEvent(source, destination);

        void ISFSM.OnRenderObjectEvent() => CurrentState?.OnRenderObjectEvent();

        void ISFSM.OnTransformChildrenChangedEvent() => CurrentState?.OnTransformChildrenChangedEvent();

        void ISFSM.OnTransformParentChangedEvent() => CurrentState?.OnTransformParentChangedEvent();

        void ISFSM.OnWillRenderObjectEvent() => CurrentState?.OnWillRenderObjectEvent();



#if UNITY_EDITOR
        void ISFSM.ResetEvent() => CurrentState?.ResetEvent();

        void ISFSM.OnGUIEvent() => CurrentState?.OnGUIEvent();

        void ISFSM.OnDrawGizmosEvent() => CurrentState?.OnDrawGizmosEvent();

        void ISFSM.OnDrawGizmosSelectedEvent() => CurrentState?.OnDrawGizmosSelectedEvent();

        void ISFSM.OnValidateEvent() => CurrentState?.OnValidateEvent();
#endif

#if PHYSIC_3D   
        void ISFSM.OnTriggerEnterEvent(Collider other) => CurrentState?.OnTriggerEnterEvent(other);

        void ISFSM.OnTriggerStayEvent(Collider other) => CurrentState?.OnTriggerStayEvent(other);

        void ISFSM.OnTriggerExitEvent(Collider other) => CurrentState?.OnTriggerExitEvent(other);

        void ISFSM.OnCollisionEnterEvent(Collision collision) => CurrentState?.OnCollisionEnterEvent(collision);

        void ISFSM.OnCollisionStayEvent(Collision collision) => CurrentState?.OnCollisionStayEvent(collision);

        void ISFSM.OnCollisionExitEvent(Collision collision) => CurrentState?.OnCollisionExitEvent(collision);

        void ISFSM.OnControllerColliderHitEvent(ControllerColliderHit hit) => CurrentState?.OnControllerColliderHitEvent(hit);

        void ISFSM.OnJointBreakEvent(float breakForce) => CurrentState?.OnJointBreakEvent(breakForce);
#endif

#if PHYSIC_2D
        void ISFSM.OnCollisionEnter2DEvent(Collision2D collision2D) => CurrentState?.OnCollisionEnter2DEvent(collision2D);

        void ISFSM.OnCollisionStay2DEvent(Collision2D collision2D) => CurrentState?.OnCollisionStay2DEvent(collision2D);

        void ISFSM.OnCollisionExit2DEvent(Collision2D collision2D) => CurrentState?.OnCollisionExit2DEvent(collision2D);

        void ISFSM.OnTriggerEnter2DEvent(Collider2D other) => CurrentState?.OnTriggerEnter2DEvent(other);

        void ISFSM.OnTriggerStay2DEvent(Collider2D other) => CurrentState?.OnTriggerStay2DEvent(other);

        void ISFSM.OnTriggerExit2DEvent(Collider2D other) => CurrentState?.OnTriggerExit2DEvent(other);

        void ISFSM.OnJointBreak2DEvent(Joint2D brokenJoint) => CurrentState?.OnJointBreak2DEvent(brokenJoint);
#endif

#if PHYSIC_2D || PHYSIC_3D
        void ISFSM.OnPointerClickHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => CurrentState?.OnPointerClickHandlerEvent(eventData);

        void ISFSM.OnPointerEnterHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => CurrentState?.OnPointerEnterHandlerEvent(eventData);

        void ISFSM.OnPointerExitHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => CurrentState?.OnPointerExitHandlerEvent(eventData);

        void ISFSM.OnPointerUpHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => CurrentState?.OnPointerUpHandlerEvent(eventData);

        void ISFSM.OnPointerDownHandlerEvent(UnityEngine.EventSystems.PointerEventData eventData) => CurrentState?.OnPointerDownHandlerEvent(eventData);
#endif

        #endregion
    }
}