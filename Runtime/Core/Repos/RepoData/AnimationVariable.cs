using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Repos.RepoData
{
    /// <summary>
    /// Class to interact with animation variables
    /// </summary>
    public class AnimationVariable
    {
        public string name { get; private set; }
        int? id = null;


        public AnimationVariable(string _name, int? _hash = null)
        {
            name = _name;
            id = _hash;
        }


        public int GetID()
        {
            if(id.HasValue == false)
            {
                id = Animator.StringToHash(name);
            }

            return id.Value;
        }
    }
}
