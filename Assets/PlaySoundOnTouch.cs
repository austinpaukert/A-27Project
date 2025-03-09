using UnityEngine;

public class PlaySoundOnTouch : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Collider>().enabled = false;
            this.enabled = false;
        }
    }
}
