using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Game2 : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int lastDate_hour;
    }
    public TMP_InputField currentNameIF;
    public TextMeshProUGUI bestNameText;
    public string bestName;
    //System//
    //Lognin
    DateTime nowDate;
    DateTime nowfirstDate;
    private int ts;
    private int tts;
    private int hp;
    private int todayDate;
    private int todayDate_hour;
    private int lastDate;
    private int lastDate_hour;
    private Animator animator;
    private bool iseat = false;
    public TextMeshProUGUI DateTimeText;
    public TextMeshProUGUI DateHourText;
    SaveData data = new SaveData();

    void Start()
    {
        GetSaveData();
        Login();
        //DataSave();
        animator = GetComponent<Animator>();
    }

    void Login()
    {
        nowDate = DateTime.Now;
        todayDate = nowDate.Year * 525600 + nowDate.Month * 43800 + nowDate.Day * 1440 + nowDate.Hour * 60 + nowDate.Minute;
        todayDate_hour = nowDate.Year * 8760 + nowDate.Month * 730 + nowDate.Day * 24 + nowDate.Hour;

        nowfirstDate = new DateTime(nowDate.Year, nowDate.Month, 1);
        DayOfWeek firstDate = nowfirstDate.DayOfWeek;

        ts = todayDate_hour - lastDate_hour;
        //tts = tts + ts;
        //hp = hp - ts;
        DateTimeText.text =  nowDate.ToString();
        //Debug.Log("today_day" + nowDate);
        //Debug.Log("today" + todayDate);
        //Debug.Log("lastday" + lastDate);
        Debug.Log("today_day" + firstDate);

    }

    void DataSave()
    {
        //PlayerPrefs.SetInt("LastHp", hp);
    }



    void Update()
    {
    }


    public void AfterFishye() //ÉGÉTÇ‚ÇÈ
    {
        if(iseat == true)
        {
            animator.SetBool("eat", false);
            iseat = false;
        }
        else if (iseat == false)
        {
            animator.SetBool("eat", true);
            iseat = true;
            Debug.Log("eat" + iseat);

        }

    }

    public void OnSetButtonClicked() //save
    {
        string currentName;
        //int currentScore;
        currentName = currentNameIF.text;
        //currentScore = int.Parse(currentScoreIF.text);
        bestNameText.text = "Name: " + currentName;
        //bestScoreText.text = "Score: " + currentScore;
        data.lastDate_hour = todayDate_hour;
        data.bestName = currentName;
        //data.bestScore = currentScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void GetSaveData() //load
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            lastDate_hour = data.lastDate_hour;
            bestName = data.bestName;
            //bestScore = data.bestScore;
        }
        else
        {
            lastDate_hour = 0;
            bestName = "";
            //bestScore = 0;
        }

        bestNameText.text = "Name: " + bestName;
        DateHourText.text = "Hour: " + lastDate_hour;
        //bestScoreText.text = "Score: " + bestScore;

    }
}