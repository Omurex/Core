using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;


namespace JosephLyons.Core.Animation.Event
{
    /// <summary>
    /// Script that provides OnEnter and OnExit events for animations to call
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimationEventExtension : MonoBehaviour
    {
        public System.Action<AnimatorStateInfo> OnAnimationStart;
        public System.Action<AnimatorStateInfo> OnAnimationEnd;

        public Animator animator { get; private set; }


        void Awake()
        {
            animator = GetComponent<Animator>();
        }


        /// <summary>
        /// Note: YOU HAVE TO CALL THIS FROM THE ANIMATION, WILL NOT BE CALLED AUTOMATICALLY
        /// </summary>
        /// <param name="animationLayer">Layer the animation is on</param>
        public void NotifyObserversOnStart(int animationLayer)
        {
            OnAnimationStart?.Invoke(animator.GetCurrentAnimatorStateInfo(animationLayer));
        }


        /// <summary>
        /// Note: YOU HAVE TO CALL THIS FROM THE ANIMATION, WILL NOT BE CALLED AUTOMATICALLY
        /// </summary>
        /// <param name="animationLayer">Layer the animation is on</param>
        public void NotifyObserversOnEnd(int animationLayer)
        {
            OnAnimationEnd?.Invoke(animator.GetCurrentAnimatorStateInfo(animationLayer));
        }
    }
}
