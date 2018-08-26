using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {
    public ParticleSystem a;
    public ParticleSystem b;
    public ParticleSystem c;
    public ParticleSystem d;
    public ParticleSystem e;
    public ParticleSystem f;
    public int s;
    public float speed;
    public float time;
    // Use this for initialization
    void Start () {
        play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void stop()
    {
        a.Stop();
        b.Stop();
        c.Stop();
        d.Stop();
        e.Stop();
        f.Stop();
    }
    public void play()
    {
        a.Play();
        b.Play();
        c.Play();
        d.Play();
        e.Play();
        f.Play();
    }
}
