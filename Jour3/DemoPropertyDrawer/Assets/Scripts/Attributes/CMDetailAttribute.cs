using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMDetailAttribute : PropertyAttribute
{
    public bool IsVisible;
    public CMDetailAttribute(bool isVisible)
    {
        this.IsVisible = isVisible;
    }
}
