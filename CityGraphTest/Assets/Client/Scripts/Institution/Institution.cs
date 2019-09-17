using UnityEngine;

public abstract class Institution : ScriptableObject
{
    [SerializeField] private string _name;

    public string Name => _name;
    public Sprite Sprite;
}
