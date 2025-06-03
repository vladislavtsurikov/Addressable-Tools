using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Log
{
    [Name("Debug/Log Text")]
    public class LogTextAction : Action
    {
        [SerializeField]
        private string _message = "My message"; 

        public override string Name => $"Log: {_message}";

        protected override UniTask<bool> Run(CancellationToken token)
        {
            Debug.Log(_message);
            return UniTask.FromResult(true);
        }
    }
}