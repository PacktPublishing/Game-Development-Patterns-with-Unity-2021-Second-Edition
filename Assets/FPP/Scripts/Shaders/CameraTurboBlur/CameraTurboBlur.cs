using UnityEngine;

[ExecuteInEditMode]
public class CameraTurboBlur : MonoBehaviour 
{
    public Material material;
    
    [Range(0f, 1f)]
    public float radius = 0.8f;
    [Range(0f, 1f)]
    public float softness = 0.5f;
    
    public Color color = new Color(1, 1, 1, 1);
    
    private static readonly int Color = Shader.PropertyToID("_Color");
    private static readonly int Radius = Shader.PropertyToID("_Radius");
    private static readonly int Softness = Shader.PropertyToID("_Softness");
    
    void OnRenderImage (RenderTexture source, RenderTexture destination) 
    {
        material.SetColor(Color, color);
        material.SetFloat(Radius, radius);
        material.SetFloat(Softness, softness);
        Graphics.Blit(source, destination, material);
    }
}