using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    public CandyMananger manager;
    AudioSource shotSound;

    public GameObject goldEffectPrefab;

    private void Start()
    {
        shotSound = GetComponent<AudioSource>(); //cbi sd am thanh
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }
    void Shot()
    {
        if (manager.GetCandyAmount() <= 0)
        {
            return;
        }

        GameObject selected = SelectCandy();
        GameObject candy = Instantiate(selected, GetInstantiatePosition(), Quaternion.identity);
        Rigidbody rb = candy.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shotForce);
        rb.AddTorque(new Vector3(0, shotTorque, 0));

        if (selected.tag == "GoldCandy")
        {
            manager.AddCandy(5);
            manager.DisplayCandyAmount();

            if (goldEffectPrefab != null)
            {
                /*Debug.Log("Gold effect position: " + candy.transform.position);*/
                Instantiate(goldEffectPrefab, candy.transform.position, Quaternion.identity);
            }
        }

        manager.ConsumeCandy();
        manager.DisplayCandyAmount();
        shotSound.Play();
    }


    // Chon ngau nhien keo de ban ra
    GameObject SelectCandy()
    {
        int select = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[select];
    }
    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth/2);
        return transform.position + new Vector3(x, 0, 0);
    }
}
