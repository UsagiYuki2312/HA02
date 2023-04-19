using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

public class AGameInstance  : Singleton<AGameInstance>
{
    private void Awake()
    {
        this.SetTimeScale(1);
    }
}
