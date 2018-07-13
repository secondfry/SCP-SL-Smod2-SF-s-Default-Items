using Smod2;
using Smod2.Attributes;

namespace SF_s_Default_Items {
    [PluginDetails(
        author = "ShingekiNoRex, @Second_Fry",
        name = "Default Item",
        description = "Custom Default Item for each human class",
        id = "sf.default.item",
        version = "1.4.0",
        SmodMajor = 3,
        SmodMinor = 1,
        SmodRevision = 7
        )]
    public class DefaultItem : Plugin {
        public override void OnDisable() {
            this.Info(this.Details.name + " has been disabled.");
        }

        public override void OnEnable() {
            this.Info(this.Details.name + " has been enabled.");
        }

        public override void Register() {
            this.AddEventHandlers(new DIEventHandler(this));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_classd", new int[] { -1 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_ntfscientist", new int[] { 7, 12, 14, 19, 20, 25, 27 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_scientist", new int[] { 1, 14 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_ci", new int[] { 10, 19, 24, 26 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_lieutenant", new int[] { 7, 12, 19, 20, 25, 27 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_commander", new int[] { 8, 12, 19, 20, 25, 27 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_cadet", new int[] { 7, 12, 19, 20 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_guard", new int[] { 7, 12, 19, 20 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
            this.AddConfig(new Smod2.Config.ConfigSetting("default_item_tutorial", new int[] { -1 }, Smod2.Config.SettingType.NUMERIC_LIST, true, ""));
        }
    }
}
