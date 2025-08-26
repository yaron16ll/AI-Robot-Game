using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInfo : MonoBehaviour
{
    public TextMesh info;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        info.text = "HP:" + GetComponent<FieldOfView>().GetHp() + "\n"
            + "Ammo:" + GetComponent<FieldOfView>().GetAmmo();

    }
}
