using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator _animator;
    const int minRand = 10;
    const int maxRand = 20;
    public int rand = 10;
    public const float minX = -115;
    public const float minY = -50;
    public const float maxX = 800;
    public const float maxY = 850;
    private Vector3 _minVector = new Vector3(minX,0,minY);
    private Vector3 _maxVector = new Vector3(maxX, 0, maxY);

  /*  public Vector3 maxTerr = Vector3.Angle();*/


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
/*        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");*/
        Randomise();
        Debug.Log("Disapeared");
        if (this.transform.position.x <= _minVector.x || this.transform.position.z <= _minVector.z
            || this.transform.position.x >= _maxVector.x || this.transform.position.z >= _maxVector.z
            )
        {
            this.transform.position -= Vector3.forward * rand;

        }
        else
        {
            this.transform.position += Vector3.forward * rand;

        }
/*        this.transform.position += Vector3.forward * rand;*/

        _animator.SetBool("isCollected", false);
    }

    public int Randomise()
    {
        rand = Random.Range(minRand, maxRand+1);
        return rand;
    }
}
