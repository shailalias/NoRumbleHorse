using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Characters;
using StardewValley.Menus;
using StardewValley.Locations;
using static StardewValley.Farmer;
using static StardewValley.Characters.Horse;
using static StardewValley.Rumble;
using static StardewValley.Options;

namespace NoRumbleHorse
{

    public class ModEntry : Mod
    {
        private Horse thisHorse;
        // private const bool rumbleOption = true; 
        private bool rumbleOption = Game1.options.rumble;

        public override void Entry(IModHelper helper)
        {
            GameEvents.UpdateTick += this.GameEvents_UpdateTick;
            LocationEvents.CurrentLocationChanged += this.LocationEvents_CurrentLocationChanged;
        }


        private void GameEvents_UpdateTick(object sender, EventArgs e)
        {
            if (Game1.player.isRidingHorse() == true)
            {
                Game1.options.rumble = false;
            }
            else
            {
                Game1.options.rumble = rumbleOption;
                
            }
        }
        private void LocationEvents_CurrentLocationChanged(object sender, EventArgs e)
        {

            this.thisHorse = (Horse)null;
            foreach (NPC character in Game1.currentLocation.getCharacters())
            {
                if (character is Horse)
                {
                    this.thisHorse = (Horse)character;
                    break;
                }
            }
        }

 
    }
}