using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutUtil
{
    public static Rect GetRect(Rect position, float posX, float posY, float nbCol, float nbRow)
    {
        float maxCol = 12;
        float maxRow = 12;

        float rectW = position.width / maxCol;
        float rectH = position.height / maxRow;

        return new Rect(posX * rectW, posY * rectH, nbCol * rectW, nbRow * rectH);
    }
}
