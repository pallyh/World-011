using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            Debug.Log("Collected");
            _animator.SetBool("isCollected",true);
        }
    }

    public void Disappeared()
    {
        Debug.Log("Disapeared");
        this.transform.position += Vector3.forward * 10;
        _animator.SetBool("isCollected", false);
    }
}
