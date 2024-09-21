using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class MirroredSlot : ItemSlot
    {
        [SerializeField]
        private ItemSlot _mirroredSlot;

        public override bool CanEnterSlot(Item item)
        {
            if (_mirroredSlot != null)
            {
                return _mirroredSlot.CanEnterSlot(item);
            }

            return true;
        }

        public override bool CanEnterSlot(ItemStack stack)
        {
            if (_mirroredSlot != null)
            {
                return _mirroredSlot.CanEnterSlot(stack);
            }

            return true;
        }


        public void SetMirroredSlot(ItemSlot slot)
        {
            if (slot == null) 
            {
                Debug.LogWarning("An mirrored slot has been set to not mirror an slot!");
            }

            _mirroredSlot = slot;
            StackUpdate();
            _mirroredSlot.OnStackChange.AddListener(StackUpdate);
        }

        public void StackUpdate()
        {
            if (_mirroredSlot != null)
            {
                ChangeStack(_mirroredSlot.ContainedStack);
            }
        }

        private void OnEnable()
        {
            StackUpdate();
            if (_mirroredSlot != null) _mirroredSlot.OnStackChange.AddListener(StackUpdate);
        }

        private void OnDisable()
        {
            if (_mirroredSlot != null)
            {
                _mirroredSlot.ChangeStack(ContainedStack);
            }
            _mirroredSlot.OnStackChange.RemoveListener(StackUpdate);
        }
    }
}
