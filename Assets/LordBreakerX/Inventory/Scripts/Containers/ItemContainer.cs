using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LordBreakerX.Utilities.Collections;

namespace LordBreakerX.Inventory
{
    public class ItemContainer : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onItemAdded = new UnityEvent();

        [SerializeField]
        private UnityEvent<ItemSlot[]> _onSlotsInilized = new UnityEvent<ItemSlot[]>();

        protected List<ItemSlot> _slots = new List<ItemSlot>();

        private bool _initilizedSlots = false;

        public UnityEvent OnItemAdded { get { return _onItemAdded; } }

        public IReadOnlyList<ItemSlot> Slots { get { return _slots.AsReadOnly(); } }

        protected virtual void Awake()
        {
            InililizeSlots();
        }

        protected virtual void InililizeSlots()
        {
            if (!_initilizedSlots)
            {
                ItemSlot[] foundSlots = GetComponentsInChildren<ItemSlot>();
                _slots.AddRange(foundSlots);
                OnSlotsInilized(foundSlots);
                _onSlotsInilized.Invoke(foundSlots);
                _initilizedSlots = true;
            }
        }

        private ItemSlot[] GetFillableSlots(Item item)
        {
            List<ItemSlot> validSlots = new List<ItemSlot>();
            List<ItemSlot> emptySlots = new List<ItemSlot>();

            foreach (ItemSlot slot in _slots)
            {
                if (slot.CanEnterSlot(item))
                {
                    if (slot.HasItem(item) && !slot.IsFull())
                    {
                        validSlots.Add(slot);
                    }
                    else if (slot.IsEmpty())
                    {
                        emptySlots.Add(slot);
                    }
                }
            }

            if (emptySlots.Count > 0) validSlots.AddRange(emptySlots);

            return validSlots.ToArray();
        }

        public int AddItem(Item item, int amount = 1, bool addToRandomSlots = false)
        {
            InililizeSlots();
            ItemSlot[] fillableSlots = GetFillableSlots(item);
            int itemsToAdd = amount;
            
            if (addToRandomSlots)
            {
                fillableSlots.Shuffle();
            }

            foreach (ItemSlot slot in fillableSlots) 
            {
                if (slot.IsEmpty())
                {
                    slot.ChangeStack(new ItemStack(item));
                    itemsToAdd--;
                }

                if (itemsToAdd > 0)
                {
                    itemsToAdd = slot.Grow(itemsToAdd);
                }

                slot.UpdateVisuals();

                if (itemsToAdd <= 0) break;
            }

            _onItemAdded.Invoke();
            return itemsToAdd;
        }

        protected virtual void OnSlotsInilized(ItemSlot[] slots) { }

        public void AddTableItems(LootTable table, int bonusModifer = 0, bool addToRandomSlots = true)
        {
            LootItem[] items = table.GetLoot(bonusModifer).ToArray();
            foreach (LootItem lootItem in items)
            {
                AddItem(lootItem.Item, lootItem.Count, addToRandomSlots);
            }
        }
    }
}
