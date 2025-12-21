using System;

namespace Domain.WizardingWorld
{
    public class WizardFactory
    {
        public Wizard Create(string name, bool isCeo = false)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (isCeo)
            {
                if (!IsValidCeoName(name))
                {
                    throw new WizardCreationException(
                        $"{name} is not a valid name for a Ceo wizard, Ceo wizard names must end with 'Potter' or 'Voldemort'",
                        name);
                }

                return new CeoWizard { Name = name };
            }

            return new NormalWizard { Name = name };
        }

        private bool IsValidCeoName(string name) => name.EndsWith("Potter") ||
                                                     name.EndsWith("Voldemort");
    }
}
