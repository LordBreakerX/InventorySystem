using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Utilities.UIElements
{
    public class BetterPropertyField : PropertyField
    {
        private Label _label;

        private string Title
        { get
            {
                if (_label != null)
                {
                    return _label.text;
                }
                else
                {
                    return "";
                }
            }

            set 
            {
                if (_label != null)
                {
                    _label.text = value;
                }
            }
        }

        public BetterPropertyField(SerializedProperty property, Color textColor): base(property)
        {
            RegisterCallback<GeometryChangedEvent>(evt => InilizeLabel(textColor));
        }

        public BetterPropertyField(SerializedProperty property, string label, Color textColor) : base(property, label) 
        {
            RegisterCallback<GeometryChangedEvent>(evt => InilizeLabel(textColor));
        }

        public BetterPropertyField(SerializedProperty property) : this(property, Color.white) { }

        public BetterPropertyField(SerializedProperty property, string label) : this(property, label, Color.white) { }

        private void InilizeLabel(Color color)
        {
            _label = this.Q<Label>();

            if (_label != null)
            {
                _label.style.color = color;
            }
        }
    }
}
