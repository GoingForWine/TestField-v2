﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBulletScript : BulletScript
{
    public override void OnTriggerEnter(Collider collider)
    {
        //HITTING A CHARACTER
        if (collider.gameObject.GetComponent<BaseCharacterBehaviour>() && !collider.gameObject.GetComponent<BaseCharacterBehaviour>().respawned)
        {
            charScript = collider.gameObject.GetComponent<BaseCharacterBehaviour>();

            charScript.TakeDamage(damage);
            charScript.GetStopped(direction);

            collider.GetComponent<Rigidbody>().AddForce(new Vector3(pushBack.x * direction, pushBack.y, 0), ForceMode.Impulse);
            charScript.SetDisablingMovementTime(stopTargetDuration);
            RaiseSoundEvent(aud.clip);    //sound event
            OnImpact();
            return;
        }
    }

    public override void OnImpact()
    {
        Physics.IgnoreCollision(shooterCollider, GetComponent<Collider>(), false); //reset collision immunity       
    }
}

