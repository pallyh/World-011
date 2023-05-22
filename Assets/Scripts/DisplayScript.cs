using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private TMPro.TextMeshProUGUI textDistance;
    // Start is called before the first frame update
    const float neutralDistance = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(
            character.transform.position,
            coin.transform.position);

        textDistance.text = distance.ToString("0.0");
        textDistance.color = new Color(
            1/(1+distance), 
            0.2f, 
            distance/(1+distance)
        );
    }
}
