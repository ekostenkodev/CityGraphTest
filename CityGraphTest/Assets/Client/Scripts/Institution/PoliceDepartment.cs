using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Institutions/Police department")]
public class PoliceDepartment : Institution
{
    public override Type Type => typeof(PoliceDepartment);
}
