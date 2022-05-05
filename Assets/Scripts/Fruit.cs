using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    [SerializeField] private float explosionRadius = 5f;
    private GameManager myGM;
    public int scoreAmount = 3;

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(400, 600), transform.position, explosionRadius);
        }
        myGM.IncreaseScore(scoreAmount);
        myGM.PlayRandomeSliceSound();
        Destroy(inst, 5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
    if (!b) {
            return;
        }
        else
        {
            CreateSlicedFruit();
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        myGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    CreateSlicedFruit();

        //}

    
    }
}
