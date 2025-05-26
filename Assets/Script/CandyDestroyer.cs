using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CandyDestroyer : MonoBehaviour
{
    public CandyMananger manager;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;
    public GameObject floatingScorePrefab;
    public Transform uiCanvasTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Neu hung trung keo roi thi xoa keo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy" || other.gameObject.tag == "GoldCandy")
        {
            Destroy(other.gameObject);

            // Them keo vao neu keo roi
            manager.AddCandy(reward);
            manager.AddScore(reward);
            /*if (floatingScorePrefab != null && uiCanvasTransform != null)
            {
                GameObject score = Instantiate(floatingScorePrefab, uiCanvasTransform);
                score.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                score.GetComponent<FloatingScoreEffect>().SetText("+" + reward.ToString());
            }*/

            if (floatingScorePrefab != null)
            {
                GameObject scoreFX = Instantiate(floatingScorePrefab,
                    Camera.main.WorldToScreenPoint(other.transform.position),
                    Quaternion.identity,
                    GameObject.Find("Canvas").transform); // parent là Canvas

                TextMeshProUGUI text = scoreFX.GetComponent<TextMeshProUGUI>();
                text.SetText("+" + reward);
            }


            manager.DisplayCandyAmount();
            /*if (effectPrefab != null)
            {
                Instantiate(effectPrefab,   // copy
                    other.transform.position,   // dat vi tri
                    Quaternion.Euler(effectRotation));      //dat toc do quay
            }*/
        }
    }


}
