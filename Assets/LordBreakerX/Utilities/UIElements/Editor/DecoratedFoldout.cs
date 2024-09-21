using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Utilities.UIElements
{
    public class DecoratedFoldout : VisualElement
    {
        private Color _buttonColor;
        private Color _backgroundHoverColor;

        private BoxElement _buttonArea;

        private BoxElement _content;

        private bool _isExpanded;

        public BoxElement Content { get { return _content; } }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                _content.style.display = _isExpanded ? DisplayStyle.Flex : DisplayStyle.None;
            }
        }

        public DecoratedFoldout(string labelText, float borderThickness, Color buttonColor, Color backgroundColor, Color borderColor, Color textColor)
        {
            _buttonColor = buttonColor;
            _backgroundHoverColor = buttonColor * new Color(1.2f, 1.2f, 1.2f);

            _buttonArea = new BoxElement(25, buttonColor);
            _buttonArea.AddBorder(borderThickness, borderColor);
            _buttonArea.style.justifyContent = Justify.Center;
            _buttonArea.style.paddingLeft = 5;
            _buttonArea.style.paddingRight = 5;
            _buttonArea.RegisterCallback<ClickEvent>(evt => IsExpanded = !IsExpanded);
            _buttonArea.RegisterCallback<PointerEnterEvent>(ev => OnPointerEnter());
            _buttonArea.RegisterCallback<PointerLeaveEvent>(ev => OnPointerExit());

            Label header = new Label(labelText);
            header.style.fontSize = 13;
            header.style.unityFontStyleAndWeight = FontStyle.Bold;
            header.style.color = textColor;

            _buttonArea.AddRange(header);

            BoxElement contentArea = new BoxElement(new StyleLength(StyleKeyword.Auto), backgroundColor);
            contentArea.AddBorder(borderThickness, borderColor);
            contentArea.style.paddingLeft = 12;
            contentArea.style.paddingRight = 5;
            contentArea.style.paddingBottom = 5;
            contentArea.style.paddingTop = 5;
            _content = contentArea;
            IsExpanded = false;

            this.AddRange(_buttonArea, contentArea);
        }

        public DecoratedFoldout(string labelText, float borderThickness, Color buttonColor, Color backgroundColor, Color borderColor) : this(labelText, borderThickness, buttonColor, backgroundColor, borderColor, Color.black)
        { }

        public DecoratedFoldout(string labelText, float borderThickness, Color buttonColor, Color backgroundColor) : this(labelText, borderThickness, buttonColor, backgroundColor, Color.black)
        { }

        public DecoratedFoldout(string labelText, float borderThickness) : this(labelText, borderThickness, Color.gray, new Color(0.35f, 0.35f, 0.35f))
        { }

        public DecoratedFoldout(string labelText) : this(labelText, 2)
        { }

        public void AddToContent(VisualElement element)
        {
            _content.Add(element);
        }

        public void AddRangeToContent(params VisualElement[] elements)
        {
            foreach (VisualElement element in elements) 
            { 
                AddToContent(element);
            }
        }

        private void OnPointerEnter()
        {
            _buttonArea.style.backgroundColor = _backgroundHoverColor;
        }

        private void OnPointerExit() 
        {
            _buttonArea.style.backgroundColor = _buttonColor;
        }
    }
}
