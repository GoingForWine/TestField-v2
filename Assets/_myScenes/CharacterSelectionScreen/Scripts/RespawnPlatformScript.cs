﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatformScript : MonoBehaviour
{
    public List<GameObject> collidedPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyPlatform());
    }

    public IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(3.0f);
        collidedPlayer[0].GetComponent<BaseCharacterBehaviour>().respawned = false;
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == collidedPlayer[0])
        {
            collidedPlayer[0].GetComponent<BaseCharacterBehaviour>().respawned = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collidedPlayer.Add(collision.gameObject);
        collidedPlayer[0].GetComponent<BaseCharacterBehaviour>().respawned = true;
    }
}
