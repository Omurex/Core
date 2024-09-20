using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Random
{
    [System.Serializable]
    public class ProbabilityTuple<T>
    {
        public T obj;

        public float probability;


        public ProbabilityTuple(T _obj, float _probability)
        {
            obj = _obj; probability = _probability;
        }


		public bool IsProbabilityZero()
		{
			return probability <= float.Epsilon;
		}
    }
}
