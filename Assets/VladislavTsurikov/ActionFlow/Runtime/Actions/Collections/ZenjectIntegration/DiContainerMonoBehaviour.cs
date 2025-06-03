using UnityEngine;
using Zenject;

namespace QuestsSystem.IntegrationActionFlow
{
    public abstract class DiContainerMonoBehaviour : MonoBehaviour
    {
        protected DiContainer DiContainer;
        
        public void SetContainer(DiContainer container)
        {
            DiContainer = container;
            ApplySetup();
        }

        protected abstract void ApplySetup();
    }
}