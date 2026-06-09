using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class DialogCharacter : MonoBehaviour
{
    public string name;
    [SerializeField] private RectTransform dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    private float animTimeSec = 0.7f;
    private float letterDelay = 0.05f, bitDelay = 0.02f;

    public void SayPhrase(string phrase, ref Action close) {
        StartCoroutine(SayPhraseIterator(phrase));
        close = () => closePanel();
    }

    private IEnumerator openPanel()
    {
        float timer = 0;
        while (timer < animTimeSec)
        {
            yield return null;
            timer += Time.deltaTime;
            
            dialogPanel.localScale = Mathf.Lerp(0, 1, timer) * Vector2.one;
        }
    }
    private IEnumerator closePanel()
    {
        float timer = 0;
        while (timer < animTimeSec)
        {
            yield return null;
            timer += Time.deltaTime;
            
            dialogPanel.localScale = Mathf.Lerp(0, 1, timer) * Vector2.one;
        }
    }
    private IEnumerator SayPhraseIterator(string phrase)
    {
        

        // clear
        dialogText.text = string.Empty;

        // panel animation
        yield return StartCoroutine(openPanel());

        // adding letters
        foreach (var letter in phrase)
        {
            yield return new WaitForSeconds (bitDelay);
            if (letter != ' ') dialogText.text += UnityEngine.Random.Range(0,2).ToString();
            else dialogText.text += '-';
        }

        // changing on normal letters
        var chars = dialogText.text.ToCharArray();
        for (int i = 0; i < phrase.Length; i ++)
        {
            yield return new WaitForSeconds (letterDelay);
            chars[i] = phrase[i];
            if (i < phrase.Length - 2) chars[i + 1] = '/';
            dialogText.text = new string(chars);
        }
    }
}
