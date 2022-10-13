using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Main : MonoBehaviour
{
    [SerializeField] private Image morningImage;
    [SerializeField] private Image nightImage;


    [SerializeField] private GameObject studentInputMenu;
    [SerializeField] private GameObject classInputMenu;

    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField surnameInput;

     [SerializeField] private TMP_InputField branchInput;
    [SerializeField] private TMP_InputField capacityInput;

    [SerializeField] private Transform classesParent;
    [SerializeField] private GameObject classText;

    [SerializeField] private TMP_Text morningPop;
    [SerializeField] private TMP_Text nightPop;

    public bool isMorning = true;









    int classNumber = 0;
   public int studentPopulation = 0;
    public int morningPopulation = 0;
    int totalCapacity = 0;
    float solidityRatio = 1;

    
    public Classes[] classes;

    
    public Student[] students;





    private void Start()
    {
        classes = new Classes[30];
        students = new Student[300];

        LoadData();
        setPopulations();

    }




    public void SaveData()
    {
        SaveSystem.SaveData(this);

    }
    private void LoadData()
    {
        Data data = SaveSystem.LoadPlayer();
        students = data.students;
        studentPopulation = data.studentPopulation;
        morningPopulation = data.morningPopulation;

    }


    public void ResetEverything()
    {
        studentPopulation = 0;
        morningPopulation = 0;
        setPopulations();
    }


    public void FillClasses()
    {

        for (int i = 0; i < classNumber; i++)
        {
            classes[i].population = 0;
        }
        for (int i = 0; i < studentPopulation; i++)
        {
            students[i].haveClass = false;
        }

           for (int i = 0;  i< classNumber; i++)
        {
            int randomStudent;
            while (!classes[i].isClassFull(1)&& !isAllStudents())
            {
             randomStudent =Random.Range(0,studentPopulation);

                    if (!students[randomStudent].haveClass && students[randomStudent].isMorning == isMorning)
                        classes[i].AddStudent(students[randomStudent]);

            }



        }
       
      
          
            
        
    }

     
    public void AddClass()
    {
        if (branchInput.text != string.Empty && capacityInput.text != string.Empty)
        {
            classes[classNumber] = new Classes();
            classes[classNumber].SetClasses(branchInput.text, int.Parse(capacityInput.text));
            ClassIdentifier();
            totalCapacity += classes[classNumber].capacity;
            Debug.Log(classes[classNumber].branch);
            classNumber++;
            
        }
        else
            Debug.Log("sube giriniz");

        branchInput.text = string.Empty;
        capacityInput.text = string.Empty;
    }
    public void OpenClassInput()
    {
        classInputMenu.SetActive(true);
        branchInput.text = string.Empty;
        capacityInput.text = string.Empty;
    }

    public void CloseClassInput()
    {
        classInputMenu.SetActive(false);

    }


    public void AddStudent()
    {
        if (nameInput.text != string.Empty && surnameInput.text != string.Empty)
        {
            students[studentPopulation] = new Student();
            students[studentPopulation].SetStudent(nameInput.text, surnameInput.text, isMorning);
            studentPopulation++;
            if (isMorning)
                morningPopulation++;
            setPopulations();
        }
        else
            Debug.Log("isim soyisim giriniz");

        
        nameInput.text = string.Empty;
        surnameInput.text = string.Empty;
        
    }


    public void OpenInputTextMorning()
    {
        studentInputMenu.SetActive(true);
        nameInput.text = string.Empty;  
        surnameInput.text = string.Empty;
        ChangeTimeMorning();
    }
    public void OpenInputTextNight()
    {
        studentInputMenu.SetActive(true);
        nameInput.text = string.Empty;
        surnameInput.text = string.Empty;
        ChangeTimeNight();

    }

    public void CloseInputText()
    {
        studentInputMenu.SetActive(false);

    }






    public void ChangeTimeMorning()
    {
        isMorning = true;
        TimeButtonColors();
    }
    public void ChangeTimeNight()
    {
        isMorning = false;
        TimeButtonColors();
    }
    private void TimeButtonColors()
    {
        if (isMorning)
        {
            morningImage.color = Color.blue;
            nightImage.color = Color.white;
        }
        else
        {
            morningImage.color = Color.white;
            nightImage.color = Color.blue;
        }
    }


    private void setPopulations()
    {
        morningPop.text = morningPopulation.ToString();
        nightPop.text = (studentPopulation - morningPopulation).ToString();
    }


    private void ClassIdentifier()
    {
       GameObject textC = Instantiate(classText, Vector3.zero, Quaternion.identity, classesParent);
        textC.transform.localPosition = new Vector3(0, 3 - 25 * classNumber, 0);
        textC.GetComponent<TMP_Text>().text = (classes[classNumber].branch + " : " + classes[classNumber].capacity.ToString());

    }


    private bool isAllStudents()
    {
       

        for (int i = 0; i < studentPopulation; i++)
        {
            if (!students[i].haveClass && students[i].isMorning == isMorning)
                return false;

        }

        return true;
    }


}
