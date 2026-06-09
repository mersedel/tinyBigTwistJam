using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        print("executing dialog");
        dialog.Execute(this);
        this.GetComponent<Collider>().enabled = false;
    }
}
