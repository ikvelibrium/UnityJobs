using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct LogSolve : IJob
{

    public NativeArray<int> RandomNumbers;
    public void Execute()
    {
        for (int i = 0; i < RandomNumbers.Length; i++)
        {
            Debug.Log(Math.Log(RandomNumbers[i]));
        }
    }

    
}
