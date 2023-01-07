using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Bounds LevelBounds;

    public bool DoRandom = false;

    public List<AttackWithDelay> attacks = new List<AttackWithDelay>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attacks());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Attacks()
    {
        Debug.Log("Starting attacks");
        int attackCounter = 0;
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(attacks[attackCounter].MinAttackDelay, attacks[attackCounter].MaxAttackDelay));
            Debug.Log("Attack " + attackCounter);
            EnemyAttack attack = Instantiate(attacks[attackCounter].AttackPrefab.GetComponent<EnemyAttack>());
            attack.SetupAttack(this);
            attack.StartAttack(this);

            attackCounter = (attackCounter + 1) % attacks.Count;
        }
    }

    private void OnDrawGizmosSelected()
    {
        DrawBounds(LevelBounds);    
    }

    void DrawBounds(Bounds b, float delay = 0)
    {
        // bottom
        var p1 = new Vector3(b.min.x, b.min.y, b.min.z);
        var p2 = new Vector3(b.max.x, b.min.y, b.min.z);
        var p3 = new Vector3(b.max.x, b.min.y, b.max.z);
        var p4 = new Vector3(b.min.x, b.min.y, b.max.z);

        Debug.DrawLine(p1, p2, Color.blue, delay);
        Debug.DrawLine(p2, p3, Color.red, delay);
        Debug.DrawLine(p3, p4, Color.yellow, delay);
        Debug.DrawLine(p4, p1, Color.magenta, delay);

        // top
        var p5 = new Vector3(b.min.x, b.max.y, b.min.z);
        var p6 = new Vector3(b.max.x, b.max.y, b.min.z);
        var p7 = new Vector3(b.max.x, b.max.y, b.max.z);
        var p8 = new Vector3(b.min.x, b.max.y, b.max.z);

        Debug.DrawLine(p5, p6, Color.blue, delay);
        Debug.DrawLine(p6, p7, Color.red, delay);
        Debug.DrawLine(p7, p8, Color.yellow, delay);
        Debug.DrawLine(p8, p5, Color.magenta, delay);

        // sides
        Debug.DrawLine(p1, p5, Color.white, delay);
        Debug.DrawLine(p2, p6, Color.gray, delay);
        Debug.DrawLine(p3, p7, Color.green, delay);
        Debug.DrawLine(p4, p8, Color.cyan, delay);
    }
}

[Serializable]
public struct AttackWithDelay
{
    public GameObject AttackPrefab;
    public float MinAttackDelay, MaxAttackDelay;
}