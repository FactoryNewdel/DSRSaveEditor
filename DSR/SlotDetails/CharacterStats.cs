using DSR.SlotDetailsDefinition;
using DSR.Utils;

namespace DSR.SlotDetails;

public class CharacterStats
{
    private byte[] _data;
    
    private UInt32 _level;
    
    private UInt32 _vit;
    private UInt32 _att;
    private UInt32 _end;
    private UInt32 _str;
    private UInt32 _dex;
    private UInt32 _int;
    private UInt32 _fth;
    private UInt32 _resistance;
    
    private UInt32 _humanity;
    private UInt32 _currentSouls;
    private UInt32 _totalSouls;

    private UInt32 _currentHP;
    
    private UInt32 _playtime;

    private byte _worldPrimary;
    private byte _worldSecondary;
    
    public CharacterStats(byte[] data)
    {
        _data = data;
        
        _level = ToUInt32(CharacterStatsDefinition.Level);
        if (_level == 0) return;

        _vit = ToUInt32(CharacterStatsDefinition.Vitality);
        _att = ToUInt32(CharacterStatsDefinition.Attunement);
        _end = ToUInt32(CharacterStatsDefinition.Endurance);
        _str = ToUInt32(CharacterStatsDefinition.Strength);
        _dex = ToUInt32(CharacterStatsDefinition.Dexterity);
        _int = ToUInt32(CharacterStatsDefinition.Intelligence);
        _fth = ToUInt32(CharacterStatsDefinition.Faith);
        _resistance = ToUInt32(CharacterStatsDefinition.Resistance);
        
        _humanity = ToUInt32(CharacterStatsDefinition.Humanity);
        _currentSouls = ToUInt32(CharacterStatsDefinition.CurrentSouls);
        _totalSouls = ToUInt32(CharacterStatsDefinition.TotalSouls);

        _currentHP = ToUInt32(CharacterStatsDefinition.CurrentHP);

        _playtime = ToUInt32(CharacterStatsDefinition.Playtime);

        _worldPrimary = data[CharacterStatsDefinition.WorldPrimary.Offset];
        _worldSecondary = data[CharacterStatsDefinition.WorldSecondary.Offset];
    }

    private UInt32 ToUInt32(StatInformation info)
    {
        DetailComparer.Add(info);
        return BitConverter.ToUInt32(_data.Skip(info.Offset).Take(info.Length).ToArray());
    }

    private void FillUInt32IntoData(ref byte[] data, UInt32 fill, StatInformation info)
    {
        var fillBytes = BitConverter.GetBytes(fill);
        for (int i = 0, offset = info.Offset; i < 4; i++)
        {
            data[i + offset] = fillBytes[i];
        }
    }

    public void UpdateData(ref byte[] data)
    {
        FillUInt32IntoData(ref data, _level, CharacterStatsDefinition.Level);
        
        FillUInt32IntoData(ref data, _vit, CharacterStatsDefinition.Vitality);
        FillUInt32IntoData(ref data, _att, CharacterStatsDefinition.Attunement);
        FillUInt32IntoData(ref data, _end, CharacterStatsDefinition.Endurance);
        FillUInt32IntoData(ref data, _str, CharacterStatsDefinition.Strength);
        FillUInt32IntoData(ref data, _dex, CharacterStatsDefinition.Dexterity);
        FillUInt32IntoData(ref data, _int, CharacterStatsDefinition.Intelligence);
        FillUInt32IntoData(ref data, _fth, CharacterStatsDefinition.Faith);
        FillUInt32IntoData(ref data, _resistance, CharacterStatsDefinition.Resistance);
        
        FillUInt32IntoData(ref data, _humanity, CharacterStatsDefinition.Humanity);
        FillUInt32IntoData(ref data, _currentSouls, CharacterStatsDefinition.CurrentSouls);
        FillUInt32IntoData(ref data, _totalSouls, CharacterStatsDefinition.TotalSouls);
        
        FillUInt32IntoData(ref data, _currentHP, CharacterStatsDefinition.CurrentHP);
        
        FillUInt32IntoData(ref data, _playtime, CharacterStatsDefinition.Playtime);

        data[CharacterStatsDefinition.WorldPrimary.Offset] = _worldPrimary;
        data[CharacterStatsDefinition.WorldSecondary.Offset] = _worldSecondary;
    }

    public uint Level
    {
        get => _level;
        set => _level = value;
    }

    public uint Vit
    {
        get => _vit;
        set => _vit = value;
    }

    public uint Att
    {
        get => _att;
        set => _att = value;
    }

    public uint End
    {
        get => _end;
        set => _end = value;
    }

    public uint Str
    {
        get => _str;
        set => _str = value;
    }

    public uint Dex
    {
        get => _dex;
        set => _dex = value;
    }

    public uint I
    {
        get => _int;
        set => _int = value;
    }

    public uint Fth
    {
        get => _fth;
        set => _fth = value;
    }

    public uint Resistance
    {
        get => _resistance;
        set => _resistance = value;
    }

    public uint Humanity
    {
        get => _humanity;
        set => _humanity = value;
    }

    public uint CurrentSouls
    {
        get => _currentSouls;
        set => _currentSouls = value;
    }

    public uint TotalSouls
    {
        get => _totalSouls;
        set => _totalSouls = value;
    }

    public uint CurrentHp
    {
        get => _currentHP;
        set => _currentHP = value;
    }


    public uint Playtime => _playtime;
    
    

    public byte WorldPrimary => _worldPrimary;

    public byte WorldSecondary => _worldSecondary;
}