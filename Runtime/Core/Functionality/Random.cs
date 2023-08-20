using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Functionality
{
    public class Random
    {
        /// <summary>
        /// Generates a random number between -1 and 1, where values around zero are more likely
        /// </summary>
        /// <returns></returns>
        /// Millington, Ian. AI for Games. Boca Raton, Fl, Crc Press, Taylor & Francis Group, 2019.
        public static float GenerateRandomBinomial()
        {
            return UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f);
        }
    }
}
