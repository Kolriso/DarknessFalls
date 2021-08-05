using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Button))]
[RequireComponent(typeof (Image))]

public class CustomButtonShape : MonoBehaviour
{
    private Image buttonImage;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.alphaHitTestMinimumThreshold = 0.5f;
        button = GetComponent<Button>();
        button.targetGraphic = buttonImage;
    }
}
