using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


public enum Character
{
    char1,
    char2,
    char3
}
[Serializable]
public class Dialog
{

    private Action close;
    public List<CharDefinition> chars;

    public List<DialogLine> scenario;
    public void Execute(MonoBehaviour mono) => mono.StartCoroutine(DialogCoroutine());
    IEnumerator DialogCoroutine()
    {
        // FIXME fix duality of one who talks

        Movement.main.enabled = false;

        foreach (var line in scenario)
        {
            var character = chars.First(def => def.character == line.character).definition;
            CameraFollow.main.target = character.gameObject.transform;

            character.SayPhrase(line.phrase, ref close);
            // yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            // close();
            // Чекаємо поки E відпущена (на випадок якщо вже затиснута)
            yield return new WaitUntil(() => !Input.GetKey(KeyCode.E));
            // Тепер чекаємо справжнього натискання
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        
            close?.Invoke();
            close = null;
        }

        CameraFollow.main.target = Movement.main.transform;
        Movement.main.enabled = true;
    }
}
[System.Serializable]
public class DialogLine
{
    public Character character;
    [TextArea(2, 5)]
    public string phrase;
}

[System.Serializable]
public class CharDefinition
{
    public Character character;
    public DialogCharacter definition;
}
