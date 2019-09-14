using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Institutions/Post office")]
public class PostOffice : Institution
{
    public override Type Type => typeof(PostOffice);
}
