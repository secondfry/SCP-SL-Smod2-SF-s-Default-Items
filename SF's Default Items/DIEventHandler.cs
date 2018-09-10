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
        private List<Role> rolesWithoutInventory = new List<Role> {
            Role.SCP_049,
            Role.SCP_049_2,
            Role.SCP_079,
            Role.SCP_096,
            Role.SCP_106,
            Role.SCP_173,
            Role.SCP_939_53,
            Role.SCP_939_89,
            Role.SPECTATOR,
            Role.TUTORIAL,
            Role.UNASSIGNED,
            Role.ZOMBIE,
        };

        public DIEventHandler(DefaultItem plugin) {
            this.plugin = plugin;
        }

        public void OnSetRole(PlayerSetRoleEvent ev) {
            if (this.rolesWithoutInventory.Contains(ev.Role)) {
                return;
            }

            IConfigFile config = ConfigManager.Manager.Config;
            string shard = DIEventHandler.ConvertRoleIDToString(ev.Role);
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

        private static string ConvertRoleIDToString(Role role) {
            switch (role) {
                case Role.CLASSD:
                    return "classd";
                case Role.NTF_SCIENTIST:
                    return "ntfscientist";
                case Role.SCIENTIST:
                    return "scientist";
                case Role.CHAOS_INSUGENCY:
                    return "ci";
                case Role.NTF_LIEUTENANT:
                    return "lieutenant";
                case Role.NTF_COMMANDER:
                    return "commander";
                case Role.NTF_CADET:
                    return "cadet";
                case Role.FACILITY_GUARD:
                    return "guard";
                case Role.TUTORIAL:
                    return "tutorial";
            }

            return "";
        }
    }
}
