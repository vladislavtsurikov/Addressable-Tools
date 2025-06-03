using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Application
{
    [Name("Application/Open Web Page")]
    public class OpenWebPage : Action
    {
        [SerializeField]
        private string _url = "https://www.google.ru";

        public override string Name => $"Open Browser URL: {_url}";

        protected override UniTask<bool> Run(CancellationToken token)
        {
            UnityEngine.Application.OpenURL(_url);
            return UniTask.FromResult(true);
        }
    }
}