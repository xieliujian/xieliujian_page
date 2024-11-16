using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace LR.SLG
{
    /// <summary>
    /// 
    /// </summary>
    [CustomEditor(typeof(SLGTools_HexColor))]
    public class SLGTools_HexColorInspector : Editor
    {
        /// <summary>
        /// 
        /// </summary>
        public override void OnInspectorGUI()
        {
            var script = (SLGTools_HexColor)target;
            if (script == null)
                return;

            base.OnInspectorGUI();

            if (GUILayout.Button("��ӡ��ɫ��Ϣ"))
            {
                script.DumpColorInfo();
            }
        }
    }
}

