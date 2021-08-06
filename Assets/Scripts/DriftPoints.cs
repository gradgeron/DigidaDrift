using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftPoints : MonoBehaviour
{
    public static float driftPointHolder;
    public Text text;
    public static bool isShaking = false;
    public Animator anim;

    GameObject[] smokeParticles;

    GameObject smokeParticle1;
    GameObject smokeParticle2;
    GameObject smokeParticle3;
    GameObject smokeParticle4;

    public static bool spawnParticles = false;
    void Start()
    {
        
    }

    void Update()
    {
        smokeParticles = GameObject.FindGameObjectsWithTag("Smoke");
        

        foreach (GameObject smokeParticle in smokeParticles)
        {
            if (smokeParticle.transform.parent.gameObject.activeSelf)
            {
                if (smokeParticle1 == null)
                {
                    smokeParticle1 = smokeParticle;
                } else if (smokeParticle2 == null)
                {
                    smokeParticle2 = smokeParticle;
                } else if (smokeParticle3 == null)
                {
                    smokeParticle3 = smokeParticle;
                } else if (smokeParticle4 == null)
                {
                    smokeParticle4 = smokeParticle;
                }
            }
        }

        if (smokeParticle1 != null && smokeParticle1.transform.parent.gameObject.activeSelf == false)
        {
            smokeParticle1 = null;
        }

        if (smokeParticle2 != null && smokeParticle2.transform.parent.gameObject.activeSelf == false)
        {
            smokeParticle2 = null;
        }

        if (smokeParticle3 != null && smokeParticle3.transform.parent.gameObject.activeSelf == false)
        {
            smokeParticle3 = null;
        }

        if (smokeParticle4 != null && smokeParticle4.transform.parent.gameObject.activeSelf == false)
        {
            smokeParticle4 = null;
        }

        text.text = ((int)driftPointHolder).ToString();
        if (isShaking)
        {
            anim.SetBool("isShaking", true);
        } else
        {
            anim.SetBool("isShaking", false);
        }

        if (spawnParticles)
        {

            smokeParticle1.GetComponent<ParticleSystem>().emissionRate = 40;
            smokeParticle2.GetComponent<ParticleSystem>().emissionRate = 40;
            smokeParticle3.GetComponent<ParticleSystem>().emissionRate = 40;
            smokeParticle4.GetComponent<ParticleSystem>().emissionRate = 40;

            //smokeParticle1.GetComponent<ParticleSystem>().emissionRate = Mathf.Lerp(0, 40, .5f);
            //smokeParticle2.GetComponent<ParticleSystem>().emissionRate = Mathf.Lerp(0, 40, .5f);
        } else
        {
            smokeParticle1.GetComponent<ParticleSystem>().emissionRate = 0;
            smokeParticle2.GetComponent<ParticleSystem>().emissionRate = 0;
            smokeParticle3.GetComponent<ParticleSystem>().emissionRate = 0;
            smokeParticle4.GetComponent<ParticleSystem>().emissionRate = 0;
        }
    }
}
