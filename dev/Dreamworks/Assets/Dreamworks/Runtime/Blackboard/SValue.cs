/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Blackboard
{
    public abstract class SValue : SScriptableObject
    {
        [SerializeField]
        protected bool IsReadOnly = true;
    }
}