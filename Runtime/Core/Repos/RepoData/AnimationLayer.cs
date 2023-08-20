using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Repos.RepoData
{
    public class AnimationLayer
    {
        public string name { get; private set; }


        public AnimationLayer(string _name)
        {
            name = _name;
        }


        public int GetIndex(Animator animator)
        {
            return animator.GetLayerIndex(name);
        }
    }
}
