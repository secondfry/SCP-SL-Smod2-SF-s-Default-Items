using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Collections.Generic;

namespace SF_s_Default_Items {
    class DIEventHandler : IEventHandlerSetRole {
        private DefaultItem plugin;
        private List<int> teamsWithoutInventory = new List<int> {
            (int) Team.NONE,
            (int) Team.SCP,
            (int) Team.SPECTATOR
        };

        public DIEventHandler(DefaultItem plugin) {
            this.plugin = plugin;
        }

        public void OnSetRole(PlayerSetRoleEvent ev) {
            if (this.teamsWithoutInventory.Contains((int) ev.TeamRole.Team)) {
                return;
            }

            IConfigFile config = ConfigManager.Manager.Config;
            string shard = DIEventHandler.ConvertRoleIDToString((int) ev.Role);
            int[] items = config.GetIntListValue("default_item_" + shard, true);

            foreach (Item item in ev.Player.GetInventory()) {
                item.Remove();
            }

            foreach (int item in items) {
                if (item == -1) {
                    continue;
                }

                ev.Player.GiveItem((ItemType) item);
            }
        }

        private static string ConvertRoleIDToString(int roleID) {
            switch (roleID) {
                case (int) Role.CLASSD:
                    return "classd";
                case (int) Role.NTF_SCIENTIST:
                    return "ntfscientist";
                case (int) Role.SCIENTIST:
                    return "scientist";
                case (int) Role.CHAOS_INSUGENCY:
                    return "ci";
                case (int) Role.NTF_LIEUTENANT:
                    return "lieutenant";
                case (int) Role.NTF_COMMANDER:
                    return "commander";
                case (int) Role.NTF_CADET:
                    return "cadet";
                case (int) Role.FACILITY_GUARD:
                    return "guard";
                case (int) Role.TUTORIAL:
                    return "tutorial";
            }

            return "";
        }
    }
}
