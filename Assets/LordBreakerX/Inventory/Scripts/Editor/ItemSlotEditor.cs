using Codice.Client.Common.GameUI;
using LordBreakerX.Utilities.UIElements;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;

namespace LordBreakerX.Inventory
{
    [CustomEditor(typeof(ItemSlot), true)]
    public class ItemSlotEditor : Editor
    {
        private SerializedProperty _selectable;
        private SerializedProperty _containerMirroring;
        private SerializedProperty _icon;
        private SerializedProperty _slotImage;
        private SerializedProperty _quantityText;
        private SerializedProperty _onStackChange;
        private SerializedProperty _isDraggable;

        protected virtual void OnEnable()
        {
            _containerMirroring = serializedObject.FindProperty("_containerMirroring");
            _icon = serializedObject.FindProperty("_icon");
            _slotImage = serializedObject.FindProperty("_slotImage");
            _quantityText = serializedObject.FindProperty("_quantityText");
            _onStackChange = serializedObject.FindProperty("_onStackChange");
            _selectable = serializedObject.FindProperty("_selectable");
            _isDraggable = serializedObject.FindProperty("_isDraggable");
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            HeaderBox header = new HeaderBox("Item Slot", 30, Color.black, Color.gray);
            header.AddBorder(5, Color.black);

            BoxElement space = new BoxElement(20);

            DecoratedFoldout visualsFoldout = new DecoratedFoldout("Visuals");
            CreateVisualsFoldout(visualsFoldout.Content);

            DecoratedFoldout draggableFoldout = new DecoratedFoldout("Slot Dragging");
            CreateDraggingFoldout(draggableFoldout.Content);

            DecoratedFoldout containerFoldout = new DecoratedFoldout("Container Slot Configuration");
            CreateContainerFoldout(containerFoldout.Content);

            DecoratedFoldout eventsFoldout = new DecoratedFoldout("Events");
            CreateEventsFoldout(eventsFoldout.Content);

            DecoratedFoldout additionalFoldout = new DecoratedFoldout("Additional Details");
            OnCreateAdditionalFoldout(additionalFoldout.Content);

            root.AddRange(header, space, visualsFoldout, draggableFoldout, containerFoldout, eventsFoldout);

            OnCreateInspectorGUI(root);

            if (additionalFoldout.Content.childCount > 0) 
            {
                root.Add(additionalFoldout);
            }

            return root;
        }

        private void CreateContainerFoldout(BoxElement content)
        {
            HelpBox helpBox = new HelpBox("These properties are for slots that are a part of an item container!", HelpBoxMessageType.Info);

            BetterPropertyField containerMirroring = new BetterPropertyField(_containerMirroring, Color.black);
            BetterPropertyField selectable = new BetterPropertyField(_selectable, Color.black);
            content.AddRange(helpBox, containerMirroring, selectable);

            OnCreateContainerFoldout(content);
        }

        private void CreateDraggingFoldout(BoxElement content)
        {
            HelpBox helpBox = new HelpBox("These properties are only applied if there is an [Item Drag Handler] in the scene!", HelpBoxMessageType.Info);

            BetterPropertyField isDraggable = new BetterPropertyField(_isDraggable, Color.black);

            content.AddRange(helpBox, isDraggable);

        }

        private void CreateVisualsFoldout(VisualElement content)
        {
            BetterPropertyField icon = new BetterPropertyField(_icon, Color.black);
            BetterPropertyField slotImage = new BetterPropertyField(_slotImage, Color.black);
            Seperator seperator = new Seperator(2, 4, Color.black);
            BetterPropertyField quantityText = new BetterPropertyField(_quantityText, Color.black);

            content.AddRange(icon, slotImage, seperator, quantityText);
            OnCreateVisualsFoldout(content);
        }

        private void CreateEventsFoldout(VisualElement content)
        {
            BetterPropertyField onStackChange = new BetterPropertyField(_onStackChange);

            content.Add(onStackChange);
            OnCreateEventsFoldout(content);
        }

        protected void CreateSeperator(VisualElement parent)
        {
            parent.Add(new Seperator(2, 4, Color.black));
        }

        protected virtual void OnCreateVisualsFoldout(VisualElement content) { }

        protected virtual void OnCreateEventsFoldout(VisualElement content) { }

        protected virtual void OnCreateContainerFoldout(VisualElement content) { }

        protected virtual void OnCreateAdditionalFoldout(VisualElement content) 
        {
            FieldsUtility.ShowDerivedFields(content, serializedObject, target.GetType(), typeof(ItemSlot), Color.black);
        }

        protected virtual void OnCreateInspectorGUI(VisualElement root) { }
    }
}
