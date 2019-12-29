/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.Core
{

    /// <summary>
    /// ITickable interface contains all Tick callbacks that framework has provides.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/24/2018</CreationDate>
    public interface ITickable : IPureTickable
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
    }
}