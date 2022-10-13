using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public Student[] students;
    public int studentPopulation;
    public int morningPopulation;

    public Data(Main main)
    {
        students = main.students;
        studentPopulation = main.studentPopulation;
        morningPopulation = main.morningPopulation;
    }
  
}
