/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System.Threading.Tasks;

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/24/2018</CreationDate>
    public abstract class FGameMode : IGameMode
    {
        #region Property
        protected string Name { get; set; }

        protected bool HasInitialized { get; private set; }

        protected bool HasBeganPlay { get; private set; }

        protected bool CanEverTick { get; set; }

        protected bool CanEverLateTick { get; set; }

        protected bool CanEverFixedTick { get; set; }

        protected bool CanTickBeforePlay { get; set; }

        protected bool CanLateTickBeforePlay { get; set; }

        protected bool CanFixedTickBeforePlay { get; set; }
        #endregion

        #region Method
        protected virtual Task PreInitializeAsync() => Task.CompletedTask;

        protected virtual Task InitializeAsync() => Task.CompletedTask;

        protected virtual Task BeginPlayAsync() => Task.CompletedTask;

        protected virtual Task UninitializeAsync() => Task.CompletedTask;

        protected virtual void Tick(float deltaTime) { }

        protected virtual void LateTick(float deltaTime) { }

        protected virtual void FixedTick(float deltaTime) { }

        #endregion

        #region IGameMode Implementation
        string INameable.Name { get => Name; }

        bool IInitializable.HasRegistered => false;

        bool IInitializable.HasInitialized => HasInitialized;

        bool IInitializable.HasBeganPlay => HasBeganPlay;

        bool ITickable.CanEverTick => CanEverTick;

        bool ITickable.CanEverLateTick => CanEverLateTick;

        bool ITickable.CanEverFixedTick => CanEverFixedTick;

        bool ITickable.CanTickBeforePlay => CanTickBeforePlay;

        bool ITickable.CanLateTickBeforePlay => CanLateTickBeforePlay;

        bool ITickable.CanFixedTickBeforePlay => CanFixedTickBeforePlay;

        async Task IPureInitializable.PreInitializeAsync() => await PreInitializeAsync();

        async Task IPureInitializable.InitializeAsync()
        {
            await InitializeAsync();

            HasInitialized = true;
        }

        async Task IPureInitializable.BeginPlayAsync()
        {
            await BeginPlayAsync();

            HasBeganPlay = true;
        }

        async Task IPureInitializable.UninitializeAsync() => await UninitializeAsync();

        void IPureTickable.Tick(float deltaTime) => Tick(deltaTime);

        void IPureTickable.LateTick(float deltaTime) => LateTick(deltaTime);

        void IPureTickable.FixedTick(float deltaTime) => FixedTick(deltaTime);
        #endregion
    }
}