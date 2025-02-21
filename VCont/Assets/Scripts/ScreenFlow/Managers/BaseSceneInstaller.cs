namespace ScreenFlow.Managers
{
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;
#if UNITY_EDITOR
#endif

    /// <summary>
    /// Every Mono Scene Installer will be inherited this class
    /// </summary>
    public class BaseSceneInstaller : LifetimeScope
    {
        /// <summary>
        /// Instance of Root UI Canvas on Scene
        /// </summary>
        [SerializeField] protected RootUICanvas rootUICanvas;

        [Inject] private IScreenManager screenManager;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            //todo this should be setup automatically
            if (this.rootUICanvas == null) return;
            this.screenManager.RootUICanvas       = this.rootUICanvas;
            this.screenManager.CurrentRootScreen  = this.rootUICanvas.RootUIShowTransform;
            this.screenManager.CurrentHiddenRoot  = this.rootUICanvas.RootUIClosedTransform;
            this.screenManager.CurrentOverlayRoot = this.rootUICanvas.RootUIOverlayTransform;
        }
    }
}