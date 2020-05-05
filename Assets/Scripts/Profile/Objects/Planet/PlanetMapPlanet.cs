using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMapPlanet : MonoBehaviour
{
    public GameObject drillDummy;
    public void Start()
    {
        Planet planet = new Planet();
        gameObject.name = Registry.profile.Data.current_planet;
        planet.LoadUsingName(Registry.profile.Data.current_planet);
        for (int i = 0; i < planet.drillAmount; i++)
        {
            GameObject drill = GameObject.Instantiate(drillDummy, gameObject.transform, false);
            MiningDrill drillObject = new MiningDrill(drill, planet.pname);
            drillObject.index = References.drills.Count;
            drillObject.Generate();
        }

        if (planet.type == PlanetType.EXOTIC) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.exoticSprites[planet.spriteNumber]; }
        if (planet.type == PlanetType.EARTHLIKE) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.earthLikeSprites[planet.spriteNumber]; }
        if (planet.type == PlanetType.LAVA) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.lavaSprites[planet.spriteNumber]; }
        if (planet.type == PlanetType.ROCKY) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.rockySprites[planet.spriteNumber]; }
        if (planet.type == PlanetType.GAS) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.gasSprites[planet.spriteNumber]; }
        if (planet.type == PlanetType.ICE) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.iceSprites[planet.spriteNumber]; }
    }
}
