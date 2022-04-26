using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    CharacterStats myStats;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 1f;
    public event System.Action OnAttack;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
;   }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            attackCooldown = 1f / attackSpeed;
            if (OnAttack != null)
            {
                OnAttack();
            }
        }
        

    }
    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
