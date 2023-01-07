using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public abstract void SetupAttack(LevelController controller);
    public abstract void StartAttack(LevelController controller);

    protected void HandleAttackEnd()
    {
        Destroy(gameObject);
    }
}
