using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace JosephLyons.Core.Functionality
{
    public class Math
    {
        public static float Round(float num, int numberDecimalPlaces = 1)
        {
            if(numberDecimalPlaces < 0) return num; // If input invalid just return num

            int placeModifier = Mathf.RoundToInt(Mathf.Pow(10, numberDecimalPlaces));
            return Mathf.Round(num * placeModifier) / placeModifier;
        }


        public static int Switch0And1(int num)
        {
            Assert.IsTrue(num == 0 || num == 1);
            
            return (num - 1) * (num - 1);
        }


        /// <summary> 
        /// Converts 0 to -1 and 1 to 1
        ///</summary>
        public static int ZeroToNegativeOne (int num)
        {
            Assert.IsTrue(num == 0 || num == 1);

            return (2 * num) - 1;
        }
    }
}
