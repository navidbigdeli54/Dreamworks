/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/


namespace DreamMachineGameStudio.Dreamworks.Core
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/31/2018</CreationDate>
    public interface IGameManagement : IService
    {
        #region Property
        IGameMode CurrentGameMode { get; }
        #endregion
    }
}