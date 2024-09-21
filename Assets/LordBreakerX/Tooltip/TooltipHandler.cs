using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LordBreakerX.TooltipSystem
{
    public class TooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {
        [SerializeField]
        private string tooltip;

        [SerializeField]
        private string headerText;

        [SerializeField]
        [Multiline(7)]
        private string bodyText;

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            TooltipManager.Instance.ShowTooltip(tooltip, bodyText, headerText);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            TooltipManager.Instance.HideTooltip(tooltip);
        }

        public virtual void OnPointerMove(PointerEventData eventData)
        {
            TooltipManager.Instance.MoveTooltip(tooltip);
        }
    }
}
