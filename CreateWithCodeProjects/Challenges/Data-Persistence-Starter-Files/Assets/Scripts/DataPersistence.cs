using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public new string name;
    public string trierName;
    public int bestScore;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
}
