using System.Collections.Generic;
using UnityEngine;

public static class dRandom
{
    #region Basics
    public static bool RollChance(float chance)
    {
        return Random.value <= chance;
    }

    public static bool FlipCoin()
    {
        return Random.Range(0, 2) == 0;
    }
    #endregion

    #region Array and List related

    public static T RandomElement<T>(List<T> list)
    {
        if (list.Count <= 0) return default(T);
        return list[Random.Range(0, list.Count)];
    }
    public static T RandomElement<T>(T[] list)
    {
        if (list.Length <= 0) return default(T);
        return list[Random.Range(0, list.Length)];
    }

    public static T RandomElementParams<T>(params T[] elements)
    {
        return RandomElement(elements);
    }

    public static List<T> Randomize<T>(List<T> list)
    {
        List<T> newList = new List<T>(list.Count);
        List<T> elements = new List<T>(list);

        while (elements.Count > 0)
        {
            var element = elements[Random.Range(0, elements.Count)];
            newList.Add(element);
            elements.Remove(element);
        }
        return newList;
    }

    #endregion

}

public static class dRandomExtensions
{
    public static T RandomElement<T>(this List<T> t)
    {
        return dRandom.RandomElement(t);
    }
}