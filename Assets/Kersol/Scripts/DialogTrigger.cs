using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag != "Player") return;

        print("executing dialog");
        dialog.Execute(this);
        this.GetComponent<Collider2D>().enabled = false;
    }
}
