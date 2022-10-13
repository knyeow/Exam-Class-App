using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteExcel:MonoBehaviour
{
    [SerializeField] private GameObject manage;

    private Main manageMain;

    private void Start()
    {
        manageMain = manage.GetComponent<Main>();
        fileName = Application.dataPath + "/test.csv";
    }



    string fileName = " ";

    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int damage;
        public int defence;


    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList playerList = new PlayerList();



   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            WriteCsv();
        
    }

    public void WriteCsv()
    {
        fileName = Application.dataPath + (manageMain.isMorning ? "/Sabah" : "/Aksam") + "list.csv";
        TextWriter tw = new StreamWriter(fileName,false);

        
        tw.WriteLine((manageMain.isMorning ?"              SABAH":"AKÞAM")+"GRUBU SINIF LÝSTESÝ");
        tw.WriteLine("Soyadý  " + "Adý  " + "Sýnýfý");
        tw.Close();

        tw = new StreamWriter(fileName, true);

        

        for(int i =0; i < manageMain.studentPopulation; i++)

        {
            if (manageMain.students[i].isMorning ==manageMain.isMorning)
            tw.WriteLine(manageMain.students[i].surname + "  " + manageMain.students[i].name + "  " + manageMain.students[i].stClass.branch);

        }

        tw.Close();
    }
}
