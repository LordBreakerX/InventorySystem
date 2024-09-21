using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/LootTable")]
    public class LootTable : ScriptableObject
    {
        [SerializeField]
        [Min(1)]
        private int _minRolls = 1;

        [SerializeField]
        [Min(1)]
        private int _maxRolls = 1;

        [SerializeField]
        [Min(0)]
        private float _bonusRolls = 0;

        [SerializeField]
        private List<LootEntry> _entries= new List<LootEntry>();

        public List<LootItem> GetLoot(int bonusModifier = 0)
        {
            if (_entries == null || _entries.Count == 0) return null;

            int rolls = GetRolls(bonusModifier);
            int totalWeight = GetTotalWeight();

            List<LootItem> loot = new List<LootItem>();

            for(int i = 0; i < rolls; i++)
            {
                LootItem lootItem = GetItem(totalWeight);
                if (lootItem != null)
                {
                    loot.Add(lootItem);
                }
            }

            return loot;
        }

        private int GetRolls(int bonusModifier)
        {
            return Random.Range(_minRolls, _maxRolls + 1) + Mathf.FloorToInt(_bonusRolls * bonusModifier);
        }

        private int GetTotalWeight()
        {
            int totalWeight = 0;
            foreach (LootEntry entry in _entries)
            {
                totalWeight += entry.Weight;
            }

            return totalWeight;
        }

        private LootItem GetItem(int totalWeight)
        {
            int randomWeight = Random.Range(0, totalWeight);

            foreach(LootEntry entry in _entries)
            {
                if (randomWeight < entry.Weight)
                {
                    return new LootItem(entry.Item, entry.GetCount());
                }
                randomWeight -= entry.Weight;
            }
            return null;
        }
    }
}
