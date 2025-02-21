namespace Base
{
    using BlueprintFlow.BlueprintControlFlow;
    using GameFoundation;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    public class GameProjectInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            GameFoundationInstaller.Install(builder, this.Container);
        }
    }
}