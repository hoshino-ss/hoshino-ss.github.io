using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Game2Calender2 : MonoBehaviour
{
    public GameObject canvas;//�G�f�B�^����w��
    public GameObject prefab;//�G�f�B�^����w��

    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }
    }
}
