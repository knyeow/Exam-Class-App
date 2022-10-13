using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Classes {

   public string branch;
    public int capacity;
    public int population = 0;

   public void  SetClasses(string branch, int capacity)
    {
        this.branch = branch;
        this.capacity = capacity;
    }

    public void AddStudent(Student student)
    {
        student.SetClass(this);
        population++;
    }

    public bool isClassFull(float solidityRatio)
    {
        return population >= capacity * solidityRatio;
    }
}

