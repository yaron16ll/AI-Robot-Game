using System.Collections;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private Vector3 newLocation;
    private LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Live", "Ammo", "RandomWalk", "Obstcales", "SafeZone");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

        if (CompareTag("Live") && (other.CompareTag("WhiteRobot") || other.CompareTag("BlackRobot")))
        {
            FieldOfView fieldOfView = other.GetComponent<FieldOfView>();

            if (fieldOfView.GetHp() > 10 && fieldOfView.GetHp() <= 15)
            {
                fieldOfView.SetHp(fieldOfView.GetHp() + 10);
            if (fieldOfView.GetHp() > 200)
            {
                fieldOfView.SetHp(200);
            }
                fieldOfView.SetIsLiveTaken(false);
                fieldOfView.isSafe = true;

                Relocate(0.04701f);                

            }
        }

        else if (CompareTag("Ammo") && (other.CompareTag("WhiteRobot") || other.CompareTag("BlackRobot")))
        {
            FieldOfView fieldOfView = other.GetComponent<FieldOfView>();

            if (fieldOfView.GetAmmo() > 0 && fieldOfView.GetAmmo() <=15)
            {
                fieldOfView.SetAmmo(fieldOfView.GetAmmo() + 10);  

                if (fieldOfView.GetAmmo() > 50)
                {
                    fieldOfView.SetAmmo(50);
                }          
                fieldOfView.SetIsAmmoTaken(false);
                fieldOfView.isSafe = true;

                Relocate(0.001f);
            }
        }
        else if (CompareTag("WhiteEquipmentCarry") && other.CompareTag("WhiteRobot"))
        {
            FieldOfView fieldOfView = other.GetComponent<FieldOfView>();
            if ( fieldOfView.GetHp() <= 10)
            {
                fieldOfView.SetHp(200);

            }
             if ( fieldOfView.GetAmmo() <= 0)
            {
                fieldOfView.SetAmmo(50);
            }
            fieldOfView.isSafe = true;

        }
        else if (CompareTag("BlackEquipmentCarry") && other.CompareTag("BlackRobot"))
        {
            FieldOfView fieldOfView = other.GetComponent<FieldOfView>();

            if (  fieldOfView.GetHp() <= 10)
            {
                fieldOfView.SetHp(200);

            }
             if ( fieldOfView.GetAmmo() <= 0)
            {
                fieldOfView.SetAmmo(50);
            }
            fieldOfView.isSafe = true;

        }
        else if (CompareTag("SafeZone") && (other.CompareTag("BlackRobot") || other.CompareTag("WhiteRobot")))
        {
            FieldOfView fieldOfView = other.GetComponent<FieldOfView>();
            fieldOfView.isSafe = true;
            fieldOfView.Walk();

        }
        else if (CompareTag("RandomWalk") && (other.CompareTag("WhiteRobot") || other.CompareTag("BlackRobot") || other.CompareTag("BlackEquipmentCarry") || other.CompareTag("WhiteEquipmentCarry")))
        {
            Relocate(2.64701f);
        }
    }


    void Relocate(float y)
    {
        bool isok = false;
        do
        {
            newLocation = new Vector3(Random.Range(-90f, 90f), y, Random.Range(-90f, 90f));
            if (!Physics.CheckSphere(newLocation, 4.5f, mask))
            {
                transform.position = newLocation;
                isok = true;
            }
        } while (!isok);
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red; // Set color of the sphere
    //    Gizmos.DrawWireSphere(newLocation, 4.5f); // Draw a wireframe sphere at the new location
    //}

    public IEnumerator reload(Collider other, float delay)
    {
        other.GetComponent<Unit>().speed = 0;
        other.GetComponent<Animator>().Play("Reload");
        yield return new WaitForSeconds(delay);

    }
}