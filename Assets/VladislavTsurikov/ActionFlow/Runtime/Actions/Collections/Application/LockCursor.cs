using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Application
{
    [Name("Application/Lock Cursor")]
    public class LockCursor : Action
    {
        [SerializeField]
        private CursorLockMode _lockMode = CursorLockMode.Locked;

        public override string Name => $"Set Cursor to {_lockMode}";

        protected override UniTask<bool> Run(CancellationToken token)
        {
            Cursor.lockState = _lockMode;
            return UniTask.FromResult(true);
        }
    }
}