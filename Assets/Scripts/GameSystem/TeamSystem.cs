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
    }

    void Update () {

        if (menu.activeSelf)
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
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf) menu.SetActive(false);
            else menu.SetActive(true);
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
        string temp_hp = GameObject.Find("principal_menu/HP/" + Enum.GetName(typeof(choices), end)).GetComponent<Text>().text ;
        string temp_lvl = GameObject.Find("principal_menu/LVL/" + Enum.GetName(typeof(choices), end)).GetComponent<Text>().text ;
        Sprite temp_sprite = GameObject.Find("principal_menu/Menu/" + end).GetComponent<SpriteRenderer>().sprite ;

        GameObject.Find("principal_menu/HP/" + Enum.GetName(typeof(choices), end)).GetComponent<Text>().text = GameObject.Find("principal_menu/HP/" + Enum.GetName(typeof(choices), begin)).GetComponent<Text>().text;
        GameObject.Find("principal_menu/LVL/" + Enum.GetName(typeof(choices), end)).GetComponent<Text>().text = GameObject.Find("principal_menu/LVL/" + Enum.GetName(typeof(choices), begin)).GetComponent<Text>().text;
        GameObject.Find("principal_menu/Menu/" + end).GetComponent<SpriteRenderer>().sprite = GameObject.Find("principal_menu/Menu/" + begin).GetComponent<SpriteRenderer>().sprite;

        GameObject.Find("principal_menu/HP/" + Enum.GetName(typeof(choices), begin)).GetComponent<Text>().text = temp_hp;
        GameObject.Find("principal_menu/LVL/" + Enum.GetName(typeof(choices), begin)).GetComponent<Text>().text = temp_lvl;
        GameObject.Find("principal_menu/Menu/" + begin).GetComponent<SpriteRenderer>().sprite = temp_sprite;
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
