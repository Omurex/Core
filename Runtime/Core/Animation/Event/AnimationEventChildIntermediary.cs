using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;


/// <summary>
/// An interface for animations to call child functions on an object since Unity doesn't natively support this
/// </summary>

namespace JosephLyons.Core.Animation.Event
{ 
    public class AnimationEventChildIntermediary : MonoBehaviour
    {
        [SerializeField] SerializedDictionary<string, AnimationEventDelegate> functionsDictionary;


        /// <summary>
        /// Call this function from a Unity animation event to access child functions
        /// </summary>
        /// <param name="functionName">Name of function to call</param>
        public void CallChildFunction(string functionName)
        {
            functionsDictionary[functionName]?.Invoke();
        }
    }
}