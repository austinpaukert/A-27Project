using TMPro;
using UnityEngine;

public class Place : MonoBehaviour
{
    public string taskPrompt = "E - Place"; // The prompt text to display
    public float interactionDistance = 3f;  // Distance for the player to be able to interact
    public TextMeshProUGUI promptText;  // UI Text component to show the prompt
    private bool isInProximity = false;
    public GameObject CrateCamera;
    public GameMain GameMainScript;
    void Update()
    {
        // Check the distance between the player
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= interactionDistance)
        {
            if (!isInProximity && CrateCamera.gameObject.active == true)
            {
                taskPrompt = "E - Place";
                promptText.text = taskPrompt;
                isInProximity = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && CrateCamera.gameObject.active == true)
            {
                Placedown();
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
    public void Placedown()
    {
        CrateCamera.gameObject.SetActive(false);
        promptText.text = "";
        taskPrompt = "";
        GameMainScript.CurrentNumber += 1;
    }
}