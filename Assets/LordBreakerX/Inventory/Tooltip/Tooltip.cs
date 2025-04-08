using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace LordBreakerX.TooltipSystem
{
    [RequireComponent(typeof(RectTransform))]
    public class Tooltip : MonoBehaviour
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        [Min(100)]
        private float _maxTooltipWidth = 500;

        [SerializeField]
        private bool _isDynamic = true;

        [SerializeField]
        private TMP_Text _headerTextbox;

        [SerializeField]
        private TMP_Text _bodyTextbox;

        private RectTransform _uiTransform;

        public string ID { get { return _id; } }

        private void Awake()
        {
            _uiTransform = GetComponent<RectTransform>();
        }

        public void ShowTooltip(string bodyText, string headerText = "")
        {
            gameObject.SetActive(true);

            MoveTooltip();

            _bodyTextbox.text = bodyText;

            if (_headerTextbox != null)
            {
                _headerTextbox.text = headerText;
                
                if (headerText == "")
                {
                    _headerTextbox.gameObject.SetActive(false);
                }
                else
                {
                    _headerTextbox.gameObject.SetActive(true);
                }
            }

            if (_isDynamic)
            {

                float width = GetTextWidth();

                _uiTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);

                _bodyTextbox.ForceMeshUpdate();

                float height = GetTextHeight();

                _uiTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            }

        }

        private float GetTextWidth()
        {
            float length = _bodyTextbox.text.Length;

            if (_headerTextbox != null && _headerTextbox.text.Length > length) 
            {
                length = _headerTextbox.text.Length;
            }

            return Mathf.Clamp(length * (_bodyTextbox.fontSize / 1.75f) + 30, 0, _maxTooltipWidth);
        }

        private float GetTextHeight() 
        {
            float lineCount = _bodyTextbox.textInfo.lineCount;
            
            if (_headerTextbox != null)
            {
                lineCount += _headerTextbox.textInfo.lineCount;
            }

            return lineCount * _bodyTextbox.fontSize + 50;
        }

        public void MoveTooltip()
        {
            if (TooltipManager.Instance != null) 
            {

                Vector3 finalPosition = Input.mousePosition;

                _uiTransform.position = finalPosition;

                Vector2 canvasMin = TooltipManager.Instance.Canvas.pixelRect.min;
                Vector2 canvasMax = TooltipManager.Instance.Canvas.pixelRect.max;
                Vector2 recMin = _uiTransform.TransformPoint(_uiTransform.rect.min);
                Vector2 recMax = _uiTransform.TransformPoint(_uiTransform.rect.max);

                if (recMin.x < canvasMin.x)
                {
                    finalPosition.x += _uiTransform.rect.width;
                }

                if (recMin.y < canvasMin.y)
                {
                    finalPosition.y += _uiTransform.rect.height;
                }

                if (recMax.x > canvasMax.x)
                {
                    finalPosition.x -= _uiTransform.rect.width;
                }

                if (recMax.y > canvasMax.y)
                {
                    finalPosition.y -= _uiTransform.rect.height;
                }

                _uiTransform.position = finalPosition;

            }

        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }

    }
}
