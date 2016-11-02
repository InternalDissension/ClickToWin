using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    Canvas canvas;
    public GameObject mainMenu;
    public GameObject gameMenu;

    RectTransform canvasSize;
    Text Title;
    Image background;

    private static bool menuRunning = true;
    private static bool endGame = false;

    public void Start()
    {
        canvasSize = GetComponent<RectTransform>();
        Title = GetComponentInChildren<Text>();
        background = GetComponentInChildren<Image>();

        setImageSize();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mainMenu.activeSelf && !gameMenu.activeSelf)
                showGameMenu();

            else if (gameMenu.activeSelf)
                hideGameMenu();
        }
    }

    private void setImageSize()
    {
        background.rectTransform.sizeDelta = canvasSize.rect.size;
    }

    private void setTitleSize()
    {

    }

    public void showGameMenu()
    {
        gameMenu.SetActive(true);
        menuRunning = true;

    }

    public void hideGameMenu()
    {
        gameMenu.SetActive(false);
        menuRunning = false;
    }

    public void showMainMenu()
    {
        hideGameMenu();
        mainMenu.SetActive(true);
        menuRunning = true;
    }

    public void hideMainMenu()
    {
        mainMenu.SetActive(false);
        menuRunning = false;
    }

    public void stopApplication()
    {
        Application.Quit();
    }

    public void stopGame()
    {
        endGame = true;
    }

    //returns true if a menu is currently shown
    public static bool getMenuState()
    {
        return menuRunning;
    }

    public static bool getGameState()
    {
        return endGame;
    }

    public static void refreshGameState()
    {
        endGame = false;
    }
}
