using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Institution : ScriptableObject
{
    public Sprite Sprite;
    [SerializeField] private string _name;
    public string Name => _name;
}
