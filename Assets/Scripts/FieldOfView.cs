using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{

    public int hp;
    public int ammo;
    public List<GameObject> lives = new List<GameObject>();
    public List<GameObject> ammos = new List<GameObject>();
    public List<GameObject> safeZones = new List<GameObject>();
    public GameObject victoryMessage;

    public GameObject randomWalkTarget;

    public GameObject equipmentCarry;

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public Animator animator;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool isShooting;
    public bool isSafe;
    public float currentDistance;
    public bool isAmmoTaken;
    public bool isLiveTaken;
    private static bool isCarefulTaken = false;
    public CharacterTypes characterType;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
        SetHp(200);
        SetAmmo(50);
        characterType = CharacterManager.ChooseCharacter(this.tag);
        isSafe = true;
        isAmmoTaken = false;
        isLiveTaken = false;
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
            SetIsAmmoTaken(false);
            SetIsLiveTaken(false);
            if (IsDie())
            {
                Die();
                break;
            }
            else if (GetAmmo() > 0 && GetAmmo() <= 15 && isSafe && isShooting == false && !isAmmoTaken)
            {
                TakeAmmo();

            }
            else if (hp > 10 && hp <= 15 && isSafe && isShooting == false && !isLiveTaken)
            {

                TakeLive();

            }
            else if (GetAmmo() <= 0)
            {
                GoToEquipmentCarry();
            }
            else if (hp <= 10)
            {
                GoToEquipmentCarry();
            }
            //In Battle:
            else if (visibleTargets.Count != 0)
            {
                foreach (Transform visibleTarget in visibleTargets)
                {
                    if (IsDie())
                    {

                        isShooting = false;
                        break;
                    }
                    else if (visibleTarget.GetComponent<FieldOfView>().IsDie())
                    {
                        visibleTarget.GetComponent<Unit>().speed = 0;
                        Init();

                    }
                    else if (visibleTargets.Count == 0)
                    {
                        Init();
                    }
                    else
                    {
                        Shoot(visibleTarget);
                    }
                }

            }
            else
            {
                if (visibleTargets.Count == 0 && isSafe)
                {
                    Walk();
                }
                else if (visibleTargets.Count == 0 && !isSafe)
                {

                    RunToSafeZone();
                }

            }

        }
    }

    private void Init()
    {
        isShooting = false;
        isSafe = true;
        SetIsAmmoTaken(true);
        SetIsLiveTaken(true);

    }


    public void Walk()
    {
        isShooting = false;

        animator.SetInteger("State", 1);
        GetComponent<Unit>().speed = 2;
        GetComponent<Unit>().target = randomWalkTarget.transform;

    }


    private void Shoot(Transform visibleTarget)
    {
        if (GetAmmo() > 0)
        {
            isShooting = true;
            isSafe = true;
            currentDistance = Vector3.Distance(visibleTarget.transform.position, transform.position);
            GetComponent<Unit>().speed = 0;
            transform.rotation = Quaternion.LookRotation(visibleTarget.position - transform.position);
            GetComponent<PlayerWeapon>().Fire();
            SetAmmo(GetAmmo() - 1);
            visibleTarget.GetComponent<FieldOfView>().isSafe = false;
            CheckCharacter(visibleTarget);

        }
    }


    private void CheckCharacter(Transform visibleTarget)
    {
        if (characterType == CharacterTypes.Aggressive)
        {
            CheckAttackDistance(visibleTarget, 15, 10, 5, 1);
        }
        else
        {
            CheckAttackDistance(visibleTarget, 10, 5, 3, 1);
        }
    }


    private void CheckAttackDistance(Transform visibleTarget, int num1, int num2, int num3, int num4)
    {
        if (GetCurrentDistance() <= 5 && GetCurrentDistance() >= 0)
        {
            visibleTarget.GetComponent<FieldOfView>().SetHp(visibleTarget.GetComponent<FieldOfView>().GetHp() - num1);

        }
        else if (GetCurrentDistance() <= 10 && GetCurrentDistance() >= 6)
        {
            visibleTarget.GetComponent<FieldOfView>().SetHp(visibleTarget.GetComponent<FieldOfView>().GetHp() - num2);

        }
        else if (GetCurrentDistance() <= 15 && GetCurrentDistance() >= 11)
        {
            visibleTarget.GetComponent<FieldOfView>().SetHp(visibleTarget.GetComponent<FieldOfView>().GetHp() - num3);

        }
        else if (GetCurrentDistance() <= 21 && GetCurrentDistance() >= 16)
        {
            visibleTarget.GetComponent<FieldOfView>().SetHp(visibleTarget.GetComponent<FieldOfView>().GetHp() - num4);

        }
        else
        {
            visibleTarget.GetComponent<FieldOfView>().SetHp(visibleTarget.GetComponent<FieldOfView>().GetHp() - num3);

        }
    }


    private void GoToEquipmentCarry()
    {
        
        animator.SetInteger("State", 0);
        GetComponent<Unit>().speed = 5;
        GetComponent<Unit>().target = equipmentCarry.transform;
    }


    private void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);

                }


            }
        }

    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


    private void Die()
    {
        animator.SetInteger("State", 7);
        Destroy(this.randomWalkTarget);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero; // Stop any movement
            rb.angularVelocity = Vector3.zero; // Stop rotation
            rb.useGravity = false; 
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }

        // Disable all colliders (NPC is not tangible)
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = false;
            Debug.Log("Disabled collider: " + col.name);
        }
       


        GetComponent<RobotInfo>().info.gameObject.SetActive(false);
        GetComponent<Unit>().speed = 0;


        if (CompareTag("WhiteRobot"))
        {
            VictoryManager.IncrementWhiteRobot(victoryMessage);
        }
        else
        {
            VictoryManager.IncrementBlackRobot(victoryMessage);
        }

    }


    public bool IsDie()
    {
        if (hp <= 0)
            return true;
        return false;

    }


    public void TakeAmmo()
    {
       
        animator.SetInteger("State", 0);
        GetComponent<Unit>().speed = 5;
        ammos.Sort(SortByDis);
        GetComponent<Unit>().target = ammos[0].transform;
    }


    public void TakeLive()
    {
       
        animator.SetInteger("State", 0);
        GetComponent<Unit>().speed = 5;
        lives.Sort(SortByDis);
        GetComponent<Unit>().target = lives[0].transform;

    }


    public void RunToSafeZone()
    {
        animator.SetInteger("State", 0);
        GetComponent<Unit>().speed = 5;
        GetComponent<FieldOfView>().safeZones.Sort(SortByDis);
        GetComponent<Unit>().target = GetComponent<FieldOfView>().safeZones[0].transform;
    }


    public int SortByDis(GameObject safeZone1, GameObject safeZone2)
    {
        float num1 = Vector3.Distance(transform.position, safeZone1.transform.position);
        float num2 = Vector3.Distance(transform.position, safeZone2.transform.position);
        return num1.CompareTo(num2);
    }

    public int GetHp()
    {
        return hp;
    }

    public bool GetIsAmmoTaken()
    {
        return isAmmoTaken;
    }

    public void SetIsLiveTaken(bool isLiveTaken)
    {
        this.isLiveTaken = isLiveTaken;
    }

    public bool GetIsLiveTaken()
    {
        return isLiveTaken;
    }

    public void SetIsAmmoTaken(bool isAmmoTaken)
    {
        this.isAmmoTaken = isAmmoTaken;
    }

    public int GetAmmo()
    {
        return ammo;
    }

    public float GetCurrentDistance()
    {
        return currentDistance;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public void SetAmmo(int ammo)
    {
        this.ammo = ammo;
    }

}
