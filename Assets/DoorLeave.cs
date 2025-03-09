using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLeave : MonoBehaviour
{
    public string taskPrompt = "E - Leave"; // The prompt text to display
    public float interactionDistance = 3f;  // Distance for the player to be able to interact
    public TextMeshProUGUI promptText;  // UI Text component to show the prompt
    private bool isInProximity = false;
    private bool Interacted = false;
    void Update()
    {
        // Check the distance between the player
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= interactionDistance)
        {
            if (!isInProximity)
            {
                promptText.text = taskPrompt;
                isInProximity = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && !Interacted)
            {
                LEAVEDOOR();
            }
        }
        else
        {
            // Hide the prompt if the player moves away
            if (isInProximity)
            {
                promptText.text = "";
                isInProximity = false;
            }
        }
    }
    void LEAVEDOOR()
    {
        SceneManager.LoadScene("Ending");
    }
}
