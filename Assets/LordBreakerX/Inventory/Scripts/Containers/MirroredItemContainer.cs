using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class MirroredItemContainer : MonoBehaviour
    {
        [SerializeField]
        private ItemContainer _container;

        [SerializeField]
        private Transform _content;

        [SerializeField]
        private MirroredSlot _slotPrefab;

        private List<MirroredSlot> _slots = new List<MirroredSlot>();

        private void Awake()
        {
            foreach(ItemSlot memicSlot in _container.Slots)
            {
                if (memicSlot.ContainerMirroring)
                {
                    MirroredSlot slot = Instantiate(_slotPrefab, _content);
                    slot.SetMirroredSlot(memicSlot);
                    _slots.Add(slot);
                }
            }
        }

        //public void UpdateStacks()
        //{
        //    foreach (MirroredSlot slot in _slots)
        //    {
        //        slot.StackUpdate();
        //    }
        //}

        //private void OnEnable()
        //{
        //    _container.OnItemAdded.AddListener(UpdateStacks);
        //}

        //private void OnDisable()
        //{
        //    _container.OnItemAdded.RemoveListener(UpdateStacks);
        //}

        //private void SetMimicSlots()
        //{
        //    for (int i = 0; i < _container.Slots.Count; i++)
        //    {
        //        _slots[i].ContainedStack = _container.Slots[i].ContainedStack;
        //        _slots[i].UpdateVisuals();
        //    }
        //}

        //private void OnEnable()
        //{
        //    SetMimicSlots();
        //    //_container.OnItemAdded.AddListener(SetMimicSlots);
        //}

        //private void OnDisable()
        //{
        //    for (int i = 0; i < _container.Slots.Count; i++)
        //    {
        //        _container.Slots[i].ContainedStack = _slots[i].ContainedStack;
        //        _container.Slots[i].UpdateVisuals();
        //    }
        //    //_container.OnItemAdded.RemoveListener(SetMimicSlots);
        //}
    }
}
