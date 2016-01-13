using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TeamSystem : MonoBehaviour
{

    #region Properties
    
    private int now = 1;
    public Sprite underChoice;
    private bool isChanging = false;
    private bool isDetail = false;
    private bool isOnce = false;
    private int choice;

    private GameObject menu;
    private GameObject det_menu;
    private GameObject sub_mosse;
    private GameObject sub_generale;
    #endregion Properties
    #region Methods

    void Start()
    {
        ChangeChoice(1);
        menu = GameObject.Find("principal_menu");
        det_menu = GameObject.Find("detail_menu");
        sub_generale = GameObject.Find("detail_menu/Multimenu/sub_generale");
        sub_mosse = GameObject.Find("detail_menu/Multimenu/sub_mosse");
        det_menu.SetActive(false);
        LoadMenu();
    }

    void Update () {

        //menu
        if (menu.activeSelf)
        {
            FunctionMenu();
        }
        
        //dettagli pokemon
        if (isDetail)
        {
            DetailMenu();
        }

        //Chiusura menu
        if (Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf)
            menu.SetActive(false);
        else if (Input.GetKeyDown(KeyCode.Escape) && det_menu.activeSelf)
        {
            det_menu.SetActive(false);
            menu.SetActive(true);
        }
        
	}


    private void LoadMenu()
    {
        //1
        foreach (Transform child in GameObject.Find("principal_menu/1").transform)
        {
            string name = child.name;
            switch (name)
            {
                case "HP":
                    child.GetComponent<Text>().text = "10/10";
                    break;
                case "Name":
                    child.GetComponent<Text>().text = "Volern porcodue";
                    break;
                case "LVL":
                    child.GetComponent<Text>().text = "50";
                    break;
            }
        }

        //2

        //3

        //4

        //5

        //6
    }

    private void FunctionMenu()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            now++;
            if (now > 6) now = 1;
            ChangeChoice(now);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            now--;
            if (now < 1) now = 6;
            ChangeChoice(now);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            isChanging = true;
            choice = now;
        }
        if (isChanging && Input.GetKeyDown(KeyCode.Return))
        {
            ChangePositionPokemon(choice, now);
            isChanging = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            isDetail = true;
            isOnce = true;
        }
    }

    private void DetailMenu()
    {
        if (isOnce)
        {
            PokemonDetailLoad();
            isOnce = false;
        }
    }

    private void ChangeChoice(int choice)
    {
        for (int i = 1; i <= 6; i++)
        {
            GameObject.Find(i.ToString() + "/Choice").GetComponent<SpriteRenderer>().sprite = null;
        }
        GameObject.Find(choice.ToString() + "/Choice").GetComponent<SpriteRenderer>().sprite = underChoice;
    }

    private void ChangePositionPokemon(int begin, int end)
    {
        string temp_hp = GameObject.Find("principal_menu/" + end + "/HP").GetComponent<Text>().text;
        string temp_lvl = GameObject.Find("principal_menu/" + end + "/LVL").GetComponent<Text>().text;
        string temp_name = GameObject.Find("principal_menu/" + end + "/Name").GetComponent<Text>().text;
        Sprite temp_sprite = GameObject.Find("principal_menu/" + end).GetComponent<SpriteRenderer>().sprite;

        GameObject.Find("principal_menu/" + end + "/HP").GetComponent<Text>().text = GameObject.Find("principal_menu/" + begin + "/HP").GetComponent<Text>().text;
        GameObject.Find("principal_menu/" + end + "/LVL").GetComponent<Text>().text = GameObject.Find("principal_menu/" + begin + "/LVL").GetComponent<Text>().text;
        GameObject.Find("principal_menu/" + end + "/Name").GetComponent<Text>().text = GameObject.Find("principal_menu/" + begin + "/Name").GetComponent<Text>().text;
        GameObject.Find("principal_menu/" + end).GetComponent<SpriteRenderer>().sprite = GameObject.Find("principal_menu/" + begin).GetComponent<SpriteRenderer>().sprite;

        GameObject.Find("principal_menu/" + begin + "/HP").GetComponent<Text>().text = temp_hp;
        GameObject.Find("principal_menu/" + begin + "/LVL").GetComponent<Text>().text = temp_lvl;
        GameObject.Find("principal_menu/" + begin + "/Name").GetComponent<Text>().text = temp_name;
        GameObject.Find("principal_menu/" + begin).GetComponent<SpriteRenderer>().sprite = temp_sprite;
    }

    private void PokemonDetailLoad()
    {
        det_menu.SetActive(true);
        //Base
        GameObject.Find("detail_menu/PokemonImg").GetComponent<SpriteRenderer>().sprite = GameObject.Find("principal_menu/" + now).GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("detail_menu/Pokemon_name").GetComponent<Text>().text = GameObject.Find("principal_menu/" + now + "/Name").GetComponent<Text>().text;
        GameObject.Find("detail_menu/Pokemon_lvl").GetComponent<Text>().text = "Lv. " + GameObject.Find("principal_menu/" + now + "/LVL").GetComponent<Text>().text;

        GameObject.Find("detail_menu/Multimenu/Mosse").GetComponent<Button>().onClick.AddListener(AttacksClicked);
        GameObject.Find("detail_menu/Multimenu/Generale").GetComponent<Button>().onClick.AddListener(GeneralClicked);

        //Generale
        GameObject.Find("detail_menu/Multimenu/sub_generale/NrPokedex").GetComponent<Text>().text = "666";
        GameObject.Find("detail_menu/Multimenu/sub_generale/name").GetComponent<Text>().text = "Blinx";
        GameObject.Find("detail_menu/Multimenu/sub_generale/Type").GetComponent<Text>().text = "Folletto";
        GameObject.Find("detail_menu/Multimenu/sub_generale/Exp").GetComponent<Text>().text = "0000000001";
        GameObject.Find("detail_menu/Multimenu/sub_generale/ExpToLvl").GetComponent<Text>().text = "1000000001";

        //Mosse
        for (int i = 1; i <= 4; i++)
        {
            GameObject.Find("detail_menu/Multimenu/sub_mosse/" + i).GetComponent<Text>().text = "funziona";
            GameObject.Find("detail_menu/Multimenu/sub_mosse/" + i + "_moves").GetComponent<Text>().text = "10/" + i + "0";
        }

        menu.SetActive(false);
        sub_mosse.SetActive(false);
    }

    private void AttacksClicked()
    {
        sub_mosse.SetActive(true);
        sub_generale.SetActive(false);
    }

    private void GeneralClicked()
    {
        sub_generale.SetActive(true);
        sub_mosse.SetActive(false);
    }
    enum choices
    {
        first = 1,
        second = 2,
        third = 3,
        fourth = 4,
        fifth = 5,
        sixth = 6
    }

    #endregion Methods
}
