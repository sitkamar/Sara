using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Text labelText;
    public Text labelName;
    public GameObject Leyla;
    public GameObject Ty;
    public GameObject Lina;
    public GameObject Vila;
    public GameObject conversation;
    public GameObject decision;
    private string name;
    private string text;
    public Text dis1;
    public Text dis2;
    public Text dis3;
    private string fileName;
    private string playerName;
    private int row = 0;
    private string[] allText;
    private bool isConversation = true;
    public void Start()
    {
        allText = System.IO.File.ReadAllLines(@"Assets\Texts\Prvni_text.txt");
        row = 0;
        conversation.SetActive(true);
        decision.SetActive(false);
        Leyla.SetActive(false);
        Ty.SetActive(false);
        Lina.SetActive(false);
        Vila.SetActive(false);
        playerName = Settings.name;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isConversation)
            {
                if (labelText.text.Contains("konec"))
                {
                    Menu();
                }
                else
                {
                    UpdateLabels();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }
    }
    public void UpdateLabels()
    {

        while (allText[row] == "")
        {
            row++;
        }
        if (row > allText.Length - 5 && !allText[allText.Length - 1].Contains("konec"))
        {
            conversation.SetActive(false);
            decision.SetActive(true);
            isConversation = false;
            UpdateDecision();
        }
        else
        {
            while (allText[row] == "")
            {
                row++;
            }
            name = allText[row];
            row++;
            while (allText[row] == "")
            {
                row++;
            }
            text = allText[row].Replace("name", playerName);
            row++;
            changeCharacter(name);
            labelText.text = text;
            labelName.text = name;
        }
    }
    private void changeCharacter(string name){
        Leyla.SetActive(false);
        Ty.SetActive(false);
        Lina.SetActive(false);
        Vila.SetActive(false);
        if(name.Contains("Leyla")){
            Leyla.SetActive(true);
        }
        if(name.Contains("Ty")){
            Ty.SetActive(true);
        }
        if(name.Contains("Lina")){
            Lina.SetActive(true);
        }
        if(name.Contains("Víla")){
            Vila.SetActive(true);
        }

    }
    public void UpdateDecision()
    {
        while (allText[row] == "")
        {
            row++;
        }
        labelName.text = allText[row].Replace("name", playerName);
        row++;
        while (allText[row] == "")
        {
            row++;
        }
        dis1.text = allText[row].Replace("name", playerName);
        row++;
        while (allText[row] == "")
        {
            row++;
        }
        dis2.text = allText[row].Replace("name", playerName);
        row++;
        while (allText[row] == "")
        {
            row++;
        }
        dis3.text = allText[row].Replace("name", playerName);
    }
    public void voidForDis1()
    {
        fileName = dis1.text.Substring(3).Replace(" ", "_").Replace(playerName,"Jindřich") + ".txt";
        newFile();
        UpdateLabels();
    }
    public void voidForDis2()
    {
        fileName = dis2.text.Substring(3).Replace(" ", "_").Replace(playerName,"Jindřich") + ".txt";
        newFile();
        UpdateLabels();
    }
    public void voidForDis3()
    {
        fileName = dis3.text.Substring(3).Replace(" ", "_").Replace(playerName,"Jindřich") + ".txt";
        newFile();
        UpdateLabels();
    }
    public void newFile()
    {
        conversation.SetActive(true);
        decision.SetActive(false);
        isConversation = true;
        row = 0;
        allText = System.IO.File.ReadAllLines(@"Assets\Texts\" + fileName);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
