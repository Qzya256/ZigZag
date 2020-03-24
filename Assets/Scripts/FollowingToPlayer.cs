using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingToPlayer : MonoBehaviour
{
    [SerializeField] private Transform FolowGameObject;
    [SerializeField] private Player PlayerScript;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * PlayerScript.Speed / Mathf.Sqrt(2) * Time.deltaTime, Space.Self);
    }
}
