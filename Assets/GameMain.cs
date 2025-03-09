using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created]
    public float NumberAllowed;
    public float CurrentNumber;
    public float Spawned;
    public float Round;
    public float timeleft;
    public TextMeshPro Timer;
    public GameObject PlayableDirectorTime2;
    public GameObject PlayableDirectorTime3;
    public GameObject PlayableDirectorTime4;
    public GameObject PlayableDirectorTime5;

    public GameObject Launcher1;
    public GameObject Launcher2;

    public GameObject DiedOBJ;
    public bool died;
    public GameObject DiedPanel;
    public float Alpha = 0;
    public GameObject CollectorSlot;
    public TextMeshProUGUI CollectText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentNumber < NumberAllowed)
        {
            timeleft -= Time.deltaTime;
            Timer.text = timeleft.ToString();
        }
        if (CurrentNumber >= NumberAllowed && Round == 1)
        {
            Launcher1.gameObject.SetActive(false);
            Launcher2.gameObject.SetActive(false);
            timeleft = 60;
            PlayableDirectorTime2.GetComponent<PlayableDirector>().Play();
            NumberAllowed = 20;
            CurrentNumber = 0;
            Spawned = 0;
            Timer.text = timeleft.ToString();
            Round += 1;
        }
        if (CurrentNumber >= NumberAllowed && Round == 2)
        {
            Launcher1.gameObject.SetActive(false);
            Launcher2.gameObject.SetActive(false);
            timeleft = 60;
            PlayableDirectorTime3.GetComponent<PlayableDirector>().Play();
            NumberAllowed = 20;
            CurrentNumber = 0;
            Spawned = 0;
            Timer.text = timeleft.ToString();
            Round += 1;
        }

        if (CurrentNumber >= NumberAllowed && Round == 3)
        {
            Launcher1.gameObject.SetActive(false);
            Launcher2.gameObject.SetActive(false);
            timeleft = 60;
            PlayableDirectorTime4.GetComponent<PlayableDirector>().Play();
            NumberAllowed = 10000000000000000;
            Launcher1.GetComponent<fire>().FireRate = 0.3f;
            Launcher2.GetComponent<fire>().FireRate = 0.35f;
            CurrentNumber = 0;
            Spawned = 0;
            Timer.text = timeleft.ToString();
            Round += 1;
        }
        if (timeleft <= 15 && Round == 4)
        {
            Launcher1.gameObject.SetActive(false);
            Launcher2.gameObject.SetActive(false);
            timeleft = 15;
            PlayableDirectorTime5.GetComponent<PlayableDirector>().Play();
            NumberAllowed = 1000000000000;
            CurrentNumber = 0;
            Spawned = 0;
            Timer.text = timeleft.ToString();
            Round += 1;
            this.enabled = false;
        }

        if (timeleft <= 0 && died == false)
        {
            timeleft = 0;
            Timer.text = timeleft.ToString();
            CollectorSlot.gameObject.SetActive(false);
            CollectText.gameObject.SetActive(false);
            DiedOBJ.GetComponent<PlayableDirector>().Play();
            died = true;
        }
        if (timeleft <= 0 && died == true && DiedOBJ.GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            Alpha += .004f;
            var Colornew = new Color(0, 0, 0, Alpha);
            DiedPanel.GetComponent<Image>().color = Colornew;
            if (Alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
            CollectorSlot.gameObject.SetActive(false);
            CollectText.gameObject.SetActive(false);
            DiedOBJ.GetComponent<PlayableDirector>().Play();
        }
    }
}
