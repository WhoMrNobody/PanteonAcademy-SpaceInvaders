using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationOver : MonoBehaviour
{
    [SerializeField] float _delay;

    void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay);
    }
}
