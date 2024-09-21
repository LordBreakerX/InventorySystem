using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class GeneratedItemContainer : ItemContainer
    {
        [SerializeField]
        private bool _includePrexistingSlots = false;

        [SerializeField]
        [Min(0f)]
        private int _generateSlotsAmount;

        [SerializeField]
        private Transform _content;

        [SerializeField]
        private ItemSlot _slotPrefab;

        private bool _isGenerated = false;

        protected override void InililizeSlots()
        {
            if (_includePrexistingSlots) base.InililizeSlots();

            if (!_isGenerated)
            {
                for (int i = 0; i < _generateSlotsAmount; i++)
                {
                    ItemSlot slot = Instantiate(_slotPrefab, _content);
                    OnSlotGeneration(slot);
                    _slots.Add(slot);
                }
                _isGenerated = true;
            }
        }

        protected virtual void OnSlotGeneration(ItemSlot slot) { }
    }
}
