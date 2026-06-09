using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private DigitController digitController;
    void Awake()
    {
        digitController.randomizeDigits();
    }
}
