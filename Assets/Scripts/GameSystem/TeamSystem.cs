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
    #endregion Properties
    #region Methods

    void Start()
    {
        ChangeChoice(1);
        menu = GameObject.Find("principal_menu");
        det_menu = GameObject.Find("detail_menu");
        det_menu.SetActive(false);
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
        GameObject.Find("detail_menu/PokemonImg").GetComponent<SpriteRenderer>().sprite = GameObject.Find("principal_menu/" + now).GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("detail_menu/Pokemon_name").GetComponent<Text>().text = GameObject.Find("principal_menu/" + now + "/Name").GetComponent<Text>().text;
        GameObject.Find("detail_menu/Pokemon_lvl").GetComponent<Text>().text = "Lv. " + GameObject.Find("principal_menu/" + now + "/LVL").GetComponent<Text>().text;
        GameObject.Find("detail_menu/Multimenu/Mosse").GetComponent<Button>().onClick.AddListener(Attacks);
        menu.SetActive(false);
    }

    private void Attacks()
    {
        Debug.Log("funziona");
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
