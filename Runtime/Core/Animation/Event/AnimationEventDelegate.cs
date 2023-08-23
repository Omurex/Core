using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace JosephLyons.Core.Animation.Event
{
    /// <summary>
    /// Class that represents a function that can be called from Unity's animation event system
    /// </summary>
    [System.Serializable]
    public class AnimationEventDelegate : UnityEvent
    {}
}