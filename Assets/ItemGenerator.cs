using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private int startPos = 80;
    private int GoalPos = 360;
    private float posRange = 3.4f;
    private GameObject unitychan;
    List<int> kago = new List<int>();
    public bool isEnd = false;


    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

       
           
    }

    // Update is called once per frame
    void Update()
    {
        
        int num = Random.Range(1, 11);
        int ran = Random.Range(13, 16);

        if (!kago.Contains(1) && !(unitychan .GetComponent < UnityChanController >(). isEnd)&&this .unitychan .transform .position .z<300 )
            {
            StartCoroutine("Seigen");
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 40 + ran);
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + 40 + ran + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + 40 + ran + offsetZ);
                    }
                }
            }
        }
    }


    IEnumerator Seigen()
    {

        kago.Add(1);
        yield return new WaitForSeconds(0.8f);
        kago.Remove(1);

    }

}

