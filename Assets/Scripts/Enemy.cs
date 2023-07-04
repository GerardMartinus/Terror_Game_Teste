using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float distance;
    float speed = 4f;
    float distancePlayer = 150;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        if(distancePlayer < distance){
            player.transform.position = new Vector3(0, 0, -205.5f);
        }

        FollowThePlayer();
    }

    void FollowThePlayer(){
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform);
    }
}
