using Cinemachine;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public string taskPrompt = "E - Pickup"; // The prompt text to display
    public float interactionDistance = 3f;  // Distance for the player to be able to interact
    public TextMeshProUGUI promptText;  // UI Text component to show the prompt
    private bool isInProximity = false;
    private bool Interacted = false;
    public GameObject CrateCamera;

    void Update()
    {
        // Check the distance between the player
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= interactionDistance)
        {
            if (!isInProximity && CrateCamera.gameObject.active == false)
            {
                promptText.text = taskPrompt;
                isInProximity = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && !Interacted && CrateCamera.gameObject.active == false)
            {
                PickUp();
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
    void PickUp()
    {
        if (CrateCamera.gameObject.active == false)
        {
            CrateCamera.gameObject.SetActive(true);
            Destroy(gameObject);
            Interacted = true;
            promptText.text = "";
            taskPrompt = "";
        }

    }
}
