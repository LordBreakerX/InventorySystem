using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LordBreakerX.Utilities.Editor
{
    public static class LayoutUtility
    {
        private static Dictionary<BoxType, GUIStyle> boxes = new Dictionary<BoxType, GUIStyle>() 
        {
            {BoxType.Box, GUI.skin.box },
            {BoxType.Helpbox, EditorStyles.helpBox },
            {BoxType.Window, GUI.skin.window }
        };

        public static void Horizontal(Action block, GUIStyle style)
        {
            EditorGUILayout.BeginHorizontal(style);
            block();
            EditorGUILayout.EndHorizontal();
            
        }

        public static void Horizontal(Action block)
        {
            Horizontal(block, GUIStyle.none);
        }

        public static void HorizontalBox(Action block, BoxType boxType = BoxType.Box)
        {
            Horizontal(block, boxes[boxType]);
        }

        public static void HorizontallyCentered(Action block)
        {
            Horizontal(() =>
            {
                GUILayout.FlexibleSpace();
                block();
                GUILayout.FlexibleSpace();
            });
        }

        public static void Vertical(Action block, GUIStyle style) 
        {
            EditorGUILayout.BeginVertical(style);
            block();
            EditorGUILayout.EndVertical();
        }

        public static void Vertical(Action block)
        {
            Vertical(block, GUIStyle.none);
        }

        public static void VerticalBox(Action block, BoxType boxType = BoxType.Box)
        {
            Vertical(block, boxes[boxType]);
        }

        public static void VerticallyCentered(Action block) 
        {
            Vertical(() =>
            {
                GUILayout.FlexibleSpace();
                block();
                GUILayout.FlexibleSpace();
            });
        }

        public static void EnabledGUI(bool enabled, Action block) 
        { 
            GUI.enabled = enabled; 
            block();
            GUI.enabled = true;

        }
    }
}
