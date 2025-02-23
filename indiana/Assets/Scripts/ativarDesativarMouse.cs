using UnityEngine;
using UnityEngine.EventSystems;
public class ativarDesativarMouse : MonoBehaviour
{
    public Texture2D customCursor; // Arraste sua textura de cursor personalizada aqui
    public Vector2 hotspot = Vector2.zero; // Ponto de clique do cursor (ajuste se necessário)
    public CursorMode cursorMode = CursorMode.Auto;

    // Chame este método quando o ponteiro entrar (enter) no botão
    public void OnCursorEnter()
    {
        Cursor.SetCursor(customCursor, hotspot, cursorMode);
    }

    // Chame este método quando o ponteiro sair (exit) do botão
    public void OnCursorExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
