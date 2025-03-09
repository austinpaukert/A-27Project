using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float wait = 0;
    public float FireRate = 1;
    public GameObject Crate;
    public float Force = 0;
    public GameMain GameMainScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wait += Time.deltaTime;
        if (wait >= FireRate && GameMainScript.Spawned < GameMainScript.NumberAllowed)
        {
            GameMainScript.Spawned += 1;
            var New =Instantiate(Crate);
            New.transform.position = transform.position;
            New.GetComponent<Rigidbody>().AddForce(Force, 0, 0, ForceMode.Impulse);
            New.transform.eulerAngles = new Vector3(0, 0, 0);
            wait = 0;
        }
    }
}
