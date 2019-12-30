/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0051

using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Debug;

namespace DreamMachineGameStudio.Dreamworks.EventManager
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>December/18/2019</CreationDate>
    public class CEventPublisher : CComponent
    {
        #region Methods
        private void Publish(string eventName)
        {
            FAssert.IsFalse(string.IsNullOrWhiteSpace(eventName));
            FEventManager.Publish(eventName);
        }
        #endregion
    }
}