using UnityEngine;
using System.Collections;

public class SimpleFSM : FSM 
{
    public enum FSMState
    {
		Sleep,
		Awake,
        Attack
    }

    //Current state that the NPC is reaching
    public FSMState curState;

    //Speed of the tank
    private float curSpeed;

    //Tank Rotation Speed
    private float curRotSpeed;

    //Bullet
    public GameObject Bullet;

    //Whether the NPC is destroyed or not
    //private bool bDead;
    //private int health;

	public float awake = 50;
	public float attack = 40;

    //Initialize the Finite state machine for the NPC tank
	protected override void Initialize () 
    {
        curState = FSMState.Sleep;
        curSpeed = 5.0f;
        curRotSpeed = 1.0f;
        //bDead = false;
        elapsedTime = 0.0f;
        shootRate = 3.0f;
        //health = 100;

        //Get the list of points
        //pointList = GameObject.FindGameObjectsWithTag("WandarPoint");

        //Set Random destination point first
        //FindNextPoint();

        //Get the target enemy(Player)
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;

        if(!playerTransform)
            print("Player doesn't exist.. Please add one with Tag named 'Player'");

        //Get the turret of the tank
        turret = gameObject.transform; // 유령에게 turret은 따로 없고 자기 자신이므로 turret = gameObject.transform;을 해준다.
        bulletSpawnPoint = turret.GetChild(1).transform; // bulletSpawnPoint는 발사하는 지점이기 때문에 유령 하위에 만들어줘야 한다.

	}

    //Update each frame
    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.Sleep: UpdateSleepState(); break;
            case FSMState.Awake: UpdateAwakeState(); break;
            case FSMState.Attack: UpdateAttackState(); break;
        }

        //Update the time
        elapsedTime += Time.deltaTime;

        //Go to dead state is no health left
        //if (health <= 0)
            //curState = FSMState.Dead;
    }
	protected void UpdateSleepState(){ // 잠자는 상태 추가 : 플레이어와의 거리 계산만 하고 아무일 하지 않는다.

		if (Vector3.Distance (transform.position, playerTransform.position) <= awake) {
			curState = FSMState.Awake;
			destPos = transform.position;
		}
	}
	RaycastHit hit;
	protected void UpdateAwakeState(){ // UpdateAwakeState()에서는 제자리에서 돌면서 플레이어가 시야에 있는 지 확인한다.

		if (Vector3.Distance (transform.position, playerTransform.position) > awake) {
			curState = FSMState.Sleep;
		}else if (Vector3.Distance (transform.position, playerTransform.position) < attack) {
			curState = FSMState.Attack;
		}

		transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed); 
		/*
		if(Physics.Raycast (transform.position, playerTransform.position, out hit, ViewDistance)){
			if( hit.transform.tag == "Player")
				curState = FSMState.Attack;
		}*/
	}

    /// <summary>
    /// Patrol state
    /// </summary>
    /*protected void UpdatePatrolState()
    {
        //Find another random patrol point if the current point is reached
        if (Vector3.Distance(transform.position, destPos) <= 100.0f)
        {
            print("Reached to the destination point\ncalculating the next point");
            FindNextPoint();
        }
        //Check the distance with player tank
        //When the distance is near, transition to chase state
        else if (Vector3.Distance(transform.position, playerTransform.position) <= 300.0f)
        {
            print("Switch to Chase Position");
            curState = FSMState.Chase;
        }

        //Rotate to the target point
        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);  

        //Go Forward
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }*/

    /// <summary>
    /// Chase state
    /// </summary>
    /*protected void UpdateChaseState()
    {
        //Set the target position as the player position
        destPos = playerTransform.position;

        //Check the distance with player tank
        //When the distance is near, transition to attack state
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        if (dist <= 200.0f)
        {
            curState = FSMState.Attack;
        }
        //Go back to patrol is it become too far
        else if (dist >= 300.0f)
        {
            curState = FSMState.Patrol;
        }

        //Go Forward
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }*/

    /// <summary>
    /// Attack state
    /// </summary>
    protected void UpdateAttackState() // 가까워지면 UpdateAttackState() 상태가 되어 공격을 하기 시작한다

    {
        //Set the target position as the player position
        destPos = playerTransform.position;

        //Check the distance with the player tank
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        if (dist >= 10.0f && dist < awake)
        {
            //Rotate to the target point
            Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);  

            //Go Forward
            transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

            curState = FSMState.Attack;
        }
        //Transition to patrol is the tank become too far
        else if (dist >= awake)
        {
            curState = FSMState.Sleep;
        }        

        //Always Turn the turret towards the player
        Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
        turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed); 

        //Shoot the bullets
        ShootBullet();
    }

    /// <summary>
    /// Dead state
    /// </summary>
    /*protected void UpdateDeadState()
    {
        //Show the dead animation with some physics effects
        if (!bDead)
        {
            bDead = true;
            Explode();
        }
    }*/

    /// <summary>
    /// Shoot the bullet from the turret
    /// </summary>
    private void ShootBullet()
    {
        if (elapsedTime >= shootRate)
        {
            //Shoot the bullet
            Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            elapsedTime = 0.0f;
        }
    }

    /// <summary>
    /// Check the collision with the bullet
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        //Reduce health
        if (collision.gameObject.tag == "Bullet")
			collision.transform.position = GameObject.FindGameObjectWithTag ("Respawn").transform.position;
            //health -= collision.gameObject.GetComponent<Bullet>().damage;
    }   

    /// <summary>
    /// Find the next semi-random patrol point
    /// </summary>
    /*protected void FindNextPoint()
    {
        print("Finding next point");
        int rndIndex = Random.Range(0, pointList.Length);
        float rndRadius = 10.0f;
        
        Vector3 rndPosition = Vector3.zero;
        destPos = pointList[rndIndex].transform.position + rndPosition;

        //Check Range
        //Prevent to decide the random point as the same as before
        if (IsInCurrentRange(destPos))
        {
            rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
            destPos = pointList[rndIndex].transform.position + rndPosition;
        }
    }*/

    /// <summary>
    /// Check whether the next random position is the same as current tank position
    /// </summary>
    /// <param name="pos">position to check</param>
    /*protected bool IsInCurrentRange(Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - transform.position.x);
        float zPos = Mathf.Abs(pos.z - transform.position.z);

        if (xPos <= 50 && zPos <= 50)
            return true;

        return false;
    }*/

    /*protected void Explode()
    {
        float rndX = Random.Range(10.0f, 30.0f);
        float rndZ = Random.Range(10.0f, 30.0f);
        for (int i = 0; i < 3; i++)
        {
            rigidbody.AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
            rigidbody.velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
        }

        Destroy(gameObject, 1.5f);
    }*/

}
