using UnityEngine;

public class ScrollText : MonoBehaviour
{
    [SerializeField] private float scrollX;
    [SerializeField] private float scrollY;
    private Renderer _texture;
    private void Start()
    {
        _texture = GetComponent<Renderer>();
    }

    void Update()
    {
        float offsetX = scrollX * Time.deltaTime;
        float offsetY = scrollY * Time.deltaTime;
        _texture.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
