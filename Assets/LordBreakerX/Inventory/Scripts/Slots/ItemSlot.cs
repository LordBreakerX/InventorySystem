using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;

namespace LordBreakerX.Inventory
{
    public class ItemSlot : MonoBehaviour, IPointerDownHandler
    {
        #region Variables & Properties

        [SerializeField]
        private bool _selectable = true;

        [SerializeField]
        private bool _isDraggable = true;

        [SerializeField]
        private bool _containerMirroring = true;

        [SerializeField]
        private List<ItemShortcutHandler> _shortcuts = new List<ItemShortcutHandler>();

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Image _slotImage;

        [SerializeField]
        private TMP_Text _quantityText;

        [SerializeField]
        private UnityEvent _onStackChange = new UnityEvent();

        private Vector3 _originalIconPosition;

        private Transform _parentAfterDrag;

        public bool ContainerMirroring { get { return _containerMirroring; } }

        public ItemStack ContainedStack { get; set; }

        public Image SlotImage { get { return _slotImage; } }

        public UnityEvent OnStackChange { get { return _onStackChange; } }

        public bool Selectable { get { return _selectable; } }

        public bool IsDraggingItem { get; private set; }

        #endregion

        private void Update()
        {
            if (!IsEmpty())
            {
                ContainedStack.StackItem.OnItemUpdate(ContainedStack);
            }
        }

        #region Slot Checks

        public bool IsEmpty()
        {
            return ContainedStack == null;
        }

        public bool HasItem(Item item)
        {
            return !IsEmpty() && ContainedStack.StackItem == item;
        }

        public bool HasItem(ItemStack stack)
        {
            if (stack != null && stack.StackItem != null)
            {
                return HasItem(stack.StackItem);
            }

            return false;
        }

        public bool IsFull()
        {
            return ContainedStack.IsStackFull();
        }

        #endregion

        #region Stack Wrapper Methods

        public int Grow(int amount)
        {
            if (ContainedStack != null)
            {
                int leftoverAmount = ContainedStack.GrowStack(amount);
                _onStackChange.Invoke();
                return leftoverAmount;
            }
            return amount;
        }

        public void Shrink(int amount)
        {
            if(ContainedStack != null)
            {
                ContainedStack.ShrinkStack(amount);
                _onStackChange.Invoke();
            }
        }

        public void UseItem(bool primary = true)
        {
            if (ContainedStack == null) return;
            ContainedStack.UseItem(this, primary);
            UpdateVisuals();
        }

        #endregion

        #region Stack Get Methods

        public Sprite GetIcon()
        {
            if (ContainedStack != null && ContainedStack.StackItem != null)
            {
                return ContainedStack.StackItem.Icon;
            }
            return null;
        }

        public int GetQuantity()
        {
            if (ContainedStack != null)
            {
                return ContainedStack.Count;
            }
            return 0;
        }

        #endregion

        #region Item Dragging

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isDraggable) return;

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                ItemDragHandler.OnLeftMouseClicked(this);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                ItemDragHandler.OnRightMouseClicked(this);
            }

        }

        #endregion

        #region Other Methods

        public void UpdateVisuals()
        {
            if (_icon == null || _quantityText == null)
            {
                Debug.LogWarning($"Can't update slot {name}'s visuals since missing an visual reference");
                return;
            }

            if (ContainedStack != null)
            {
                _icon.gameObject.SetActive(true);
                _icon.sprite = GetIcon();

                if (GetQuantity() > 1)
                {
                    _quantityText.gameObject.SetActive(true);
                    _quantityText.text = GetQuantity().ToString();
                }
                else
                {
                    _quantityText.gameObject.SetActive(false);
                }
            }
            else
            {
                _icon.gameObject.SetActive(false);
                _icon.sprite = null;
            }
        }

        public virtual bool CanEnterSlot(ItemStack stack)
        {
            return true;
        }

        public virtual bool CanEnterSlot(Item item)
        {
            return true;
        }

        public void ChangeStack(ItemStack itemStack)
        {
            if (ContainedStack != null)
            {
                ContainedStack.StackItem.OnItemRemoved(ContainedStack);
            }

            ContainedStack = itemStack;

            if (ContainedStack != null)
            {
                ContainedStack.StackItem.OnItemAdded(ContainedStack);
            }

            UpdateVisuals();
            _onStackChange.Invoke();
        }

        #endregion

    }
}
