using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Save Configuration", menuName = "Configurations/Save Configuration", order = 1)]
public class SaveConfiguration : ScriptableObject
{
    public float[] floatData;
    public float[] inventoryData;
    public float[] amountData;

    public void AddData(int id, float data)
    {
        if (floatData.Length > id)
            floatData[id] = data;
        else
            Array.Resize(ref floatData, id + 1);
    }

    public float GetData(int id, float data)
    {
        if (floatData.Length > id)
            return floatData[id];
        else
            return data;
    }
}
