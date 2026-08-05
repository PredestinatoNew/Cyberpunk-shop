using UnityEngine;

public class CartSpawner : MonoBehaviour, IUISpawner
{
	public int CartCount;
	[SerializeField] private GameObject CartObject;

	[Header("Layout Settings")]
	[Tooltip("Distance between each cart")]
	[SerializeField] private float spacing = 2.0f;

	public void DrawUI()
	{
		// Clear existing children
		for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
		{
#if UNITY_EDITOR
			DestroyImmediate(gameObject.transform.GetChild(i).gameObject);
#else
            Destroy(gameObject.transform.GetChild(i).gameObject);
#endif
		}

		// Spawn new carts side-by-side to the left
		for (int i = 0; i < CartCount; i++)
		{
			GameObject newCart = Instantiate(CartObject, gameObject.transform);

			// Offset each cart along the negative X-axis (Vector3.left)
			newCart.transform.localPosition = Vector3.left * (i * spacing);
		}
	}

	void Start()
	{
		DrawUI();
	}
}