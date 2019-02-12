using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMeteors : MonoBehaviour
{
    //If there is an ongoing meteor shower
    bool showering = false;
    //When to fire the next round of meteors
    private float nextFireTime = 0.0f;
    //How long to wait inbetween meteor firings in seconds
    public float waitTime = 1.0f;


    int MAX_METEORS_PER_FIRE;
    float MAX_SPHERE_SIZE;
    int METEOR_PROXIMITY;
    int NUMBER_OF_METEORS;
    int NUMBER_FIRED;

    // Use this for initialization
    void Start()
    {
        MAX_METEORS_PER_FIRE = 5;
        MAX_SPHERE_SIZE = 2.5f;
        METEOR_PROXIMITY = 1;
        NUMBER_OF_METEORS = 100;
        NUMBER_FIRED = 0;
    }

    void Update()
    {
        //If the user presses "m" the meteor shower will start
        if (Input.GetKey("t"))
        {
            showering = true;
        }
        if(Input.GetKey("joystick button 0")) {
            showering = true;
        }

        if (showering)
        {
            //If enough time has passed fire more meteors
            if(Time.time > nextFireTime)
            {
                nextFireTime = Time.time + waitTime;
                if (NUMBER_FIRED < NUMBER_OF_METEORS)
                {
                    GenerateMeteors(new Vector3(200, 200, 200));
                }
                else
                {
                    showering = false;
                    NUMBER_FIRED = 0;
                }
            }
            
        }
    }

    /// <summary>
    /// Generates an meteor in the area and aims it at the astronaut
    /// </summary>
    /// <param name="area">Area the meteor should spawn in</param>
    void GenerateMeteors(Vector3 area)
    {
        // Get a random number of meteors to fire
        var randomFireAmount = Random.Range(1, MAX_METEORS_PER_FIRE);

        // Fire meteors
        for(int i = 0; i < randomFireAmount; i++)
        {
            //Keep track how many meteors have been fired
            NUMBER_FIRED++;

            //Get a new position within +/- area so the meteors will come from above or below
            var posi = new Vector3(Random.Range(-1.0f, 1.0f) * area.x, Random.Range(-1.0f, 1.0f) * area.y, Random.Range(-1.0f, 1.0f) * area.z);

            // Variation in size of spheres
            var sphereSize = Random.Range(1, MAX_SPHERE_SIZE);

            //Create an meteors GameObject (sphere)
            GameObject meteors = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            //Instantiate it
            GameObject mtr = Instantiate(meteors, posi, meteors.transform.rotation);

            //Scale it 
            mtr.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);

            //Add collision
            mtr.AddComponent<ObjectCollision>();

            //Add a rigidbody on to the GameObject
            Rigidbody newMeteor = mtr.AddComponent<Rigidbody>();

            //Remove Gravity
            newMeteor.useGravity = false;

            //Find the astronaut
            GameObject astro = GameObject.FindGameObjectWithTag("Astronaut");

            //Make a direction from the new meteor to the astronaut
            var direction = (astro.transform.position - newMeteor.position);

            //Vary the x, y, and z so the meteor doesnt come directly at the astronaut, but still close
            direction.x = direction.x + Random.Range(-METEOR_PROXIMITY, METEOR_PROXIMITY);
            direction.y = direction.y + Random.Range(-METEOR_PROXIMITY, METEOR_PROXIMITY);
            direction.z = direction.z + Random.Range(-METEOR_PROXIMITY, METEOR_PROXIMITY);

            //Change velocity towards astronaut from meteor
            newMeteor.velocity = direction.normalized * Random.Range(30f, 75f);

            //Meteors should destroy themselves after 5 seconds
            Destroy(newMeteor, 7.5f);
            Destroy(mtr, 7.5f);
            Destroy(meteors, 7.5f);
        }
    }
}

