using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.QuestSystem
{
    public class QuestStage
    {
        [SerializeField]
        private List<string> _stageObjectives = new List<string>();

        [SerializeField]
        private QuestReward _stageCompletionReward;

        public QuestStage(QuestReward stageReward, params string[] stageObjectives)
        {
            _stageCompletionReward = stageReward;
            _stageObjectives.AddRange(stageObjectives);
        }
    }
}
