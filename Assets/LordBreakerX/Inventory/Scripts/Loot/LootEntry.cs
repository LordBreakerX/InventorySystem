using UnityEngine;

namespace LordBreakerX.Inventory
{
    [System.Serializable]
    public class LootEntry
    {
        [SerializeField]
        private Item _item;

        [SerializeField]
        [Min(1)]
        private int _weight = 1;

        [SerializeField]
        [Min(1)]
        private int _minCount = 1;

        [SerializeField]
        [Min(1)]
        private int _maxCount = 1;

        public Item Item { get { return _item; } }

        public int Weight { get { return _weight; } }

        public LootEntry(Item item, int weight, int minCount, int maxCount)
        {
            _item = item;
            _weight = weight;
            _minCount = minCount;
            _maxCount = maxCount;
        }

        public LootEntry(Item item, int weight, int count) : this(item, weight, count, count)
        {

        }

        public int GetCount()
        {
            if (_minCount == _maxCount)
            {
                return _minCount;
            }

            return Random.Range(_minCount, _maxCount + 1);
        }
    }
}
