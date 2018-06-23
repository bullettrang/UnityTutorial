using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hacker : MonoBehaviour {
    //variables for game state
    int level;
    enum Screen { MainMenu, Password, Win};

    Screen currentScreen;

    // Use this for initialization
    void Start () {
        print("Launching menu and displaying prompts");
        ShowMainMenu("Hello Vault Dweller");

    }
    
    //this should only decide who handles user input itself, not actually do it
    void OnUserInput(string input)
    {
        
        if (input == "menu")//we always have the option to go back to menu
        {
            ShowMainMenu("Hello Vault Dweller");
        }//if you're in the main menu, run the main menu
        else if (currentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }
    
    void RunMainMenu(string input)
    {
         if (input == "1")
        {
            print("You chose Grandma's computer");
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            print("You chose Police Station");
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            print("You chose National Security Agency");
            level = 3;
            StartGame();
            
        }
        else
        {
            Terminal.WriteLine("Invalid command");
        }
    }

     void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
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

