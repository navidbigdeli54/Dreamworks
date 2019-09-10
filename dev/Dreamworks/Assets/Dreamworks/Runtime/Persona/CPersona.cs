/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using UnityEngine;
using System.Threading.Tasks;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.Persona
{
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>August/5/2019</CreationDate>
    [RequireComponent(typeof(Animation))]
    public class CPersona : CComponent
    {
        #region Field
        private new Animation animation;
        #endregion

        #region Method
        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            animation = GetComponent<Animation>();

            animation.playAutomatically = false;
        }
        #endregion
    }
}