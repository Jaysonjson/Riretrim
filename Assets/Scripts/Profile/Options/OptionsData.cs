using System;

[System.Serializable]
public class OptionsData
{
    public float asteroid_despawn_distance;
    public bool asteroid_shadows;
    public bool particle_systems;
    public OptionsData()
    {
        asteroid_despawn_distance = Options.asteroid_despawn_distance;
        asteroid_shadows = Options.asteroid_shadows;
        particle_systems = Options.particle_systems;
    }
}