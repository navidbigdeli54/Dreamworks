/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

using System;
using UnityEditor;
using System.Linq;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using DreamMachineGameStudio.Dreamworks.Core;
using DreamMachineGameStudio.Dreamworks.Utility;

namespace DreamMachineGameStudio.Dreamworks.Editor
{
    [CustomPropertyDrawer(typeof(FSubclass))]
    public class USubclassPropertyDrawer : PropertyDrawer
    {
        #region Fields
        private string[] typeFullNames;
        private string[] displaynames;
        private int selectedIndex;
        #endregion

        #region Editor Methods
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var nameProperty = property.FindPropertyRelative("fullName");

            if (displaynames == null)
            {
                CacheTypeNames();

                if (displaynames != null && displaynames.Length > 0)
                {
                    selectedIndex = Array.IndexOf(displaynames, nameProperty.stringValue);

                    if (selectedIndex == -1) selectedIndex = 0;
                }
            }

            Vector2 lableSize = GUI.skin.label.CalcSize(label);

            EditorGUI.LabelField(new Rect(position.x, position.y, lableSize.x, position.height), label);
            selectedIndex = EditorGUI.Popup(new Rect(position.x + lableSize.x + 5, position.y, position.width - lableSize.x - 5, position.height), selectedIndex, displaynames);

            if (displaynames != null && displaynames.Length > 0)
            {
                nameProperty.stringValue = typeFullNames[selectedIndex];
            }
        }
        #endregion

        #region Private Methods
        private void CacheTypeNames()
        {
            if (fieldInfo.IsDefined(ASubclassFilter.CLASS_TYPE))
            {
                Attribute attribute = fieldInfo.GetCustomAttribute(ASubclassFilter.CLASS_TYPE);
                PropertyInfo typePropertyInfo = attribute.GetType().GetProperty(nameof(ASubclassFilter.Type));
                Type typeFilter = (Type)typePropertyInfo.GetValue(attribute);
                IEnumerable<Type> subtypes = FReflectionUtility.GetSubTypesOf(typeFilter);
                typeFullNames = subtypes.Select(x => x.FullName).ToArray();
                displaynames = subtypes.Select(x => FReflectionUtility.HasDefinedAttribute(x, AName.CLASS_TYPE) ? FReflectionUtility.GetAttributeProperty<string>(x, AName.CLASS_TYPE, nameof(AName.Name)) : x.FullName).ToArray();
            }
        }

        #endregion
    }
}