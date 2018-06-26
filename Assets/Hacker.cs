using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hacker : MonoBehaviour {
    //variables for game state
    int level;
    enum Screen {MainMenu, Password, Win};

    Screen currentScreen;
    string password;
    const string menuHint = "(Type menu to return to menu any time, press 'escape button' to quit application)";
    const int requiredScore = 3;
    int userScore = 0;

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    //BEGINNING OF GAME CONFIG DATA
    string[] level1passwords = {
            "stitch",
            "cardigan",
            "cheese",
            "cookies",
            "baking",
            "dear",
            "casserole",
            "knitting",
            "rascal"
        };

    string[] level2passwords =
    {
        "force",
        "arrest",
        "organization",
        "homicide",
        "state",
        "robbery",
        "racketeer",
        "bootleg"
    };
    string[] level3passwords =
    {
        "algorithm",
        "computer",
        "surveillance",
        "information",
        "eavesdrop",
        "defense",
        "political",
        "communication",
        "intelligence",
        "internet",
        "whistleblower",
        "conspiracy"
    };
    //END OF GAME CONFIG DATA
    /*
     *
     * 
     * 
     * 
     * 
     * 
     *   
         */
   // Use this for initialization



   void Start () {
            print("Launching menu and displaying prompts");
       
            ShowMainMenu("Hello Vault Dweller");

    }
    void resetGame() {
        userScore = 0;
    }
    //this should only decide who handles user input itself, not actually do it
    void OnUserInput(string input)
    {
        if (input == "menu")//we always have the option to go back to menu
        {
            resetGame();
            ShowMainMenu("Hello Vault Dweller");
        }//if you're in the main menu, run the main menu
        else if (input == "exit") {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            //each difficulty has a password, so we need to check it
            CheckPassword(input);
        }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
        resetGame();
    }
    void DisplayUserScore() {
        Terminal.WriteLine("User Score: " + userScore+ " out of "+requiredScore);
    }

     void ShowLevelReward()
    {
        switch (level)
        {
            case 1: Terminal.WriteLine("Grandma gives you bacon");
                Terminal.WriteLine(@" 
          __      _.._
       .-'__`-._.'.--.'.__.,
      /--'  '-._.'    '-._./
     /__.--._.--._.'``-.__/
     '._.-'-._.-._.-''-..'                                                                                      
                    ");
                break;
            case 2: //Terminal.WriteLine("Take my gun");
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
Take my Gun
   ,-.______________,=========,
  [|  )_____________)#######((_
  '-._,__,__[JW]____\#########/
            \ (  )) )####O###(
             \ \___ /,.#######\
              `==== '' \#######\
                        )##O####|
                        )####__,`
");
                break;
            case 3: Terminal.WriteLine("Congrats! you went to jail");
                Terminal.WriteLine(@"
Congrats! you went to jail
     ||     ||<(.)>||<(.)>||     || 
     ||    _||     ||     ||_    || 
     ||   (__D     ||     C__)   || 
     ||   (__D     ||     C__)   ||
     ||   (__D     ||     C__)   ||
     ||   (__D     ||     C__)   ||
     ||     ||     ||     ||     ||
  ================================
");
                break;
            default:
                break;

        }
    }

    void CheckPassword(string input)
    {   //if user input is CORRECT
         if (input == password)
         {
            //if user is right, increment total pts
            userScore++;
            //check if user has enough total pts
            if (userScore == requiredScore) {
                DisplayWinScreen();
            }
            else
            {
                StartLevel();
            }

        }//if user input is INCORRECT
        else
        {
            //StartGame();
            Terminal.ClearScreen();
            DisplayUserScore();
            Terminal.WriteLine("Enter a password, hint: " + password.Anagram());
        }
    }
    //gets random password index
    int getRandomPassword(int level)
    {

        System.Random rnd = new System.Random();
        if (level == 1)
        {
            return rnd.Next(0, level1passwords.Length);
        }
        else if (level == 2)
        {
            return rnd.Next(0, level2passwords.Length);
        }
        else 
        {
            return rnd.Next(0, level3passwords.Length);
        }
        

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = ( input == "1" || input == "2" || input =="3");

        if (isValidLevelNumber)
        {
            //change string input to int
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid command");
        }
    }
    //changes currentScreen
     void StartGame()
    {
        //change the screen
        currentScreen = Screen.Password;
        StartLevel();
    }
    void StartLevel() {
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        DisplayUserScore();
        switch (level)
        {
            case 1:    
                Terminal.WriteLine("You chose Grandma's Computer");
                Terminal.WriteLine("Enter Password below");
                password = level1passwords[getRandomPassword(level)];
                break;
            case 2:
                Terminal.WriteLine("You chose Police Station");
                Terminal.WriteLine("Enter Password below");
                password = level2passwords[getRandomPassword(level)];
                break;
            case 3:
                Terminal.WriteLine("You chose NSA");
                Terminal.WriteLine("Enter Password below");
                password = level3passwords[getRandomPassword(level)];
                break;
            default:
                Debug.LogError("I don't know this level");
                break;
        }
        Terminal.WriteLine("Enter a password, hint: " + password.Anagram());

    }
    //showMainMenu DECLARATION
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Select a location to hack into: ");
        Terminal.WriteLine("Press 1 for Grandma's House");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for National Security Agency");
        Terminal.WriteLine("Enter your selection below:");
    }
}

