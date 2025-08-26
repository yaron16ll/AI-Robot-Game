using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmosBehaviour : MonoBehaviour
{
    public GameObject[] ammos;

    // Start is called before the first frame update
    void Start()
    {
        int locationNum;

        locationNum = Random.Range(0,3);

        Debug.Log("AMMOS-"+locationNum);

        switch (locationNum)
        {
            case 0:
                ammos[0].transform.localPosition = new Vector3(3.9f, -15.184f, 25f);
                ammos[1].transform.localPosition = new Vector3(-105.6f, -15.184f, -32.4f);
                ammos[2].transform.localPosition = new Vector3(36.31546f, -15.184f, 60.7f);
                ammos[3].transform.localPosition = new Vector3(-110.4f, -15.184f, 35.3f);
                ammos[4].transform.localPosition = new Vector3(-120.6f, -15.184f, -58.1f);
                break;

            case 1:
                ammos[0].transform.localPosition = new Vector3(3.9f, -15.184f, -59.3f);
                ammos[1].transform.localPosition = new Vector3(-132.3f, -15.184f, 31.3f);
                ammos[2].transform.localPosition = new Vector3(-108.7f, -15.184f, -29.1f);
                ammos[3].transform.localPosition = new Vector3(-63.3f, -15.184f, 64.1f);
                ammos[4].transform.localPosition = new Vector3(15.7f, -15.184f, -7.1f);
                break;

            case 2:
                ammos[0].transform.localPosition = new Vector3(3.9f, -15.184f, 23.3f);
                ammos[1].transform.localPosition = new Vector3(-70.8f, -15.184f, 76.8f);
                ammos[2].transform.localPosition = new Vector3(-27.8f, -15.184f, -48.1f);
                ammos[3].transform.localPosition = new Vector3(-131.1f, -15.184f, 64.1f);
                ammos[4].transform.localPosition = new Vector3(15.7f, -15.184f, 59.8f);
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
