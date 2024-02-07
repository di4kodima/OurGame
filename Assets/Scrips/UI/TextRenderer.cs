using UnityEngine;
using UnityEngine.UI;

public class TextRenderer : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void updateText(string value) {
        if (text == null) return;
        text.text = value;
    }
}
