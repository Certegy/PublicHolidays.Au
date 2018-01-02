using System;

namespace PublicHolidays.Au
{
    [Flags]
    public enum Region
    {
        // Australian States
        ACT = 1,
        NSW = 2,
        NT = 4,
        QLD = 8,
        SA = 16,
        TAS = 32,
        VIC = 64,
        WA = 128,
        // New Zealand Regions
        Northland = 256,
        Auckland = 512,
        Waikato = 1024,
        BayOfPlenty = 2048,
        Gisborne = 4096,
        HawkesBay = 8192,
        Taranaki = 16384,
        ManawatuWanganui = 32768,
        Wellington = 65536,
        Tasman = 131072,
        Nelson = 262144,
        Marlborough = 524288,
        WestCoast = 1048576,
        Canterbury = 2097152,
        Otago = 4194304,
        Southland = 8388608,
        // Collections
        AU = ACT | NSW | NT | QLD | SA | TAS | VIC | WA,
        NZ = Northland | Auckland | Waikato | BayOfPlenty | Gisborne | HawkesBay | Taranaki | ManawatuWanganui | Wellington | Tasman | Nelson | Marlborough | WestCoast | Canterbury | Otago | Southland,
        ANZ = AU | NZ
    }
}