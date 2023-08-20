using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Repos.RepoData
{
    /// <summary>
    /// Holds info for Unity layers in code for easy retrieval
    /// </summary>
    public class LayerInfo
    {
        public string name { get; private set; }
        public int index { get; private set; }
        public LayerMask mask { get; private set; }

        public LayerInfo(string _name)
        {
            name = _name;
            index = LayerMask.NameToLayer(name);
            mask = LayerMask.GetMask(name);
        }
    }
}
