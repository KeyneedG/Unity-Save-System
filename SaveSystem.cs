using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public SaveConfiguration saveConfiguration;
    public InventoryManager inventoryManager;

    private void Awake()
    {
        Load();
    }

    private void Start()
    {
        StartCoroutine(SaveTimer());
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "StrangerGameSave.txt"))
        {
            string textFile = File.ReadAllText(Application.persistentDataPath + "StrangerGameSave.txt");
            string[] textFileArray;
            textFileArray = textFile.Split(' ');
            saveConfiguration.floatData = StringArray(textFileArray);
        }

        if (File.Exists(Application.persistentDataPath + "StrangerInventorySave.txt"))
        {
            string textFileInv = File.ReadAllText(Application.persistentDataPath + "StrangerInventorySave.txt");
            string[] textFileArrayInv;
            textFileArrayInv = textFileInv.Split(' ');
            //if(textFileArrayInv.Length > 0)
            saveConfiguration.inventoryData = StringArray(textFileArrayInv);

            string textFileA = File.ReadAllText(Application.persistentDataPath + "StrangerAmountSave.txt");
            string[] textFileArrayA;
            textFileArrayA = textFileA.Split(' ');
            //if(textFileArrayInv.Length > 0)
            saveConfiguration.amountData = StringArray(textFileArrayA);
        }
    }

    public void Save()
    {
        File.WriteAllText(Application.persistentDataPath + "StrangerGameSave.txt", FloatArray(saveConfiguration.floatData));
        if (inventoryManager.inventory.Count > 0)
        {
            File.WriteAllText(Application.persistentDataPath + "StrangerInventorySave.txt", FloatArray(saveConfiguration.inventoryData));
            File.WriteAllText(Application.persistentDataPath + "StrangerAmountSave.txt", FloatArray(saveConfiguration.amountData));
        }
    }

    public string FloatArray(float[] data)
    {
        int i = 0;
        string finalText = string.Empty;

        while (i < data.Length)
        {
            finalText += data[i].ToString();
            if (i < data.Length - 1)
            {
                i++;
                finalText += " ";
            }
            else
                break;
        }

        return finalText;
    }

    public float[] StringArray(string[] text)
    {
        int i = 0;
        float[] finalFloat = new float[text.Length];

        while (i < text.Length)
        {
            finalFloat[i] = float.Parse(text[i]);
            i++;
        }

        return finalFloat;
    }

    IEnumerator SaveTimer()
    {
        yield return new WaitForSeconds(60);
        Save();
        StartCoroutine(SaveTimer());
    }
}
