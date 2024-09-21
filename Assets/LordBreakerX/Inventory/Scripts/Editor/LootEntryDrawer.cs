using LordBreakerX.Utilities.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Inventory
{
    [CustomPropertyDrawer(typeof(LootEntry))]
    public class LootEntryDrawer : PropertyDrawer
    {

        private SerializedProperty _item;
        private SerializedProperty _weight;
        private SerializedProperty _minCount;
        private SerializedProperty _maxCount;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            _item = property.FindPropertyRelative("_item");
            _weight = property.FindPropertyRelative("_weight");
            _minCount = property.FindPropertyRelative("_minCount");
            _maxCount = property.FindPropertyRelative("_maxCount");

            VisualElement root = new VisualElement();

            DecoratedFoldout foldout = new DecoratedFoldout(property.displayName);

            BetterPropertyField item = new BetterPropertyField(_item, Color.black);
            BetterPropertyField weight = new BetterPropertyField(_weight, Color.black);
            BetterPropertyField minCount = new BetterPropertyField(_minCount, Color.black);
            BetterPropertyField maxCount = new BetterPropertyField(_maxCount, Color.black);

            foldout.AddRangeToContent(item, weight, minCount, maxCount);

            root.Add(foldout);

            return root;
        }
    }
}
