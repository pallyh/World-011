using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject menuContent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = menuContent.activeInHierarchy ? 1.0f : 0.01f;
            menuContent.SetActive(!menuContent.activeInHierarchy);
            
        }
    }
}
