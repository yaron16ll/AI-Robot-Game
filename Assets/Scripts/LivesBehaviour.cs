using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBehaviour : MonoBehaviour
{
    public GameObject[] lives;

    // Start is called before the first frame update
    void Start()
    {
        int locationNum;
        locationNum = Random.Range(0, 3);
        Debug.Log("LIVES - " + locationNum);

        switch (locationNum)
        {
            case 0:
                lives[0].transform.localPosition = new Vector3(17.9f, -15.12101f, 91.1f);
                lives[1].transform.localPosition = new Vector3(34.9f, -15.12101f, -11.8f);
                lives[2].transform.localPosition = new Vector3(-107f, -15.12101f, -80.3f);
                lives[3].transform.localPosition = new Vector3(-94f, -15.12101f, 45.6f);
                lives[4].transform.localPosition = new Vector3(33.1f, -15.12101f, -55.5f);
                break;

            case 1:
                lives[0].transform.localPosition = new Vector3(13.3f, -15.12101f, 31.4f);
                lives[1].transform.localPosition = new Vector3(-95.7f, -15.12101f, 5.5f);
                lives[2].transform.localPosition = new Vector3(1.2f, -15.12101f, -72.1f);
                lives[3].transform.localPosition = new Vector3(-133.9f, -15.12101f, 45.6f);
                lives[4].transform.localPosition = new Vector3(-127.1f, -15.12101f, -75.3f);

                break;

            case 2:
                lives[0].transform.localPosition = new Vector3(-10f, -15.12101f, 62.9f);
                lives[1].transform.localPosition = new Vector3(-34.9f, -15.12101f, -79.9f);
                lives[2].transform.localPosition = new Vector3(-107f, -15.12101f, 93.1f);
                lives[3].transform.localPosition = new Vector3(-94f, -15.12101f, 45.6f);
                lives[4].transform.localPosition = new Vector3(22f, -15.12101f, 27.8f);
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
