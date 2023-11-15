using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PassaDeFase : MonoBehaviour
{
	private Animator anim;
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			anim.SetTrigger("fim");
			SceneManager.LoadScene("Boss");
		}
	}
}
