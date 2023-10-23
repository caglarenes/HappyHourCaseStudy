using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : ScopedSingleton<InGameUIManager>
{
    public List<IView> Views;
}
