using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] TouchDetection touchDetection;

    public float speed = 5f;

    [SerializeField] Slider speedSlider;
    void Start()
    {
        StartCoroutine(MoveCharacter());
        OnSliderValueChanged();
    }

    IEnumerator MoveCharacter()
    {
        while (true)
        {
            while (touchDetection.GetQueueCount() > 0)
            {
                Vector3 targetPosition = touchDetection.DequeuePosition();
                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    yield return null;
                }
                yield return null;
            }
            yield return null;
        }
    }

    public void OnSliderValueChanged()
    {
        speed = speedSlider.value * 5;
    }
}
