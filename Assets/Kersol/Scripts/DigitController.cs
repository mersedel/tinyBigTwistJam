using UnityEngine;
using TMPro;

public class DigitController : MonoBehaviour
{
    [SerializeField] private TMP_Text[] digits;

    public void setDigits(string[] texts)
    {
        for (int i = 0; i < 4; i++)  digits[i].text = texts[i];
    } 

    public void randomizeDigits()
    {
        for (int i = 0; i < 4; i++)  digits[i].text = Random.Range(0,2).ToString();
    }
}
