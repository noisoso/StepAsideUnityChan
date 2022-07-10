using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject unitychan;
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    private void OnTriggerEnter(Collider des)
    {
        if (des.gameObject.tag == "CoinTag"|| (des.gameObject.tag == "CarTag" || des.gameObject.tag == "TrafficConeTag")||des.gameObject.tag =="sss")
        {
            Destroy(des.gameObject);
        }
    }

}
