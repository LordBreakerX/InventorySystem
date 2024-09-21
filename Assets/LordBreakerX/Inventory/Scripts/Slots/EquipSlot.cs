using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class EquipSlot : ItemSlot
    {
        [SerializeField]
        private string _equipCategory;

        public override bool CanEnterSlot(Item item)
        {
            return item.Category == _equipCategory;
        }

        public override bool CanEnterSlot(ItemStack stack)
        {
            return stack.StackItem.Category == _equipCategory;
        }
    }
}
