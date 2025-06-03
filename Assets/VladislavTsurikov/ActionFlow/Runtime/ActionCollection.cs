using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ActionFlow.Runtime.Actions;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime
{
    public class ActionCollection : ComponentStackSupportSameType<Action>
    {
        public async UniTask<bool> Run(CancellationToken token = default)
        {
            foreach (var action in ElementList)
            {
                token.ThrowIfCancellationRequested();
                bool isActionCompleted =  await action.RunAction(token);

                if (!isActionCompleted)
                {
                    return false;
                }
            }

            return true;
        }
    }
}