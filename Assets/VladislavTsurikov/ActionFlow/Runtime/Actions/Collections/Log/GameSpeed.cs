﻿using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Log
{
    [Name("Debug/Time Scale")]
    public class GameSpeed : Action
    {
        [SerializeField, Min(0)] private float _speed = 1;
        
        protected override UniTask<bool> Run(CancellationToken token)
        {
            Time.timeScale = _speed;
            return UniTask.FromResult(true);
        }
    }
}