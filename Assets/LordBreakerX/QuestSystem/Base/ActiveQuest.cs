using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.QuestSystem
{
    public class ActiveQuest
    {
        private Quest _quest;
        private int _currentStageIndex;
        private int _currentObjectiveIndex;

        private ActiveQuest(Quest quest)
        {
            _quest = quest;
            _currentStageIndex = 0;
            _currentObjectiveIndex = 0;
        }

        public static void AddQuest(QuestPerformer questPerformer, Quest quest)
        {
            if (quest != null && questPerformer != null)
            {
                ActiveQuest activeQuest = new ActiveQuest(quest);
            }
        }
    }
}
