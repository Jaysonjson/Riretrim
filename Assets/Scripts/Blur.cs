using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class Blur : MonoBehaviour
{
    public Texture2D texture;
    public enum Type
    {
        RGBA32,
        RGB24
    }

    public Type type;
    void Start()
    {
        if (type == Type.RGBA32)
        {
            if (texture.isReadable == false) throw new UnityException("This texture is not accessible from CPU");
            if (texture.format != TextureFormat.RGBA32)
                throw new UnityException($"Wrong format. Texture is not {TextureFormat.RGBA32} but {texture.format}");
            var job = new LinearBlur.NativeRGBA32Job(
                texture.GetRawTextureData<LinearBlur.RGBA32>(),
                texture.width,
                texture.height,
                Mathf.Min(texture.width, texture.height) / 200,
                5
            );
            job.Schedule().Complete();
            job.Close();
            texture.Apply();
        }
        if (type == Type.RGB24)
        {
            if (texture.isReadable == false) throw new UnityException("This texture is not accessible from CPU");
            if (texture.format != TextureFormat.RGB24)
                throw new UnityException($"Wrong format. Texture is not {TextureFormat.RGB24} but {texture.format}");
            var job = new LinearBlur.NativeRGB24Job(
                texture.GetRawTextureData<LinearBlur.RGB24>(),
                texture.width,
                texture.height,
                Mathf.Min(texture.width, texture.height) / 200,
                5
            );
            job.Schedule().Complete();
            job.Close();
            texture.Apply();
        }
    }
    
}
