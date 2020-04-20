using UnityEngine;
using UnityEngine.SceneManagement;

public class Options
{
    public static float asteroid_despawn_distance = 45f;
    public static bool asteroid_shadows;
    public static bool particle_systems = true;

    public static void load()
    {
        OptionsData data = OptionsSave.load();
        asteroid_despawn_distance = data.asteroid_despawn_distance;
        asteroid_shadows = data.asteroid_shadows;
        particle_systems = data.particle_systems;
    }

    public static void save()
    {
        OptionsSave.save();
    }
}
