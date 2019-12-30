/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <summary>
    /// IInitializable contains all Initialization callbacks that framework has provides.
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>April/24/2018</CreationDate>
    public interface IInitializable : IPureInitializable
    {
        #region Property
        /// <summary>
        /// If true, this object has been registered to the framework, otherwise not.
        /// </summary>
        bool HasRegistered { get; }

        /// <summary>
        /// If true, object's PreInitializeComponent and InitializeComponent has been called, otherwise not.
        /// </summary>
        bool HasInitialized { get; }

        /// <summary>
        /// If true, object's BeginPlay has been called, otherwise not.
        /// </summary>
        bool HasBeganPlay { get; }
        #endregion
    }
}