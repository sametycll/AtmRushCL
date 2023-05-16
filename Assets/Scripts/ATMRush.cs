using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ATMRush : MonoBehaviour
{
    public static ATMRush instance;
    public float movementDelay = 0.25f;

    public List<GameObject> cubes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

    public void StackCube(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cubes.Add(other);
        StartCoroutine(MakeObjectBigger());

    }

    private IEnumerator MakeObjectBigger()
    {
        for (int i = cubes.Count-1; i >0 ; i--)
        {
            int a =i;
            Vector3 scale = new Vector3(1,1,1);
            scale*=1.5f;
            cubes[a].transform.DOScale(scale,0.1f).OnComplete(() => cubes[a].transform.DOScale(new Vector3(1,1,1),0.1f));

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveListElements()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i-1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos,movementDelay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[0].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, 0.70f);
        }
    }


}
