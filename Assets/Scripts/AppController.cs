using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public static AppController Instance;
    [SerializeField] private TMP_InputField mainScreen;
    [SerializeField] private GameObject onScreen;
    Animator animator;
    bool isOn, isError;

    private void Awake()
    {
        Instance = this;
        StopProgram();
        isError = false;
        animator = onScreen.GetComponent<Animator>();
    }

    public void StartProgram()
    {
        isOn = true;
        onScreen.SetActive(isOn);
        CheckError();
    }

    public void StopProgram()
    {
        mainScreen.text = "";
        isOn = false;
        onScreen.SetActive(isOn);
    }

    public void ShowResult()
    {
        if (isOn && !isError)
            mainScreen.text = Calculator(mainScreen.text);
    }

    public void AddNumber(string value)
    {
        if (isOn)
        {
            mainScreen.text += value;
            CheckError();
        }
    }

    public void RemoveOne()
    {
        int count = mainScreen.text.Length;
        if (count > 0)
            mainScreen.text = mainScreen.text.Remove(count - 1);
        CheckError();
    }

    public void RemoveAll()
    {
        mainScreen.text = "";
        CheckError();
    }

    public string Calculator(string math)
    {
        try
        {
            if (math.Length == 0) math = "0";
            if (math[0] == '*' || math[0] == '/') throw new Exception("Failed");
            DataTable table = new DataTable();
            double result = (double)table.Compute("(2 - 2) / 2 + " + math, null);
            return string.Format("{0:0.00}", result);
        }
        catch
        {
            throw new Exception("Failed");
        }
    }

    void CheckError()
    {
        try
        {
            _ = Calculator(mainScreen.text);
            isError = false;
        }
        catch
        {
            isError = true;
        }
        animator.SetBool("isError", isError);
    }
}
