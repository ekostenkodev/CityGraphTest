using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPanel : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private Text _startNode;
    private Institution[] _institutions;

    #region MonoBehaviour

    void Start()
    {
        // подписываемся на событие нажатия на узел, чтобы обновить наш текст
        InputSystem.Instance.StartNodeSetted += (node) => _startNode.text = node.Position.ToString();
        _menu.CityGenerated += ClearFields;

        _institutions = Resources.LoadAll<Institution>("ScriptableObjects/Institutions");
        FillDropdownList();

        _dropdown.onValueChanged.AddListener(DropdownValueChanged);
    }

    #endregion

    private void ClearFields()
    {
        _dropdown.value = 0;
        _startNode.text = String.Empty;
    }

    
    private void FillDropdownList()
    {
        List<Dropdown.OptionData> data = new List<Dropdown.OptionData>();
        
        foreach (var institution in _institutions)
            data.Add(new Dropdown.OptionData(institution.Name, institution.Sprite));
        
        _dropdown.AddOptions(data);
    }

    private void DropdownValueChanged(int index)
    {    
        // сделано для косметического эффекта, тк dropdown не имеет пустых вкладок - что влечет к тому, что какой-то пункт УЖЕ выбран в самом начале
        if (--index < 0)
            InputSystem.Instance.SetTargetInstitution(null);
        else
            InputSystem.Instance.SetTargetInstitution(_institutions[index].GetType());
        
    }
    
   
}
