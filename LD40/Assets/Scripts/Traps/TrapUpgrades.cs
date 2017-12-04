namespace Traps
{
    public enum TrapTypes
    {
        trap1,
        trap2,
        trap3
    }

    public enum UpgradeType
    {
        CatchRaduis,
        CatchCoolDown,
        CatchSuccessChance
    }

    public static class TrapTypesUpgrades
    {
        static int Trap1Success = 10;
        static int Trap1CoolDown = 10;
        static int Trap1Raduis = 10;

        static int Trap2Success = 10;
        static int Trap2CoolDown = 10;
        static int Trap2Raduis = 10;

        static int Trap3Success = 10;
        static int Trap3CoolDown = 10;
        static int Trap3Raduis = 10;

 
    
        public static int RequestUpgradeAmount(UpgradeType _Utype, TrapTypes _trapTypes)
        {
            switch (_trapTypes)
            {
                case TrapTypes.trap1:

                    switch(_Utype)
                    {
                        case UpgradeType.CatchSuccessChance:
                            return Trap1Success;
                        case UpgradeType.CatchCoolDown:
                            return Trap1CoolDown;
                        case UpgradeType.CatchRaduis:
                            return Trap1Raduis;
                    }

                    break;
                case TrapTypes.trap2:

                    switch (_Utype)
                    {
                        case UpgradeType.CatchSuccessChance:
                            return Trap2Success;
                        case UpgradeType.CatchCoolDown:
                            return Trap2CoolDown;
                        case UpgradeType.CatchRaduis:
                            return Trap2Raduis;
                    }

                    break;
                case TrapTypes.trap3:

                    switch (_Utype)
                    {
                        case UpgradeType.CatchSuccessChance:
                            return Trap3Success;
                        case UpgradeType.CatchCoolDown:
                            return Trap3CoolDown;
                        case UpgradeType.CatchRaduis:
                            return Trap3Raduis;
                    }

                    break;
            }

            return 0;
        }
    }
}
