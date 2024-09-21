using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LordBreakerX.Inventory;

namespace LordBreakerX.QuestSystem
{
    [System.Serializable]
    public struct QuestReward
    {
        [SerializeField]
        [Min(0)]
        private int _xpReward;

        [SerializeField]
        private LootTable _lootTableReward;

        public int XpReward { get { return _xpReward; } }

        public LootTable LootTableReward { get { return _lootTableReward; } }

        public QuestReward(int xpReward, LootTable lootTableReward)
        {
            _xpReward = xpReward;
            _lootTableReward = lootTableReward;
        }
    }
}
