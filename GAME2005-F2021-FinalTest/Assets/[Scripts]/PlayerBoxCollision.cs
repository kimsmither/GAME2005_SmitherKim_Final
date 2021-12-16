using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class PlayerBoxCollision : MonoBehaviour
{
    public List<CubeBehaviour> cubes = new List<CubeBehaviour>();

    // Update is called once per frame
    void Update()
    {
        void CheckCollision()
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                for (int j = i + 1; j < cubes.Count; j++)
                {
                    CubeBehaviour firstCube = cubes[i];
                    CubeBehaviour secondCube = cubes[j];
                    PlayerCubeCollision(firstCube, secondCube);
                }
            }
        }
    }

    void PlayerCubeCollision(CubeBehaviour a, CubeBehaviour b)
    {
        Vector3 halfSizeA = a.half;
        Vector3 halfSizeB = b.half;

        Vector3 displacement = b.transform.position - a.transform.position;

        float overlapX = (halfSizeA.x + halfSizeB.x - Mathf.Abs(displacement.x));
        float overlapY = (halfSizeA.y + halfSizeB.y - Mathf.Abs(displacement.y));
        float overlapZ = (halfSizeA.z + halfSizeB.z - Mathf.Abs(displacement.z));

        if (overlapX < 0 || overlapY < 0 || overlapZ <0)
        {
            return;
        }

        Vector3 normal;
        Vector3 mtv;

        if (overlapX <= overlapY && overlapX <= overlapZ) 
        {
            normal = new Vector3(Mathf.Sign(displacement.x), 0, 0);
            mtv = normal * -overlapX;
        }
        else if (overlapY <= overlapX && overlapY <= overlapZ)
        {
            normal = new Vector3(0, Mathf.Sign(displacement.y), 0);
            mtv = normal * -overlapY;
        }
        else
        {
            normal = new Vector3(0, 0, Mathf.Sign(displacement.z));
            mtv = normal * -overlapZ;
        }

        if (a.isPlayer && !b.isPlayer) //move b
        {
            b.transform.position -= mtv;
        }

        if (!a.isPlayer && b.isPlayer) //move a
        {
            a.transform.position += mtv;
        }
    }
}
