namespace BlueprintFlow.BlueprintControlFlow
{
    using Base;
    using BlueprintFlow.BlueprintReader;
    using GameFoundation.Observer.MessagePipe;
    using Services.BlueprintControlFlow.BlueprintSignal;
    using VContainer;

    /// <summary>
    /// Binding all services of the blueprint control flow at here
    /// </summary>
    public class BlueprintServicesInstaller : Installer<BlueprintServicesInstaller>
    {
        protected override void InstallBinding(IContainerBuilder builder, IObjectResolver resolver)
        {
            //BindBlueprint reader for mobile
            builder.Register<PreProcessBlueprintMobile>(Lifetime.Singleton);
            builder.Register<BlueprintReaderManager>(Lifetime.Singleton);
            builder.Register<BlueprintConfig>(Lifetime.Singleton); // TODO: Find instance in GDK Config
            builder.RegisterAllTypeDerivedFrom<IGenericBlueprintReader>();

            builder.DeclareSignal<LoadBlueprintDataSucceedSignal>();
            builder.DeclareSignal<LoadBlueprintDataProgressSignal>();
            builder.DeclareSignal<ReadBlueprintProgressSignal>();
        }
    }
}