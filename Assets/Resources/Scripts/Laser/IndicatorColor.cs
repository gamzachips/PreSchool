using UnityEngine;

public class IndicatorColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float fadeInTime = 1f; // 인스펙터에서 설정할 시간
    public float fadeOutDelay = 1.2f; // 알파값 초기화 시간 (Fade In Time보다 조금 뒤로 설정해주시면 됩니다)
    private void OnEnable()
    {
        // 스프라이트 렌더러 지정되지 않았을 때 콘솔창에 오류가 발생하기 때문에 넣은 코드입니다.
        // 따로 인스펙터에 Sprite 렌더러 집어넣지 않아도 작동합니다!!
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            // 현재까지 진행된 시간 계산
            elapsedTime += Time.deltaTime;

            // 현재 알파 값 계산
            float currentAlpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);

            // 스프라이트 렌더러의 알파 값 설정
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }

        // 인스펙터에서 설정한 시간이 지나면 알파값 초기화
        yield return new WaitForSeconds(fadeOutDelay);

        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            // 현재까지 진행된 시간 계산
            elapsedTime += Time.deltaTime;

            // 현재 알파 값 계산
            float currentAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInTime);

            // 스프라이트 렌더러의 알파 값 설정
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }

        // 페이드 아웃이 끝나면 이 스크립트 비활성화
        enabled = false;
    }
}
