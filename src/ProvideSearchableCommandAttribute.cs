using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;

using System;

namespace ToggleQuickInfo
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ProvideSearchableCommandAttribute : RegistrationAttribute
    {
        private const string _keyName = @"Search\CommandScopes";

        private readonly string _name;
        private readonly string _commandGuid;
        private readonly int _commandId;

        public ProvideSearchableCommandAttribute(string name, string commandGuid, int commandId)
        {
            _name = name;
            _commandGuid = commandGuid;
            _commandId = commandId;
        }

        public override void Register(RegistrationContext context)
        {
            using (Key langKey = context.CreateKey(_keyName))
            {
                langKey.SetValue(_name, $"{{{_commandGuid}}};{_commandId}");
            }
        }

        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(_keyName);
        }
    }
}
