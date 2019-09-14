using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Navigator _navigator;
    [SerializeField] private CityGenerator _cityGenerator;
    [SerializeField] private InputField _roadCount;
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private Text _startNode;

    private void Start()
    {
        
    }

    public void GenerateCity()
    {
        try
        {
            int roadCount = Convert.ToInt32(_roadCount.text);
            _cityGenerator.GenerateCity(roadCount);

        }
        catch (FormatException e)
        {
            Debug.Log($"{e.Message}");
        }
        
    }

}
