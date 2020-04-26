using UnityEngine;
using UnityEngine.SceneManagement;

public class Options
{
    public static float AsteroidDespawnDistance = 45f;
    public static bool AsteroidShadows = false;
    public static bool ParticleSystems = true;
    public static bool ObjectShadows = true;
    public static bool Lights = true;
    public static bool ShowFPS = false;

    public static void load()
    {
        OptionsData data = OptionsSave.load();
        AsteroidDespawnDistance = data.asteroidDespawnDistance;
        AsteroidShadows = data.asteroidShadows;
        ParticleSystems = data.particleSystems;
        ObjectShadows = data.objectShadows;
        Lights = data.lights;
        ShowFPS = data.showFPS;
    }

    public static void save()
    {
        OptionsSave.save();
    }
}
