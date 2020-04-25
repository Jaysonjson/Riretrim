using UnityEngine;
using UnityEngine.SceneManagement;

public class Options
{
    public static float asteroid_despawn_distance = 45f;
    public static int asteroid_max_spawn_amount = 750;
    public static bool asteroid_shadows;
    public static bool particle_systems = true;

    public static void load()
    {
        OptionsData data = OptionsSave.load();
        asteroid_despawn_distance = data.asteroid_despawn_distance;
        asteroid_shadows = data.asteroid_shadows;
        particle_systems = data.particle_systems;
        asteroid_max_spawn_amount = data.asteroid_max_spawn_amount;
    }

    public static void save()
    {
        OptionsSave.save();
    }
}
