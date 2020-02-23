/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;

namespace DreamMachineGameStudio.Dreamworks.Variant
{
    public interface IValue : IEquatable<IValue>, IComparable<IValue>
    {
        #region Fields
        bool IsReadOnly { get; }
        #endregion
    }
}