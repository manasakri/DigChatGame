using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CategoryHighlighter : MonoBehaviour
{
    public Color darkRedColor;
    public Color darkBlueColor;
    public Color darkGreenColor;
    public Color grayColor;
    public Color clearColor;
    public Color neonGreen;
    public Color neonRed;
    public Color neonBlue;
    
    public Image triangle1Image;
    public Image triangle2Image;
    public Image triangle3Image;
    public Image triangle1backgroundImage;
    public Image triangle2backgroundImage;
    public Image triangle3backgroundImage;

    public Image hexagonImage;

    void Start()
    {
        StartCoroutine(SwitchColors());
    }

    IEnumerator SwitchColors()
    {
        Color lastColor = grayColor; // Initialize last color to gray
        Color lastColor1 = Color.clear;

        // Switch colors 2 times
        for (int i = 0; i < 2; i++)
        {
            // Highlight Triangle 1 in dark red and Triangles 2 and 3 in gray
            HighlightTriangle1();
            lastColor = darkRedColor;

            // Wait for 2 seconds
            yield return new WaitForSeconds(0.5f);

            // Highlight Triangle 2 in dark blue and Triangles 1 and 3 in gray
            HighlightTriangle2();
            lastColor = darkBlueColor;

            // Wait for 2 seconds
            yield return new WaitForSeconds(0.5f);

            // Highlight Triangle 3 in dark green and Triangles 1 and 2 in gray
            HighlightTriangle3();
            lastColor = darkGreenColor;

            // Wait for 2 seconds
            yield return new WaitForSeconds(0.5f);
            
            // Wait for 2 seconds
            yield return new WaitForSeconds(0.5f);
        }


        // Set the hexagon image color to the last selected color after the second iteration
        hexagonImage.color = lastColor;
    }

    void HighlightTriangle1()
    {
        triangle1Image.color = darkRedColor;
        triangle2Image.color = grayColor;
        triangle3Image.color = grayColor;
        triangle1backgroundImage.color = neonRed;
        triangle2backgroundImage.color = clearColor;
        triangle3backgroundImage.color = clearColor;
    }

    void HighlightTriangle2()
    {
        triangle1Image.color = grayColor;
        triangle2Image.color = darkBlueColor;
        triangle3Image.color = grayColor;
        triangle1backgroundImage.color = clearColor;
        triangle2backgroundImage.color = neonBlue;
        triangle3backgroundImage.color = clearColor; 
    }

    void HighlightTriangle3()
    {
        triangle1Image.color = grayColor;
        triangle2Image.color = grayColor;
        triangle3Image.color = darkGreenColor;
        triangle1backgroundImage.color = clearColor;
        triangle2backgroundImage.color = clearColor;
        triangle3backgroundImage.color = neonGreen;
    }
}
