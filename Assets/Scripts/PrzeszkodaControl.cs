using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrzeszkodaControl : MonoBehaviour
{

    public float scrollerSpeed = 5.0f;
    public GameObject[] Przeszkoda;
    public float frequency = 0.5f; // ilość przeszkód na sekundę
    private float counter = 0.0f;
    public Transform przeszkodaSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GererateRandoPrzeszkoda();
    }

    // Update is called once per frame
    void Update()
    {
        //Generowanie przeszkód
        if (counter <= 0.0f)
        {
            GererateRandoPrzeszkoda();
        } 
        else
        {
            counter -= Time.deltaTime * frequency;

        }



        //Scroling
        GameObject currentChild;
        for (int a0=0; a0<this.transform.childCount; a0++)
        {
            currentChild = this.transform.GetChild(a0).gameObject;
            ScrolerPrzeszkody(currentChild);
            if (currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }

        }

    }

    void ScrolerPrzeszkody(GameObject aktualnaPrzeszkoda)
    {
        aktualnaPrzeszkoda.transform.position -= Vector3.right * (scrollerSpeed * Time.deltaTime);
    }

    void GererateRandoPrzeszkoda ()
    {
        GameObject newPrzeszkoda =  Instantiate(Przeszkoda[Random.Range(0, Przeszkoda.Length)], przeszkodaSpawnPoint.position, Quaternion.identity) as GameObject;
        newPrzeszkoda.transform.parent = this.transform;
        counter = 1.0f;
    }


}
