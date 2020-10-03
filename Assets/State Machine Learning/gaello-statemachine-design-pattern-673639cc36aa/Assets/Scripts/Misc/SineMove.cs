using UnityEngine;

/// <summary>
/// This component just moves sprite around to give it some life.
/// It uses Sine and Cosine to achieve that.
/// </summary>
public class SineMove : MonoBehaviour
{
    // Speed multiplication for vertical axis
    [SerializeField]
    private float verticalSpeedMulti = 2;

    // Speed multiplication for horizontal axis
    [SerializeField]
    private float horizontalSpeedMulti = 3;

    // Called every frame
    private void Update()
    {
        // Each frame local position is change to make UFO sprite move a little bit.
        transform.localPosition = new Vector3(Mathf.Sin(Time.time * horizontalSpeedMulti), Mathf.Cos(Time.time * verticalSpeedMulti), 0) * 0.25f;
    }
}