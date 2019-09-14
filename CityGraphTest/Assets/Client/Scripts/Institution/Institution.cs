using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Institution : ScriptableObject
{
    public Sprite Sprite;

    public abstract Type Type { get; }
}
