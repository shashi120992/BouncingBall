﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMovement : MonoBehaviour
    {

		public Transform target;

		void LateUpdate()
		{
			if (target.position.y > transform.position.y)
			{
				Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
				transform.position = newPos;
			}
		}
	}
}