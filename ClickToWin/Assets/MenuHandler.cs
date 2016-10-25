using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    Canvas canvas;
    RectTransform canvasSize;
    Text Title;
    Image background;

    public void Start()
    {
        canvas = GetComponent<Canvas>();
        canvasSize = GetComponent<RectTransform>();
        Title = GetComponentInChildren<Text>();
        background = GetComponentInChildren<Image>();

        setImageSize();
    }

    private void setImageSize()
    {
        background.rectTransform.sizeDelta = canvasSize.rect.size;
    }

    private void setTitleSize()
    {

    }

    public void hideCanvas()
    {
        canvas.enabled = false;
    }

    public void showCanvas()
    {
        canvas.enabled = true;
    }
}
