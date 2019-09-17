using UnityEngine;

public abstract class Institution : ScriptableObject
{
    public Sprite Sprite;
    [SerializeField] private string _name;
    public string Name => _name;
}
