using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public SaveConfiguration saveConfiguration;

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
        if (File.Exists(Application.persistentDataPath + "{YourGameName}.txt"))
        {
            string textFile = File.ReadAllText(Application.persistentDataPath + "{YourGameName}.txt");
            string[] textFileArray;
            textFileArray = textFile.Split(' ');
            saveConfiguration.floatData = StringArray(textFileArray);
        }
    }

    public void Save()
    {
        File.WriteAllText(Application.persistentDataPath + "{YourGameName}.txt", FloatArray(saveConfiguration.floatData));
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
