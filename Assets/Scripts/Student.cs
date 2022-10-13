using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Student
{
   public string name;
    public string surname;
    public Classes stClass;
    public bool haveClass = false;
    public bool isMorning = true;

    public void SetStudent(string name, string surname, bool isMorning)
    {
        this.name = name;
        this.surname = surname;
        this.isMorning = isMorning;
    }

    public void SetClass(Classes stClass)
    {
        this.stClass = stClass;
        haveClass = true;

    }


    



}
