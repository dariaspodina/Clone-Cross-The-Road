using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 startPlayerPos;
    GameGUI gui;

    ParticleSystem particle;

    void Start()
    {
        startPlayerPos = new Vector3(-6,1,-3);
        transform.position = startPlayerPos;
        gui = FindObjectOfType<GameGUI>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerDie();
        }
    }

    void OnBecameInvisible()
    {
        PlayerDie();
    }

    void PlayerDie()
    {
        StartCoroutine("Break");
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    //пауза для показа ParticleSystem
    private IEnumerator Break()
    {
        particle.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        gui.SpawnGameOverCanvas();
    }
}
