using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GostMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpped;
        [SerializeField] private float frequency;
        [SerializeField] private float magnitude;

        //bool facingRight = true;
        Vector3 pos, localscale;

        private void Start()
        {
            pos = transform.position;
            localscale = transform.localScale;
        }

        private void Update()
        {
            checkWhereToFace();
        }

        
        private void checkWhereToFace()
        {
            //localscale.x *= -1;
            //transform.localScale = localscale;
            pos += transform.up * Time.deltaTime * moveSpped;
            transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }
}