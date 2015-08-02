using UnityEngine;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;
using System.Collections;

namespace AncientTimes.Assets.Scripts.Intro
{
    public class Intro : MonoBehaviour
    {
        #region Properties

        private Animator animator;
        private GameObject Kerneth;
        private GameObject KShadow;
        private float timeElapsed = 0;
        private IntroState state;
        private string Nome = "Gimmy";
        private GameObject male;
        private GameObject female;
        private Animator SexAnim;


        #endregion Properties

        #region Methods
        void Start()
        {
            GameVariables.UpdateSwitch("IsChosen", false);
            GameVariables.UpdateSwitch("IsMan", false);
            SexAnim = GameObject.Find("Sex").GetComponent<Animator>();
            Kerneth = GameObject.Find("KernethSprite");
            KShadow = GameObject.Find("KShadow");
            animator = Kerneth.GetComponent<Animator>();
            male = GameObject.Find("male");
            female = GameObject.Find("female");
            ActiveSex(false);
        }

        void Update()
        {
            CheckState();
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
            EndSex();
            
        }

        void CheckState()
        {
            switch (state)
            {
                case IntroState.Beginning:
                    Timer();
                    break;
                case IntroState.StartExplanation:
                    StartExplanation();
                    break;
                case IntroState.ThaumeyComesOut:
                    ThaumeyComesOut();
                    break;
                case IntroState.Explanation:
                    Explanation();
                    break;
                case IntroState.Name:
                    Name();
                    break;
                case IntroState.Sex:
                    Sex();
                    break;
            }
        }

        void NextState() { state++; }

        void Timer()
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 2.0f)
            {
                NextState();
                timeElapsed = 0;
            }
        }

        void StartExplanation(){
	        Console.Write("Ben arrivato!");
	        Console.Write("Benvenuto in questo mondo popolato dai Pokémon!");
	        Console.Write("Io sono Kerneth ma tutti mi chiamano 'vecchio saggio' perché ho\n\ndedicato tutta la mia vita allo studio e al rispetto dei Pokémon!");
            Console.Write("Forse ti sarai chiesto che cosa siano i Pokémon di cui tanto parlo:\n\ntoh, eccone uno, quando si dice la coincidenza.");
            Console.MessageComplete += () => NextState();
            NextState();
        }

        void ThaumeyComesOut()
        {
            animator.SetBool("isOut", true);
            NextState();
        }

        void Explanation(){
            Console.Write("Su questo pianeta viviamo in simbiosi con creature che chiamiamo\n\nPokémon!\n\nSono davvero amici fedeli sai?");
            Console.Write("A volte persino preziosi alleati!");
            Console.Write("Nonostante ciò non sappiamo ancora tutto su queste meraviglie della\n\nnatura.");
            Console.Write("Per questo mi sono ritirato tanti anni fa qui lontano da tutti per vivere\n\nancora di più a contatto con loro!");
            Console.Write("Vorrai perdonarmi ma ultimamente la mia vista è calata....\n\nperciò dimmi:");
            NextState();
        }

        void Name()
        {
            Console.Write("Come ti chiami?", true, "CharacterName" );
            Console.MessageComplete += () => Console.Write("Sei sicuro di chiamarti " + GameVariables.GetVariable("CharacterName") + "?");
            NextState();
        }

        void Sex()
        {
            Console.Write("Sei un maschio o una femmina?");
            Console.MessageComplete += () => ActiveSex(true);
            NextState();
        }

        void ActiveSex(bool isActive)
        {
            male.SetActive(isActive);
            female.SetActive(isActive);
            if (isActive)
            {
                SexAnim.SetBool("IsStatic", isActive);
                Kerneth.SetActive(false);
                KShadow.SetActive(false);
            }
        }

        void EndSex()
        {
            if (GameVariables.GetSwitch("IsChosen"))
            {
                Kerneth.SetActive(true);
                KShadow.SetActive(true);
                if (GameVariables.GetSwitch("IsMan"))
                    Console.Write("Sei un ragazzo");
                else
                    Console.Write("Sei una ragazza");
                
            }
        }

        #endregion Methods

    }
}



internal enum IntroState
{
    Beginning = 0,
    StartExplanation = 1,
    WaintingPresentation = 2,
    ThaumeyComesOut = 3,
    Explanation = 4,
    Name = 5,
    Sex = 6
    //ecc ecc ecc
}
