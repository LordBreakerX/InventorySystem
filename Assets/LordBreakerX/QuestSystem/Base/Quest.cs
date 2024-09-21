using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.QuestSystem
{
    [CreateAssetMenu()]
    public class Quest : ScriptableObject
    {
        [SerializeField]
        private string _title;
        [SerializeField]
        private string _description;
        [SerializeField]
        private QuestReward _completionReward;

        public virtual void OnQuestStarted()
        {
            
        }

        

    }
}
