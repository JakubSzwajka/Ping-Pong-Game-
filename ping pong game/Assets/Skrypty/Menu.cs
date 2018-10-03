using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Menu : MonoBehaviour
{
    public Canvas MenuPanel;
    public Canvas OptionsPanel;
    public Canvas SureIfExit;
    public Canvas SureIfMenu;
    public Canvas ControlCanvas; 

    public ScoreCounter ScoreCounterScript;

    private void Start()
    {
        SureIfExit.enabled = false;       // if exit the game canvas off
        OptionsPanel.enabled = false;     // option canvas off
        SureIfMenu.enabled = false;       // if back to menu canvas off
        ControlCanvas.enabled = false;    // control cansas off

        MenuPanel.enabled = true;         // menu canvas on

        Time.timeScale = 0;               // stop the time
    }
    void Update ()
    {
        // if you are in menu, escape button works like...
		if(Input.GetKeyDown(KeyCode.Escape) && MenuPanel.enabled == true && ControlCanvas.enabled == false)
        {
            // ... if are you sure you want to exit the game.
            ExitButtonMethode();
        }
        // if you are in options panel, escape button works like...
        else if(Input.GetKeyDown(KeyCode.Escape) && OptionsPanel.enabled == true && MenuPanel.enabled == false)
        {
            //  ...going back to menu.
            OptionsPanel.enabled = false;
            MenuPanel.enabled = true; 
        }
        // if you are in Game mode, escape button works like...
        else if(Input.GetKeyDown(KeyCode.Escape) && MenuPanel.enabled == false && OptionsPanel.enabled == false)
        {
            // ... if are you sure you want to go back to main menu.
           IfBackToMainMenu();
        }
        // if you are in Control menu, escape button works like...
        else if(Input.GetKeyDown(KeyCode.Escape)&& MenuPanel.enabled == true && ControlCanvas.enabled == true )
        {
            //... going back to menu.
            BackControl(); 
        }
    }
    public void PlayButtonMethode()     // PLAY BUTTON
    {
        MenuPanel.enabled = false;      // switch off menu Canvas 
        Cursor.visible = false;         // cursos will be invisible
        Time.timeScale = 1;             // time starts ! 
    }
    public void OptionButtonMethode()   // OPRION BUTTON
    {
        OptionsPanel.enabled = true;    // switch on OPTION Canvas
        MenuPanel.enabled = false;      // switch off MENU Canvas 
    }
    public void ExitButtonMethode()     // EXIT BUTTON
    {
        SureIfExit.enabled = true;      // sure if exit the game canvas on
    }
    public void OptionExitButton()      // OPTION EXIT BUTTON
    {
        OptionsPanel.enabled = false;   // option canvas off
        MenuPanel.enabled = true;       // menu canvas on
    }
    public void ExitForSureYES()        // TOTAL EXIT BUTTON
    {
        Debug.Log("EXIT ! ! ! ! ! ");   // to console.. just for checking in UNITY
        Application.Quit();             // close the app
    }

    public void ExitForSureNO()         // BACK FROM EXIT 
    {
        SureIfExit.enabled = false;     // sure if exit buttons canvas off
    }

    public void IfBackToMainMenu()      // FROM THE GAME - IF YOU WANT TO GO BACK TO MENU BY ESCAPE
    {
        SureIfMenu.enabled = true;      // sure if go back to menu canvas on
        Time.timeScale = 0;             // stop the time
        Cursor.visible = true;          // cursor visible
    }
    public void IfBackToMainMenuYES()   // BACK TO MENU BUTTON
    {
        SureIfMenu.enabled = false;                   // sure if go back to menu canvas off
        MenuPanel.enabled = true;                     // menu canvas on
        ScoreCounterScript.Winner.enabled = false;    // winner canvas off
        ScoreCounterScript.RightPlayerScore = 0;      // zero the points 
        ScoreCounterScript.LeftPlayerScore = 0;       // zero the points
    }
    public void IfBackToMainMenuNO()            // STAY IN GAME
    {
        SureIfMenu.enabled = false;             // if back to menu canvas off
        Time.timeScale = 1;                     // time starts 
        Cursor.visible = false;                 // cursor invisible
    }
    public void Control()                       // CONTROL BUTTON 
    {
        ControlCanvas.enabled = true;           // control canvas on
    }
    public void BackControl()                   // BACK FROM CONTROLL 
    {
        ControlCanvas.enabled = false;          // control canvas off
    }
}
