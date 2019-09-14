using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Institutions/Hospital")]
public class Hospital : Institution
{
    public override Type Type => typeof(Hospital);
}
