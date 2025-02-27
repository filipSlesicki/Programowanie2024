using System.Collections;
using UnityEngine;

public class DelayTest : MonoBehaviour
{
    public Transform cubeTransform;
    public Transform moveTarget;
    public MeshRenderer cubeRenderer;
    public float moveTime = 2;
    public float moveSpeed = 2;
    public float blinkWaitTime = 0.5f;
    private bool isMoving;
    private bool isBlinking;
    Coroutine blinkCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //StopCoroutine(blinkCoroutine);
            //blinkCoroutine = StartCoroutine(BlinkCube());
            StartCoroutine(MoveCubeToTarget(moveTarget.position));
        }
        if(!isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(MoveByVector(Vector3.up * moveSpeed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(MoveByVector(Vector3.down * moveSpeed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(MoveByVector(Vector3.left * moveSpeed));
            }
            if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine(MoveByVector(Vector3.right * moveSpeed));
            }
        }
    }

    private IEnumerator MoveCubeToTarget(Vector3 targetPosition)
    {
        Vector3 startPosition = cubeTransform.position;
        float progress = 0; // from 0 to 1

        while(progress < 1)
        {
            //cubeTransform.position = Vector3.MoveTowards(cubeTransform.position,
            //    moveTarget.position, moveSpeed * Time.deltaTime);
            // Move towards - Ruch z podan¹ prêdkoœæi¹, czas trwania zale¿y od dystansu

            progress += Time.deltaTime / moveTime;
            cubeTransform.position = Vector3.Lerp(startPosition,targetPosition, progress);
            // Lerp - ruch trwa podany czas, prêdkoœæ zale¿y od dystansu

            yield return null; // Czekaj 1 klatke
        }
    }

    private IEnumerator MoveByVector(Vector3 moveVector)
    {
        isMoving = true;
        Vector3 startPosition = cubeTransform.position;
        Vector3 targetPosition = startPosition + moveVector;
        float progress = 0; // from 0 to 1

        while (progress < 1)
        {
            progress += Time.deltaTime / moveTime;
            cubeTransform.position = Vector3.Lerp(startPosition, targetPosition, progress);
            yield return null;
        }

        isMoving = false;
    }

    private IEnumerator BlinkCube()
    {
        isBlinking = true;
        yield return new WaitForSeconds(blinkWaitTime);
        HideCube();
        yield return new WaitForSeconds(blinkWaitTime);
        ShowCube();
        yield return new WaitForSeconds(blinkWaitTime);
        HideCube();
        yield return new WaitForSeconds(blinkWaitTime);
        ShowCube();
        yield return new WaitForSeconds(blinkWaitTime);
        HideCube();
        yield return new WaitForSeconds(blinkWaitTime);
        ShowCube();
        isBlinking = false;
        blinkCoroutine = null;
    }

    private void HideCube()
    {
        cubeRenderer.enabled =false;
    }

    private void ShowCube()
    {
        cubeRenderer.enabled = true;
    }
}
