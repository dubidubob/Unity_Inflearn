using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    public virtual void Init() //always make Init method instead of just using start
    {
        Managers.UI.SetCanvas(gameObject, false);
    }
}
