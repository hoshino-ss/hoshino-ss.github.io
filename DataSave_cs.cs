using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;


public class DataSave_cs : MonoBehaviour
{

    [System.Serializable]
    public class SaveData
    {
        public string story_1;
        public string story_2;
    }
    public TMP_InputField currentNameIF;
    public TextMeshProUGUI bestNameText;
    public string bestName;
    private int button_num;
    SaveData data = new SaveData();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnSaveData() //save
    {
        string currentName;
        currentName = currentNameIF.text;
        bestNameText.text = "Name " + button_num + ": " + currentName;
        switch (button_num)
        {
            case 1:
                data.story_1 = currentName;
                break;
            case 2:
                data.story_2 = currentName;
                break;

            default:
                Debug.Log("defaultsave");
                break;
        }
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void GetSaveData() //load
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log(json);

            switch (button_num)
            {
                case 1:
                    bestName = data.story_1;
                    break;
                case 2:
                    bestName = data.story_2;
                    break;

                default:
                    Debug.Log("defaultsave");
                    break;
            }
        }
        else
        {
            bestName = "";
        }
        bestNameText.text = "Name" + button_num + ": " + bestName;
    }

    public void Button1()
    {
        button_num = 1;
        GetSaveData();
    }

    public void Button2()
    {
        button_num = 2;
        GetSaveData();
    }

}
