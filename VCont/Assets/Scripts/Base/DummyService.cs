namespace Base
{
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    public class DummyService  : IInitializable
    {
        [Inject] IObjectResolver resolver;

        public void Initialize()
        {
            Debug.Log(this.resolver);
        }
    }
}