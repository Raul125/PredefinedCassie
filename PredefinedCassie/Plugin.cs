namespace PredefinedCassie
{
    using Exiled.API.Features;
    using System;

    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public override string Author { get; } = "Cegla, Raul125";
        public override string Name { get; } = "PredefinedCassie";
        public override string Prefix { get; } = "PredefinedCassie";
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        public override Version Version { get; } = new Version(1, 0, 5);

        public override void OnEnabled()
        {
            Singleton = this;
            CheckConfig();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            base.OnDisabled();
        }

        public void CheckConfig()
        {
            foreach (var cassie in Config.PredefiniedCassies)
            {
                if (cassie.Key == string.Empty || cassie.Value == string.Empty)
                {
                    Log.Info("Please, check your config, a predefined cassie is empty");
                }
            }
        }
    }
}
