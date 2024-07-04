using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotHandler : MonoBehaviour
{
    public Camera screenshotCamera;
    public Image displayImage;

    void Start()
    {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("ScreenshotCamera");
        if (cameraObject != null)
        {
            screenshotCamera = cameraObject.GetComponent<Camera>();
        }
        else
        {
            Debug.LogError("No camera with tag 'ScreenshotCamera' found.");
            screenshotCamera = Camera.main;  // Fallback to the main camera if no tagged camera is found.
        }
    }

    private IEnumerator FindImageComponent()
    {
        yield return null; // Ждем кадр для загрузки всех элементов

        GameObject imageObject = GameObject.FindGameObjectWithTag("MyImageTag");
        if (imageObject != null)
        {
            displayImage = imageObject.GetComponent<Image>();
        }
        else
        {
            Debug.LogError("No object with tag 'MyImageTag' found.");
        }
    }

    public void SetCamera()
    {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("ScreenshotCamera");
        if (cameraObject != null)
        {
            screenshotCamera = cameraObject.GetComponent<Camera>();
        }
        else
        {
            Debug.LogError("No camera with tag 'ScreenshotCamera' found.");
            screenshotCamera = Camera.main;  // Fallback to the main camera if no tagged camera is found.
        }
    }

    public void StartCaptureScreenshot()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        // Дождитесь завершения поиска компонента изображения
        yield return StartCoroutine(FindImageComponent());

        // После того как FindImageComponent завершился, начните процесс создания скриншота
        yield return StartCoroutine(TakeScreenshotAndShow());
    }

    private IEnumerator TakeScreenshotAndShow()
    {
        // Подождите окончание рендеринга
        yield return new WaitForEndOfFrame();

        // Создайте текстуру для хранения скриншота
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture renderTex = RenderTexture.GetTemporary(Screen.width, Screen.height, 24);
        RenderTexture prev = screenshotCamera.targetTexture;

        // Сделайте скриншот
        screenshotCamera.targetTexture = renderTex;
        screenshotCamera.Render();

        RenderTexture.active = renderTex;
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Восстановите предыдущие настройки камеры
        screenshotCamera.targetTexture = prev;
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(renderTex);

        // Установите скриншот в UI Image
        displayImage.sprite = Sprite.Create(screenshot, new Rect(0.0f, 0.0f, screenshot.width, screenshot.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}