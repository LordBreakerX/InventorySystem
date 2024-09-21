using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.QuestSystem
{
    public abstract class Objective : ScriptableObject
    {
        [SerializeField]
        private bool isOptional;

        public abstract string GetMiniDescription();

        public abstract void OnObjectiveStarted();
        public abstract void OnObjectiveCompleted();
        public abstract void OnObjectiveFailed();

        public abstract void OnObjectiveUpdate();

    }
}
