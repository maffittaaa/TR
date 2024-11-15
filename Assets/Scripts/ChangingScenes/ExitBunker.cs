using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBunker : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			SceneManager.LoadScene("Bunker");
			collision.transform.position = new Vector3(-10, 2, 0);
			
		}
	}
}