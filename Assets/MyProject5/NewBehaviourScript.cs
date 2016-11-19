using UnityEngine;
using System.Collections;
using System;

[DisallowMultipleComponent]
public class NewBehaviourScript : MonoBehaviour
{
    [Range(1, 10)]
    public int num1;

    [Range(1, 10)]
    public float num2;

    [Range(1, 10)]
    public long num3;

    [Range(1, 10)]
    public double num4;
    
    [Header("Player Settings")]
    public Player player;

    [Serializable]
    public class Player
    {
        public string name;

        [Range(1,100)]
        public int hp;
    }

    [Header("Game Settings")]
    public Color background;
    
    [Space(16)]
    public string str1;
    
    [Tooltip("これはツールチップです")]
    public long tooltip;
}