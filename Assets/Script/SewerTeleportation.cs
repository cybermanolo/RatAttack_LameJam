using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerTeleportation : MonoBehaviour
{
    public Transform listTp;
    public List<Transform> tpTarget = new List<Transform>();
    public int targetID;

    private int maxRange = 0;
    [SerializeField] AudioClip _woosh;
    [SerializeField] AudioSource _audioSource;

    public GameObject _vfx;
    public Animator _vfxAnimator;

    void Start()
    {

        
        foreach(Transform child in listTp)
        {
    
            tpTarget.Add(child);
            maxRange++;
        }

        targetID = Random.Range(0, maxRange);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>())
        {
            targetID = Random.Range(0, maxRange);
            tpTarget[targetID].GetComponent<CircleCollider2D>().enabled = false;
            Player.Instance.transform.position = tpTarget[targetID].transform.position;
            StartCoroutine(Countdown(2, targetID));
            _audioSource.PlayOneShot(_woosh);
            SpawnVFX();
        }
            

    }



    IEnumerator Countdown(int seconds, int target)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        tpTarget[target].GetComponent<CircleCollider2D>().enabled = true;

    }

    void SpawnVFX()
    {

        GameObject newObject = Instantiate(_vfx, tpTarget[targetID].transform.position, transform.rotation);
        //float length = _vfxAnimator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(newObject, 2f);

    }
}
