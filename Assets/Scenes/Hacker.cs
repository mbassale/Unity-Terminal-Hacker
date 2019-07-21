using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen { MainMenu, Password, Win };

    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    int level;
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library.");
        Terminal.WriteLine("Press 2 for the local police station.");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen ==  Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }
        else if (input == "exit")
        {
            Application.Quit();
        }
        else
        {
            Terminal.WriteLine("Please select a level");
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
  /////|
 ///// |
|~~~|  |
|===|  |
|j  |  |
| g |  |
|  s| /
|===|/");
                break;
            case 2:
                Terminal.WriteLine("Have a gun...");
                Terminal.WriteLine(@"
      __,_____
hjw  / __.==--
    /#(-'
    `-'
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter you password, hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
