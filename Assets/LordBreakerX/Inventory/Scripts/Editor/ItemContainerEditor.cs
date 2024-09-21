using LordBreakerX.Utilities.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Inventory
{
    [CustomEditor(typeof(ItemContainer), true)]
    public class ItemContainerEditor : Editor
    {
        private SerializedProperty _onItemAdded;
        private SerializedProperty _onSlotsInilized;

        protected virtual void OnEnable()
        {
            _onItemAdded = serializedObject.FindProperty("_onItemAdded");
            _onSlotsInilized = serializedObject.FindProperty("_onSlotsInilized");
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            HeaderBox header = new HeaderBox("Item Container", 30, Color.black ,Color.gray);
            header.AddBorder(5, Color.black);

            BoxElement space = new BoxElement(20);

            DecoratedFoldout events = new DecoratedFoldout("Events");
            CreateEventsFoldout(events.Content);

            root.AddRange(header, space);
            OnCreateInspectorGUI(root);
            root.Add(events);

            DecoratedFoldout additionals = new DecoratedFoldout("Additional Details");
            CreateAdditionalDetails(additionals.Content);

            if (additionals.Content.childCount > 0) 
            {
                root.Add(additionals);
            }

            return root;
        }

        protected virtual void OnCreateInspectorGUI(VisualElement root)
        {
            
        }

        protected virtual void CreateAdditionalDetails(BoxElement content)
        {
            FieldsUtility.ShowDerivedFields(content, serializedObject, target.GetType(), typeof(ItemContainer), Color.black);
        }

        private void CreateEventsFoldout(BoxElement content)
        {
            BetterPropertyField onItemAdded = new BetterPropertyField(_onItemAdded);
            BetterPropertyField onSlotsInilized = new BetterPropertyField(_onSlotsInilized);

            content.AddRange(onItemAdded, onSlotsInilized);
            OnCreateEventsFoldout(content);
        }

        protected virtual void OnCreateEventsFoldout(BoxElement content)
        {

        }
    }
}
