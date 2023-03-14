using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float timeToDissapear = 1;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Package" && !hasPackage) {
            Destroy(other.gameObject, timeToDissapear);
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up");
        } else if (other.gameObject.tag == "Customer" && hasPackage) {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered");
        }
    }
}
