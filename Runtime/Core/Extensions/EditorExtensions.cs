using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Extensions
{
    /// <summary>
    /// Functions involving the Unity Editor
    /// </summary>
    public class EditorExtensions
    {
        public static void MarkDirty(Object obj)
        {
            #if UNITY_EDITOR
            if(!Application.isPlaying)
                UnityEditor.EditorUtility.SetDirty(obj);
            #endif
        }
    }
}
