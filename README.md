# Unity-Save-System
Save system for Unity. Works due the text file.

Example of using:
```cs
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    public SaveConfiguration saveConfig;
    
    private float variableToSave;
    
    void Start()
    {
        variableToSave = saveConfig.GetData(0, variableToSave); //Get data from saved massive
    }
    
    void Update()
    {
        saveConfig.AddData(0, variableToSave); //Add data to massive
        
        variableToSave += Time.deltaTime;
    }
}
```
