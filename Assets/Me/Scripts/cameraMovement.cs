using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Transform tr;
    public Transform trP;
    public float lagBA;
    // Start is called before the first frame update
    void Start()
    {
        lagBA = trP.transform.position.x-tr.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        tr.transform.position = new Vector3(trP.transform.position.x-lagBA, tr.transform.position.y, -5);
    }
}
