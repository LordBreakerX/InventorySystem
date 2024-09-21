using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private Sprite _brokenIcon;

        [SerializeField]
        [Tooltip("the name that can be displayed for the item")]
        private string _displayName;

        [SerializeField]
        [Multiline]
        [Tooltip("Description of the item")]
        private string _description;

        [SerializeField]
        private string _category;

        [SerializeField]
        [Tooltip("The rarity of the item")]
        private Rarity _itemRarity = Rarity.Common;

        [SerializeField]
        [Min(1f)]
        [Tooltip("The max amount of this one item that can be in an stack.")]
        private int _maxStackSize = 64;

        [SerializeField]
        [Tooltip("The max amount of durabilitty this item has. Keep at 0 to make the item unbreakable.")]
        [Min(0f)]
        private int _maxDurability = 0;

        [SerializeField]
        [Min(0f)]
        private float _itemValue;

        [SerializeField]
        private bool _consumeOnUse;

        [SerializeField]
        private DurabilityZeroBehavior _noDurabilityBehavior;

        public Sprite Icon { get { return _icon; } }

        public string DisplayName { get { return _displayName; } }
        public string Description { get { return _description; } }
        public string Category { get { return _category; } }

        public Rarity ItemRarity { get { return _itemRarity; } }

        public int MaxStackSize { get { return _maxStackSize; } }
        public int MaxDurability { get { return _maxDurability; } }

        public float ItemValue { get { return _itemValue; } }

        public bool ConsumeOnUse { get { return _consumeOnUse; } }

        public DurabilityZeroBehavior NoDurabilityBehavior { get { return _noDurabilityBehavior; } }

        public virtual void OnPrimaryUse(ItemStack itemStack) { }
        public virtual void OnSecondaryUse(ItemStack itemStack) { }
        public virtual void OnConsume(ItemStack itemStack) { }

        public virtual void OnItemDropped(ItemStack itemStack) { }


        public virtual void OnItemAdded(ItemStack itemStack) { }
        public virtual void OnItemRemoved(ItemStack itemStack) { }
        public virtual void OnItemUpdate(ItemStack itemStack) { }

        public virtual bool CanBeDestroyed()
        {
            return _maxDurability > 0;
        }

        public bool IsStackable()
        {
            return _maxStackSize > 1 && !CanBeDestroyed();
        }
    }
}
