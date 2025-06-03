using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Utility
{
    [Name("Utility/Delay")]
    public class Delay : Action
    {
        [SerializeField, Min(0)] private float _seconds = 0;
        
        public override string Name => $"Delay {_seconds} sec.";
    
        protected override async UniTask<bool> Run(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_seconds), cancellationToken: token);
            return true;
        }
    }
}