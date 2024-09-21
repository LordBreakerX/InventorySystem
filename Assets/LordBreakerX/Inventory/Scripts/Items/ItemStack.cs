using JetBrains.Annotations;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class ItemStack
    {
        private Item _stackItem;
        private int _count;
        private int _currentDurability;

        public Item StackItem { get { return _stackItem; } }
        public int Count { get { return _count; } }
        public int CurrentDurability { get { return _currentDurability; } }

        public ItemStack(Item item, int count)
        {
            _stackItem = item;
            _currentDurability = _stackItem.MaxDurability;
            _count = count;
        }

        public ItemStack(Item item) : this(item, 1)
        {
            
        }

        public ItemStack SplitStack(int amount)
        {
            int clampedAmount = Mathf.Clamp(amount, 0, _count);
            ShrinkStack(clampedAmount);
            return new ItemStack(_stackItem, clampedAmount);
        }

        public ItemStack SplitStack()
        {
            if (_count > 1)
            {
                return SplitStack(_count / 2);
            }
            else
            {
                return SplitStack(_count);
            }
        }

        public int CombineStacks(ItemStack stack)
        {
            if (stack.StackItem == _stackItem)
            {
                return GrowStack(stack.Count);
            }
            return 0;
        }

        public int GetRemainingSpace() 
        {
            return _stackItem.MaxStackSize - _count;
        }

        /// <summary>
        ///     Increases the size of the stack by an amount.
        /// </summary>
        /// <param name="amount"> the amount of the item to add to the slot </param>
        /// <returns> The amount that wasn't able to be added to the slot </returns>
        public int GrowStack(int amount = 1)
        {
            int remainingItems = amount;

            if (_stackItem.IsStackable())
            {
                if (amount > 0)
                {
                    int oldCount = _count;
                    _count = Mathf.Clamp(_count + amount, 0, _stackItem.MaxStackSize);
                    remainingItems = amount - (_count - oldCount);
                }
                else
                {
                    Debug.LogWarning($"Can't grow stack since {amount} is not greater then zero!");
                }
            }
            else
            {
                Debug.LogWarning($"Could not increase the {_stackItem.DisplayName} stack since it isn't stackable!");
            }

            if (remainingItems < 0)
            {
                remainingItems = 0;
            }

            return remainingItems;
        }

        public void ShrinkStack(int amount = 1)
        {
            if (amount > 0)
            {
                _count = Mathf.Clamp(_count - amount, 0, _stackItem.MaxStackSize);
            }
            else
            {
                Debug.LogWarning($"Could not shrink stack since {amount} is not greater then zero!");
            }
        }

        public bool IsStackFull()
        {
            if (_count == _stackItem.MaxStackSize || (!_stackItem.IsStackable() && _count > 0))
            {
                return true;
            }
            return false;
        }

        public bool MergeStacks(ItemStack itemStack)
        {
            if (itemStack != null)
            {
                if (itemStack.StackItem == _stackItem)
                {
                    if (_stackItem.IsStackable())
                    {
                        GrowStack(itemStack.Count);
                        return true;
                    }
                    else
                    {
                        Debug.LogWarning($"Can't merge {_stackItem.DisplayName} items as they are not stackable!");
                    }
                }
                else
                {
                    Debug.LogError($"Can't merge item stack {itemStack.StackItem.DisplayName} with a stack of a different item ({_stackItem.DisplayName})");
                }
            }
            else
            {
                Debug.LogWarning($"Tried to merge a null perameter with {_stackItem.DisplayName}");
            }
            return false;
        }

        public void UseItem(ItemSlot slot, bool primary)
        {
            if (primary)
            {
                _stackItem.OnPrimaryUse(this);
            }
            else
            {
                _stackItem.OnSecondaryUse(this);
            }

            if (_stackItem.CanBeDestroyed())
            {
                _currentDurability--;
            }

            if ( _stackItem.ConsumeOnUse && primary)
            {
                _stackItem.OnConsume(this);
                ShrinkStack();
                if (Count <= 0)
                {
                    slot.ChangeStack(null);
                }
            }
        }

    }
}
