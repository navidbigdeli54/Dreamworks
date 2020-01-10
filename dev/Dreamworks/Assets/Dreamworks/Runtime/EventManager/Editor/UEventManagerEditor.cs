/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

#pragma warning disable IDE0051

using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace DreamMachineGameStudio.Dreamworks.EventManager.Editor
{
    public class UEventManagerEditor : EditorWindow
    {
        #region Fields
        private Vector3 scrollPosition;
        #endregion

        #region Private Methods
        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal(GUI.skin.box);
            EditorGUILayout.LabelField("Event");
            EditorGUILayout.LabelField("Listeners");
            EditorGUILayout.EndHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            foreach (KeyValuePair<string, FEventManager.DEventSubscriber> item in FEventManager.Events)
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                EditorGUILayout.LabelField(item.Key, GUILayout.Width(position.width / 2));

                EditorGUILayout.BeginVertical();
                foreach (Delegate subscriber in item.Value.GetInvocationList())
                {
                    EditorGUILayout.LabelField($"*{subscriber.Target.GetType().FullName}.{subscriber.Method.Name}", GUILayout.Width(position.width / 2));
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndVertical();
        }
        #endregion

        #region Static Methods
        [MenuItem("DreamMachineGameStudio/Event Manager")]
        private static void OpenWindow()
        {
            GetWindow<UEventManagerEditor>("Event Management", focus: true);
        }
        #endregion
    }
}