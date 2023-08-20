using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JosephLyons.Core.Extensions
{
    /// <summary>
    /// A set of functions relating to vectors
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Converts Vector3 to float array
        /// </summary>
        /// <param name="vec">Any Vector3</param>
        /// <returns>Float array with 3 elements</returns>
        public static float[] ToFloatArray(this Vector3 vec)
        {
            return new float[] { vec.x, vec.y, vec.z };
        }


        /// <summary>
        /// Converts Vector2 to float array
        /// </summary>
        /// <param name="vec">Any Vector2</param>
        /// <returns>Float array with 2 elements</returns>
        public static float[] ToFloatArray(this Vector2 vec)
        {
            return new float[] { vec.x, vec.y };
        }


        /// <summary>
        /// Converts float array to Vector3
        /// </summary>
        /// <param name="arr">Array with only 3 elements</param>
        /// <returns>Array converted to Vector3</returns>
        public static Vector3 ToVector3(this float[] arr)
        {
            UnityEngine.Assertions.Assert.IsTrue(arr.Length == 3);

            return new Vector3(arr[0], arr[1], arr[2]);
        }


        /// <summary>
        /// Converts float array to Vector2
        /// </summary>
        /// <param name="arr">Array with only 2 elements</param>
        /// <returns>Array converted to Vector2</returns>
        public static Vector2 ToVector2(this float[] arr)
        {
            UnityEngine.Assertions.Assert.IsTrue(arr.Length == 2);

            return new Vector2(arr[0], arr[1]);
        }


        /// <summary>
        /// Gets length of vector that is guaranteed to have x as 0 or y as 0; faster than built-in Vector2Int.magnitude
        /// </summary>
        /// <param name="vec">Axis aligned vector; has x as 0 or y as 0</param>
        /// <returns>Length of vec</returns>
        public static int GetLengthOfAxisAlignedVec(this Vector2Int vec)
        {
            UnityEngine.Assertions.Assert.IsTrue(vec.x == 0 || vec.y == 0);

            return Mathf.Abs(vec.x + vec.y);
        }
    }
}
