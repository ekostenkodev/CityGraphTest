using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private CityGenerator _cityGenerator;
    [SerializeField] private InputField _roadCount;
    
    public event UnityAction CityGenerated = delegate {}; 
    
    public void GenerateCity()
    {
        try
        {
            int roadCount = Convert.ToInt32(_roadCount.text);
            _cityGenerator.GenerateCity(roadCount);
            CityGenerated.Invoke();
        }
        catch (FormatException e)
        {
            Debug.Log($"{e.Message}");
        }
        
    }

}
