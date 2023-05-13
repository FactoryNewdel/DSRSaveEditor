
namespace DSR.SlotDetails;

public class SaveSlotDetails
{
    private byte[] _bytes;

    private CharacterStats _characterStats;

    public SaveSlotDetails(byte[] bytes)
    {
        _bytes = bytes;
        
        _characterStats = new CharacterStats(bytes);

        if (_characterStats.Level == 0) return;
        
        // x?
        /*_bytes[220958] = 34;
        _bytes[220959] = 130;
        _bytes[220960] = 65;
        _bytes[220961] = 64;
        
        // y?
        _bytes[220962] = 41;
        _bytes[220963] = 226;
        _bytes[220964] = 68;
        _bytes[220965] = 67;
        
        // z?
        _bytes[220966] = 109;
        _bytes[220967] = 25;
        _bytes[220968] = 22;
        _bytes[220969] = 65;
        
        //_bytes[220978] = 226;
        //_bytes[220979] = 178;
        
        // pitch
        _bytes[220980] = 192;
        _bytes[220981] = 62;*/
        
        // 2984 counter until weapon loses durability
        // 2844, 2872 armor counter
        // 2980 weapon durability
        // 96, 97 cur HP
        // 220887 Enemy death states Asylum
        /*_bytes[220887] = 255;
        _bytes[220888] = 255;
        _bytes[220889] = 255;*/
        /*_bytes[220890] = 255;
        _bytes[220891] = 255;
        _bytes[220892] = 255;*/
        //_bytes[220988] = 255;
        //_bytes[220989] = 255;
        //_bytes[220900] = 255;
        //_bytes[220901] = 255;
        ///_bytes[220902] = 255;
        //_bytes[220903] = 255;
        //_bytes[220904] = 255;
        //_bytes[220905] = 255;
        /*_bytes[220906] = 0;
        _bytes[220907] = 0;
        _bytes[220908] = 0;
        _bytes[220909] = 0;
        _bytes[220910] = 0;
        _bytes[220911] = 0;
        _bytes[220912] = 0;
        _bytes[220913] = 0;
        _bytes[220914] = 0;
        _bytes[220915] = 0;
        _bytes[220916] = 0;
        _bytes[220917] = 0;
        _bytes[220918] = 0;
        _bytes[220919] = 0;
        _bytes[220920] = 0;
        _bytes[220921] = 0;
        _bytes[220922] = 0;
        _bytes[220923] = 0;
        _bytes[220924] = 0;*/
        
        //_bytes[221046] = 0;
        
        
        //_bytes[128533] = 54;
        // 177413 Bit1 Gold Pine Resin Door
        // 131291 Bit3 Undead Merchant (Male) dead
        //_bytes[131291] = 0;
        
        
        
        //_bytes[131388] = 16;    // Taurus Demon dead + Fog wall Bit2

        //_bytes[357] = 15;    // Weapon level (seams useless, maybe for pvp matchmaking?)
        //_bytes[772] = 245;   // Weapon id for compare  40 Longsword + 0, 140 crystal, 240 lightning
        //_bytes[2964] = 245;  // Weapon id of equipped
        
        /*_bytes[221165] = 46;
        _bytes[221166] = 104;
        _bytes[221173] = 201;
        _bytes[221174] = 84;
        _bytes[221185] = 240;
        _bytes[221186] = 4;
        _bytes[221187] = 38;
        _bytes[222329] = 249;
        _bytes[222330] = 165;
        _bytes[222331] = 27;
        _bytes[222333] = 10;
        _bytes[222337] = 0;
        _bytes[222349] = 248;
        _bytes[222350] = 165;
        _bytes[222351] = 27;
        _bytes[222353] = 10;
        _bytes[222369] = 232;
        _bytes[222370] = 73;
        _bytes[222371] = 15;
        _bytes[222373] = 0;
        _bytes[222389] = 8;
        _bytes[222390] = 152;
        _bytes[222391] = 15;
        _bytes[222393] = 20;
        _bytes[222397] = 1;*/

        // Suloire
        /*_bytes[151760] = 0;
        _bytes[200401] = 0;
        _bytes[200402] = 0;*/


        // 0, 64, 66

        // 127422 Bit1 Asylum Demon
        // 150475 Bit6 Asylum Big Door
        // 173512 Bit6 Asylum Soul in front of exit collected
        // 155584 Bit1 Firelink Humanity at Well
        // 131366 hellkyte dragon

        // 2683 first item type (item, weapon, armor, ring, etc)
        // 2688 first inv item amount
        // 2683-5 first inv item id
        // 
        // 144 small soul, 145 large soul, 244 Humanity

        // 740 Bit6 twohanding weapon


        //_bytes[220887] = 66;
        //_bytes[127422] = 0;


        //_bytes[150475] = 97;
        //_bytes[173512] = 0;

        //_bytes[2683] = 64;
        //_bytes[2684] = 145;
        //_bytes[2688] = 1;

        /*_bytes[2680] = 0;
        _bytes[2681] = 0;
        _bytes[2682] = 0;
        
        _bytes[2685] = 1;
        _bytes[2686] = 0;
        _bytes[2687] = 0;
        
        // place in list
        _bytes[2693] = 16;
        _bytes[2694] = 4;
        _bytes[2695] = 0;
        
        // Image
        _bytes[2696] = 1;*/


        /*_bytes[3092] = 255;
        _bytes[3093] = 255;
        _bytes[3094] = 255;
        _bytes[3095] = 255;*/
        //_bytes[58204] = 79;
        //_bytes[740] = 3;

        /*_bytes[220999] = 255;
        _bytes[221000] = 255;
        _bytes[221001] = 255;
        _bytes[221003] = 255;
        _bytes[221004] = 128;*/
        /*_bytes[221005] = 0;
        _bytes[221007] = 0;
        _bytes[221008] = 0;*/
        //_bytes[221009] = 0;

        /*_bytes[64] = 137;
        _bytes[65] = 0;
        _bytes[68] = 71;
        _bytes[72] = 217;
        _bytes[73] = 0;
        _bytes[76] = 151;
        _bytes[77] = 95;
        _bytes[84] = 155;
        _bytes[85] = 95;
        _bytes[127412] = 224;
        _bytes[127413] = 169;
        _bytes[127414] = 27;
        _bytes[127447] = 0;
        _bytes[127456] = 0;
        _bytes[127505] = 0;
        _bytes[127553] = 0;
        _bytes[127559] = 64;
        _bytes[128481] = 0;
        _bytes[128481] = 240;*/

        // red marker for "equipped"
        /*_bytes[664] = 75;
        // id
        _bytes[772] = 40;
        _bytes[773] = 17;
        _bytes[774] = 3;*/


    }

    public byte[] Bytes
    {
        get
        {
            _characterStats.UpdateData(ref _bytes);
            return _bytes;
        }
    }

    public CharacterStats CharacterStats => _characterStats;
}