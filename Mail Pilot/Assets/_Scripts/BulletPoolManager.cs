using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton


[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    static BulletPoolManager instance;

    public GameObject bullet;
    public GameObject thisBullet;

    //TODO: create a structure to contain a collection of bullets
    public GameObject[] bullets = new GameObject[50];
    

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<bullets.Length; i++)
        {
            bullets[i] = Instantiate(bullet, Vector3.zero, Quaternion.identity);
            bullets[i].SetActive(false);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static BulletPoolManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject obj = new GameObject();
                instance = obj.AddComponent<BulletPoolManager>();
            }
            return instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(int bulletIteration)
    {
        bullets[bulletIteration].SetActive(true);
        return bullets[bulletIteration];
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
