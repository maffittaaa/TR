using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private float maxHealth;
    [SerializeField] public float currentHealth;

    [Header("Damage")]
    [SerializeField] private Color bloodColor;
    [SerializeField] private Color mainColor;
    [SerializeField] private float damageEffectTimeSeconds = 0.3f;

    [Header("Collectibles Settings")]
    [SerializeField] private GameObject[] dropCollectibles;
    [SerializeField] private GameObject collectiblesHolder;
    [SerializeField][Range(0,1)] private float dropProbability = 0.5f;

    [Header("EnemyType")]
    [SerializeField] public EnemyType enemyType;
    [SerializeField] private Animator animator;

    private void Start()
    {
        collectiblesHolder = GameObject.FindGameObjectWithTag("CollectiblesHolder");
        gameObject.GetComponent<SpriteRenderer>().color = mainColor;
        currentHealth = maxHealth;
    }

    public void DealDamage(float damage)
    {
        if (animator != null)
        {
            animator.SetTrigger("isHurt");
        }
        currentHealth -= damage;
        StartCoroutine(DamageEffect());

        if (currentHealth <= 0)
        {
            Drop();
            Destroy(gameObject);
        }
    }

    private IEnumerator DamageEffect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = bloodColor;
        yield return new WaitForSeconds(damageEffectTimeSeconds);
        gameObject.GetComponent<SpriteRenderer>().color = mainColor;
    }

    private void Drop()
    {   
        float randomNum = Random.Range(0f, 1f);

        bool willDrop = dropProbability > randomNum;

        if (willDrop == true)
        {
            GameObject drop = Instantiate(dropCollectibles[Random.Range(0, dropCollectibles.Length)], collectiblesHolder.transform);
            drop.transform.position = transform.position;
            drop.GetComponent<ICollectible>().SetParent(CollectibleParent.Enemy);
        }
    }

    public virtual void TakeDamage(GameObject instigator, float damage, float knockback)
    {
        DealDamage(damage);
    }

    public virtual Color GetBloodColor()
    {
        return bloodColor;
    }
}
