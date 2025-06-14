using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Animator
{
    [Name("Animator/Set Trigger")]
    public class SetAnimatorTrigger : ActionAnimator
    {
        [SerializeField]
        private string _parameter = "My Parameter";

        public override string Name => $"Set Animator Trigger {_parameter}";

        protected override UniTask<bool> Run(CancellationToken token)
        {
            Animator.SetTrigger(_parameter);
            return UniTask.FromResult(true);
        }
    }
}