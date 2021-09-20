using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivesController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPoint;
    [SerializeField]
    private float fuseTime = 0;
    [SerializeField]
    private float explosionRadius = 0;

    [SerializeField]
    private float damage = 0;

    [SerializeField]
    private ParticleSystem fuseParticles;
    [SerializeField]
    private ParticleSystem explosionParticles;
    //Explosives that can be placed or thrown (?)

    private void Start()
    {
        Explode();
    }

    public void Explode()
    {
        StartCoroutine("StartFuse");
    }

    IEnumerator StartFuse()
    {
        fuseParticles.Play();

        yield return new WaitForSeconds(fuseTime);

        fuseParticles.Stop();
        
        //TBA play explosion particles and sound

        Collider2D[] colliderList = Physics2D.OverlapCircleAll(explosionPoint.transform.position, explosionRadius);


        for (int i=0; i<colliderList.Length; i++)
        {
            DamageHandler damageHandler = colliderList[i].gameObject.GetComponent<DamageHandler>();
            
            if (damageHandler != null)
            {
                //TBA slow down
                damageHandler.Hurt(damage);
            }
        }

        //Destroy(gameObject, 0);
        explosionPoint.transform.parent = null;
        explosionParticles.Play();

        Destroy(gameObject, 0);

    }

}
