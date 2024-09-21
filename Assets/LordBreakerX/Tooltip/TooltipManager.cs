using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.TooltipSystem
{
    [RequireComponent(typeof(Canvas))]
    public class TooltipManager : MonoBehaviour
    {
        public static TooltipManager Instance { get; private set; }

        private Canvas _canvas;

        private Dictionary<string, Tooltip> _tooltipsRegistry = new Dictionary<string, Tooltip>();

        public Canvas Canvas { get { return _canvas; } }

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            Tooltip[] tooltips = GetComponentsInChildren<Tooltip>(true);

            foreach (Tooltip tooltip in tooltips)
            {
                if (!_tooltipsRegistry.ContainsKey(tooltip.ID))
                {
                    _tooltipsRegistry.Add(tooltip.ID, tooltip);
                }
                else
                {
                    Debug.LogWarning($"Cound'nt register a tooltip since {tooltip.ID} is an already registered tooltip!");
                }
            }
        }

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning($"[{name}] there is already an Tooltip Manager called [{Instance.name}]!");
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private Tooltip GetTooltip(string tooltipID)
        {
            if (_tooltipsRegistry.TryGetValue(tooltipID, out Tooltip tooltip))
            {
                return tooltip;
            }
            else
            {
                Debug.LogWarning($"There isn't any tooltip registered with the name {tooltipID}");
                return null;
            }
        }

        public void ShowTooltip(string tooltipID, string bodyText, string headerText = "")
        {
            Tooltip tooltip = GetTooltip(tooltipID);
            if (tooltip != null)
            {
                tooltip.ShowTooltip(bodyText, headerText);
            }
        }

        public void MoveTooltip(string tooltipID)
        {
            Tooltip tooltip = GetTooltip(tooltipID);
            if (tooltip != null)
            {
                tooltip.MoveTooltip();
            }
        }

        public void HideTooltip(string tooltipID)
        {
            Tooltip tooltip = GetTooltip(tooltipID);
            if (tooltip != null)
            {
                tooltip.HideTooltip();
            }
        }
    }
}
