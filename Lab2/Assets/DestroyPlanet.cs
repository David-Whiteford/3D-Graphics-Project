using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlanet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "EnemyPlanet")
        {
            Destroy(collision.gameObject);
        }

    }
}
