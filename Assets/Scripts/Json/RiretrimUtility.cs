using System;
using System.Linq;
public class RiretrimUtility
{
    public static Galaxy GetGalaxy(string name)
    {
        Galaxy galaxy = null;
        Registry.adventureMap.galaxies.TryGetValue(name, out galaxy);
        return galaxy;
    }

    public static Star GetStar(Galaxy galaxy, string name)
    {
        Star star = null;
        galaxy.Data.stars.TryGetValue(name, out star);
        return star;
    }

    public static Star GetStar(string galaxy, string star)
    {
        Star starObject = null;
        GetGalaxy(galaxy).Data.stars.TryGetValue(star, out starObject);
        return starObject;
    }

    public static Star GetStar(string name)
    {
        Star starObject = null;
        GetGalaxy(Registry.profile.Data.current_galaxy).Data.stars.TryGetValue(name, out starObject);
        return starObject;
    }

    public static Planet GetPlanet(Star star, string name)
    {
        Planet planet = null;
        star.Data.planets.TryGetValue(name, out planet);
        return planet;
    }

    public static Planet GetPlanet(string name)
    {
        Planet planet = null;
        GetStar(Registry.profile.Data.current_galaxy, Registry.profile.Data.current_solarsystem).Data.planets.TryGetValue(name, out planet);
        return planet;
    }

    public static int GetMoonAmountInStar(Star star)
    {
        int amount = 0;
        for (int i = 0; i < star.Data.planets.Count; i++)
        {
            Planet planet = star.Data.planets.ElementAt(i).Value;
            amount += planet.Data.moons.Count;
        }
        return amount;
    }

    public static bool Contains(Object[] array, Object obj) {
        if(array.Contains(obj)) {
            return true;
        }
        return false;
    }
}