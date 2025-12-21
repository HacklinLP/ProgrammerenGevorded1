using System;

namespace Domain.WizardingWorld
{
    public class WizardCreationException : Exception
    {
        public WizardCreationException(string message, string wizardName) : base(message)
        {
            RequestedWizardName = wizardName;
        }

        public string RequestedWizardName { get; private set; }
    }
}
