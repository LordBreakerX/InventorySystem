using System.Collections.Generic;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System;

namespace LordBreakerX.Utilities.UIElements
{
    public static class FieldsUtility
    {
        public static void ShowDerivedFields(VisualElement element, SerializedObject serializedObject, Type targetType, Type baseType, Color labelColor)
        {
            List<FieldInfo> derivedFields = new List<FieldInfo>();

            while (targetType != baseType)
            {
                FieldInfo[] fields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                derivedFields.AddRange(fields);
                targetType = targetType.BaseType;
            }

            foreach (FieldInfo field in derivedFields)
            {
                SerializedProperty property = serializedObject.FindProperty(field.Name);

                if (property != null)
                {
                    BetterPropertyField propertyField = new BetterPropertyField(property, labelColor);
                    propertyField.BindProperty(property);
                    element.Add(propertyField);
                }
            }
        }

        public static void ShowDerivedFields(VisualElement element, SerializedObject serializedObject, Type targetType, Type baseType)
        {
            ShowDerivedFields(element, serializedObject, targetType, baseType, Color.white);
        }
    }
}
