using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class HotbarItemContainer : ItemContainer
    {
        [SerializeField]
        private Sprite _selectedSlot;
        [SerializeField]
        private Sprite _notSelectedSlot;

        private List<ItemSlot> _selectableSlots = new List<ItemSlot>();

        private int _selectedSlotIndex = 0;

        private void Start()
        {
            foreach(ItemSlot slot in Slots)
            {
                slot.SlotImage.sprite = _notSelectedSlot;

                if (slot.Selectable)
                {
                    _selectableSlots.Add(slot);
                }
            }

            _selectableSlots[0].SlotImage.sprite = _selectedSlot;
        }

        private void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll > 0f)
            {
                NextSlot();
            }
            else if (scroll < 0f)
            {
                PreviousSlot();
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                _selectableSlots[_selectedSlotIndex].UseItem(false);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                _selectableSlots[_selectedSlotIndex].UseItem(true);
            }
        }

        private void NextSlot()
        {
            _selectableSlots[_selectedSlotIndex].SlotImage.sprite = _notSelectedSlot;

            _selectedSlotIndex++;
            if (_selectedSlotIndex >= _selectableSlots.Count)
            {
                _selectedSlotIndex = 0;
            }

            _selectableSlots[_selectedSlotIndex].SlotImage.sprite = _selectedSlot;
        }

        private void PreviousSlot()
        {
            _selectableSlots[_selectedSlotIndex].SlotImage.sprite = _notSelectedSlot;

            _selectedSlotIndex--;
            if (_selectedSlotIndex < 0)
            {
                _selectedSlotIndex = _selectableSlots.Count - 1;
            }

            _selectableSlots[_selectedSlotIndex].SlotImage.sprite = _selectedSlot;
        }
    }
}
