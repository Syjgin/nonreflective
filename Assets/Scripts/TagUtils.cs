using System;
using UnityEngine;

public class TagUtils
{
    public static bool IsPlayer(Collider other)
    {
        return CompareTag(other, "Player");
    }
    
    public static bool IsEnemy(Collider other)
    {
        return CompareTag(other, "enemy");
    }

    private static bool CompareTag(Collider other, String tag)
    {
        return other.gameObject.CompareTag(tag);
    }
}