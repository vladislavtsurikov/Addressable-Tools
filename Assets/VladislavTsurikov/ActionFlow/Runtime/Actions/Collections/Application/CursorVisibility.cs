using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Application
{
    [Name("Application/Cursor Visibility")]
    public class CursorVisibility : Action
    {
        [SerializeField]
        private bool _isVisible = true;

        public override string Name => $"Set Cursor Visibility to {_isVisible}";

        protected override UniTask<bool> Run(CancellationToken token)
        {
            Cursor.visible = _isVisible;
            return UniTask.FromResult(true);
        }
    }
}