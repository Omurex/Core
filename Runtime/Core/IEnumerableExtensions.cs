using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public static class IEnumerableExtensions
{
    /// <summary>
    /// Shuffles copy of passed in enumerable
    /// </summary>
    /// <param name="enumerable">Anything that inherits from IEnumerable (list, stack, etc.)</param>
    /// <returns>Shuffled enumerable</returns>
    public static IEnumerable<T> GetShuffledEnumerable<T>(this IEnumerable<T> enumerable)
    {
        System.Random rnd = new System.Random();
        IEnumerable<T> shuffledEnumerable = enumerable.OrderBy(item => rnd.Next()).AsEnumerable();

        return shuffledEnumerable;
    }


    public static IEnumerable<T> GetShuffledEnumerable<T>(ref IEnumerable<T> enumerable)
    {
        return enumerable.GetShuffledEnumerable();
    }


    /// <summary>
    /// Gets shuffled copy of enumerable converted to a stack
    /// </summary>
    public static Stack<T> GetShuffledStack<T>(this IEnumerable<T> enumerable)
    {
        return new Stack<T>(enumerable.GetShuffledEnumerable());
    }


    public static Stack<T> GetShuffledStack<T>(ref IEnumerable<T> enumerable)
    {
        return enumerable.GetShuffledStack();
    }


    /// <summary>
    /// Gets shuffled copy of enumerable converted to a queue
    /// </summary>
    public static Queue<T> GetShuffledQueue<T>(this IEnumerable<T> enumerable)
    {
        return new Queue<T>(enumerable.GetShuffledEnumerable());
    }


    public static Queue<T> GetShuffledQueue<T>(ref IEnumerable<T> enumerable)
    {
        return enumerable.GetShuffledQueue();
    }


    /// <summary>
    /// Gets shuffled copy of enumerable converted to a linked list
    /// </summary>
    public static LinkedList<T> GetShuffledLinkedList<T>(this IEnumerable<T> enumerable)
    {
        return new LinkedList<T>(enumerable.GetShuffledEnumerable());
    }


    public static LinkedList<T> GetShuffledLinkedList<T>(ref IEnumerable<T> enumerable)
    {
        return enumerable.GetShuffledLinkedList();
    }


    /// <summary>
    /// Gets shuffled copy of enumerable converted to a list
    /// </summary>
    public static List<T> GetShuffledList<T>(this IEnumerable<T> enumerable)
    {
        return new List<T>(enumerable.GetShuffledEnumerable());
    }


    public static List<T> GetShuffledList<T>(ref IEnumerable<T> enumerable)
    {
        return enumerable.GetShuffledList();
    }
}
