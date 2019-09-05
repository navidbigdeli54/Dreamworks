/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// ITickable interface contains all Tick callbacks that framework has provides.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/24/2018</CreationDate>
    public interface ITickable : INameable
    {
        #region Property
        /// <summary>
        /// If true, this component will get Tick after all objects have been initialized.
        /// </summary>
        bool CanEverTick { get; }

        /// <summary>
        /// If true, this component will get LateTick after all objects have been initialized.
        /// </summary>
        bool CanEverLateTick { get; }

        /// <summary>
        /// If true, this component will get FixedTick after all objects have been initialized.
        /// </summary>
        bool CanEverFixedTick { get; }

        /// <summary>
        /// If true, this component will get Tick before BeginPlay.
        /// </summary>
        bool CanTickBeforePlay { get; }

        /// <summary>
        /// If true, this component will get LateTick before BeginPlay.
        /// </summary>
        bool CanLateTickBeforePlay { get; }

        /// <summary>
        /// If true, this component will get FixedTick beforeBeginPlay.
        /// </summary>
        bool CanFixedTickBeforePlay { get; }
        #endregion

        #region Method
        /// <summary>
        /// Tick is called every frame.
        /// Tick is the most commonly used function to implement any kind of game behavior.
        /// </summary>
        /// <param name="deltaTime">The time in seconds it took to complete the last frame.</param>
        void Tick(float deltaTime);

        /// <summary>
        /// LateTick is called every frame.
        /// LateTick is called after all Tick functions have been called.This is useful to order script execution.
        /// For example a follow camera should always be implemented in LateTick because it tracks objects that might have moved inside Tick.
        /// </summary>
        /// <param name="deltaTime">The time in seconds it took to complete the last frame.</param>
        void LateTick(float deltaTime);

        /// <summary>
        /// This function is called every fixed framerate frame.
        /// FixedTick should be used instead of Update when dealing with Rigidbody.
        /// For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside FixedTick instead of every frame inside Tick.
        /// </summary>
        /// <param name="deltaTime">The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's FixedUpdate) are performed.</param>
        void FixedTick(float deltaTime);
        #endregion
    }
}