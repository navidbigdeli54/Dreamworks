/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable CS0649

using System.Threading.Tasks;
using DreamMachineGameStudio.Dreamworks.Core;

namespace DreamMachineGameStudio.Dreamworks.HFSM
{
    public abstract class CHFSMBrain : CComponent
    {
        #region Properties
        protected IHFSM HFSM { get; private set; }
        #endregion

        #region Methods
        protected override async Task PreInitializeComponenetAsync()
        {
            await base.PreInitializeComponenetAsync();

            HFSM = new FHFSM(this);

            await SetupHFSM();

            await HFSM.PreInitializeAsync();
        }

        protected async override Task InitializeComponentAsync()
        {
            await base.InitializeComponentAsync();

            await HFSM.InitializeAsync();
        }

        protected async override Task BeginPlayAsync()
        {
            await base.BeginPlayAsync();

            await HFSM.BeginPlayAsync();
        }

        protected async override Task UninitializeCompoonentAsync()
        {
            await base.UninitializeCompoonentAsync();

            await HFSM.UninitializeAsync();
        }

        protected override void TickComponent(float deltaTime)
        {
            base.TickComponent(deltaTime);

            HFSM.Tick(deltaTime);
        }

        protected override void LateTickComponent(float deltaTime)
        {
            base.LateTickComponent(deltaTime);

            HFSM.LateTick(deltaTime);
        }

        protected override void FixedTickComponent(float deltaTime)
        {
            base.FixedTickComponent(deltaTime);

            HFSM.FixedTick(deltaTime);
        }

        protected abstract Task SetupHFSM();
        #endregion
    }
}