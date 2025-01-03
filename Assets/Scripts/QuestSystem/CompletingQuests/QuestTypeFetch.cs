using UnityEngine;

public class QuestTypeFetch : MonoBehaviour
{
	[SerializeField] private bool isInRange;
	[SerializeField] private QuestData quest;
	[SerializeField] private QuestManager manager;
	private Item item;
	
	private void Start()
	{
		item = GetComponent<Item>();
		manager = FindFirstObjectByType<QuestManager>();
		
		SceneManagement.Instance.AddObjectToScene(gameObject, "BunkerOutside");
	}

	private void Update()
	{
		if (!isInRange || !Input.GetKeyDown(KeyCode.E)) 
			return;
		
		QuestManager.OnQuestAction.Invoke();
		SceneManagement.Instance.RemoveObjectFromScene(gameObject);
		Destroy(gameObject);
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Player")) 
			return;
		
		isInRange = true;
		manager.interactedItem = item;
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Player")) 
			return;
		
		isInRange = false;
		if (manager.interactedItem == item)
			manager.interactedItem = null;

	}
}
