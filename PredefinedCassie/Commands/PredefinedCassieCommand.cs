namespace PredefinedCassie.Command
{
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using RemoteAdmin;
    using System;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class PredefinedCassieCommand : ICommand
    {
        public string Command { get; } = "predefinedcassie";

        public string[] Aliases { get; } = { "pc" };

        public string Description { get; } = "Executes an Predefined Cassie Command";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((sender as PlayerCommandSender).ReferenceHub);

            if (!sender.CheckPermission("pc.cassie"))
            {
                response = "You don't have permission to do that. Missing permission: pc.cassie";
                return false;
            }
            

            if (arguments.Count == 0)
            {
                string cassies = "";
                foreach (var cas in Plugin.Singleton.Config.PredefiniedCassies.Keys)
                {
                    cassies += $"{cas}\n";
                }

                response = $"Available cassies: \n{cassies}";
                return false;
            }

            string cassie = arguments.At(0);

            if (!Plugin.Singleton.Config.PredefiniedCassies.ContainsKey(cassie))
            {
                response = $"The predefined cassie <b>{cassie}</b> isn't valid";

                return false;
            }

            Cassie.Message(Plugin.Singleton.Config.PredefiniedCassies[cassie], false, Plugin.Singleton.Config.AreCassiesNoisy);

            response = "Cassie sent";
            return true;
        }
    }
}