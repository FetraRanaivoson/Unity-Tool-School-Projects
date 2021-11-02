using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutUtil
{
    public static Rect GetRect(Rect position, float rowX, float rowY, float nbCol, float nbRow)
    {
        float maxCol = 12;
        float maxRow = 12;

        float rectW = position.width / maxCol;
        float rectH = position.height / maxRow;

        return new Rect(rowX * rectW, rowY * rectH, nbCol * rectW, nbRow * rectH);
    }
}


