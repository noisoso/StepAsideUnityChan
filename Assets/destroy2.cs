using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy2 : MonoBehaviour
{
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform .position .z+6<this.unitychan .transform .position .z)
        {
            Destroy(this.gameObject);
        }
    }
}
