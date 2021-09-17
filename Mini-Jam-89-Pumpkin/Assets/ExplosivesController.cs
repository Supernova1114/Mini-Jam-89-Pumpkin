using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivesController : MonoBehaviour
{
    [SerializeField]
    private float fuseTime = 0;
    [SerializeField]
    private float explosionRadius = 0;

    [SerializeField]
    private float damage = 0;

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
        //TBA play sound and particles for fuse

        yield return new WaitForSeconds(fuseTime);

        //TBA play explosion particles and sound

        Collider2D[] colliderList = Physics2D.OverlapCircleAll(transform.position, explosionRadius);


        for (int i=0; i<colliderList.Length; i++)
        {
            DamageHandler damageHandler = colliderList[i].gameObject.GetComponent<DamageHandler>();
            
            if (damageHandler != null)
            {
                //TBA slow down
                damageHandler.Hurt(damage);
            }
        }

        Destroy(gameObject, 0);

    }

}
