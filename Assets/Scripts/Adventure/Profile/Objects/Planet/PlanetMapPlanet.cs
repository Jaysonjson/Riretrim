using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMapPlanet : MonoBehaviour
{
    public GameObject drillDummy;
    Planet planet;
    public void Start()
    {
        gameObject.name = Registry.profile.Data.current_planet;
        planet = RiretrimUtility.GetPlanet(Registry.profile.Data.current_planet);
        //planet.Load(Registry.profile.Data.current_planet);
        for (int i = 0; i < planet.Data.miningDrills.Count; i++)
        {
            //GameObject drill = GameObject.Instantiate(drillDummy, gameObject.transform, false);
            //MiningDrill drillObject = new MiningDrill(drill, planet.Data.name);
            //drillObject.index = References.drills.Count;
            //drillObject.Generate();
        }

      /*  if (planet.Data.type == PlanetType.EXOTIC) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.exoticSprites[planet.Data.spriteNumber]; }
        if (planet.Data.type == PlanetType.EARTHLIKE) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.earthLikeSprites[planet.Data.spriteNumber]; }
        if (planet.Data.type == PlanetType.LAVA) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.lavaSprites[planet.Data.spriteNumber]; }
        if (planet.Data.type == PlanetType.ROCKY) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.rockySprites[planet.Data.spriteNumber]; }
        if (planet.Data.type == PlanetType.GAS) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.gasSprites[planet.Data.spriteNumber]; }
        if (planet.Data.type == PlanetType.ICE) { gameObject.GetComponent<SpriteRenderer>().sprite = Planets.iceSprites[planet.Data.spriteNumber]; }
        */
    }
}
