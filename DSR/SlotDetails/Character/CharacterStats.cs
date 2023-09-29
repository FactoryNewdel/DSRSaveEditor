using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using DSR.SlotDetailsDefinition;
using DSR.Utils;

namespace DSR.SlotDetails.Character;

public class CharacterStats : INotifyPropertyChanged
{
    #region Variables
    
    private byte[] _data;
    
    private UInt32 _level;
    private UInt32 _levelMin;
    
    private string _name;

    private StarterClass _starterClass;

    private UInt32 _vit;
    private UInt32 _vitMin;
    private UInt32 _att;
    private UInt32 _attMin;
    private UInt32 _attunementSlots;
    private UInt32 _end;
    private UInt32 _endMin;
    private UInt32 _str;
    private UInt32 _strMin;
    private UInt32 _dex;
    private UInt32 _dexMin;
    private UInt32 _int;
    private UInt32 _intMin;
    private UInt32 _fth;
    private UInt32 _fthMin;
    private UInt32 _resistance;
    private UInt32 _resistanceMin;
    
    private UInt32 _humanity;
    private UInt32 _currentSouls;
    private UInt32 _totalSouls;

    private UInt32 _deaths;

    private UInt32 _hpCurrent;
    private UInt32 _hpTotalUnmodified;
    private UInt32 _hpTotalModified;
    
    private UInt32 _staminaCurrent;
    private UInt32 _staminaTotalUnmodified;
    private UInt32 _staminaTotalModified;
    
    private UInt32 _playtime;
    private string _playtimeString;

    private byte _worldPrimary;
    private byte _worldSecondary;
    private string _locationString;
    
    #endregion
    
    public CharacterStats(byte[] data)
    {
        _data = data;

        Level = ToUInt32(CharacterStatsDefinition.Level);
        if (Level == 0) return;

        var sb = new StringBuilder();
        for (var i = CharacterStatsDefinition.Name.Offset;; i += 2)
        {
            if (_data[i] == 0 && _data[i + 1] == 0) break;
            sb.Append(Encoding.Unicode.GetString(_data.Skip(i).Take(2).ToArray()));
        }
        _name = sb.ToString();

        _starterClass = (StarterClass)_data[CharacterStatsDefinition.StarterClass.Offset];
        SetMinimumLevels();

        _vit = ToUInt32(CharacterStatsDefinition.Vitality);
        _att = ToUInt32(CharacterStatsDefinition.Attunement);
        _attunementSlots = GetAttunementSlots(_att);
        _end = ToUInt32(CharacterStatsDefinition.Endurance);
        _str = ToUInt32(CharacterStatsDefinition.Strength);
        _dex = ToUInt32(CharacterStatsDefinition.Dexterity);
        _int = ToUInt32(CharacterStatsDefinition.Intelligence);
        _fth = ToUInt32(CharacterStatsDefinition.Faith);
        _resistance = ToUInt32(CharacterStatsDefinition.Resistance);
        
        _humanity = ToUInt32(CharacterStatsDefinition.Humanity);
        _currentSouls = ToUInt32(CharacterStatsDefinition.CurrentSouls);
        _totalSouls = ToUInt32(CharacterStatsDefinition.TotalSouls);

        _deaths = ToUInt32(CharacterStatsDefinition.Deaths);

        _hpCurrent = ToUInt32(CharacterStatsDefinition.HPCurrent);
        _hpTotalUnmodified = ToUInt32(CharacterStatsDefinition.HPTotalUnmodified);
        _hpTotalModified = ToUInt32(CharacterStatsDefinition.HPTotalModified);

        _staminaCurrent = ToUInt32(CharacterStatsDefinition.StaminaCurrent);
        _staminaTotalUnmodified = ToUInt32(CharacterStatsDefinition.StaminaTotalUnmodified);
        _staminaTotalModified = ToUInt32(CharacterStatsDefinition.StaminaTotalModified);

        Playtime = ToUInt32(CharacterStatsDefinition.Playtime);

        WorldPrimary = data[CharacterStatsDefinition.WorldPrimary.Offset];
        WorldSecondary = data[CharacterStatsDefinition.WorldSecondary.Offset];
    }

    private void SetMinimumLevels()
    {
        if (_starterClass == StarterClass.Warrior)
        {
            _levelMin = 4;
            _vitMin = 11;
            _attMin =  8;
            _endMin = 12;
            _strMin = 13;
            _dexMin = 13;
            _resistanceMin = 11;
            _intMin =  9;
            _fthMin =  9;
        }
        else if (_starterClass == StarterClass.Knight)
        {
            _levelMin = 5;
            _vitMin = 14;
            _attMin = 10;
            _endMin = 10;
            _strMin = 11;
            _dexMin = 11;
            _resistanceMin = 10;
            _intMin =  9;
            _fthMin = 11;
        }
        else if (_starterClass == StarterClass.Wanderer)
        {
            _levelMin = 3;
            _vitMin = 10;
            _attMin = 11;
            _endMin = 10;
            _strMin = 10;
            _dexMin = 14;
            _resistanceMin = 12;
            _intMin = 11;
            _fthMin =  8;
        }
        else if (_starterClass == StarterClass.Thief)
        {
            _levelMin = 5;
            _vitMin =  9;
            _attMin = 11;
            _endMin =  9;
            _strMin =  9;
            _dexMin = 15;
            _resistanceMin = 10;
            _intMin = 12;
            _fthMin = 11;
        }
        else if (_starterClass == StarterClass.Bandit)
        { 
            _levelMin = 4;
            _vitMin = 12;
            _attMin =  8;
            _endMin = 14;
            _strMin = 14;
            _dexMin =  9;
            _resistanceMin = 11;
            _intMin =  8;
            _fthMin = 10;
        }
        else if (_starterClass == StarterClass.Hunter)
        {
            _levelMin = 4;
            _vitMin = 11;
            _attMin =  9;
            _endMin = 11;
            _strMin = 12;
            _dexMin = 14;
            _resistanceMin = 11;
            _intMin =  9;
            _fthMin =  9;
        }
        else if (_starterClass == StarterClass.Sorcerer)
        {
            _levelMin = 3;
            _vitMin =  8;
            _attMin = 15;
            _endMin =  8;
            _strMin =  9;
            _dexMin = 11;
            _resistanceMin = 8;
            _intMin = 15;
            _fthMin =  8;
        }
        else if (_starterClass == StarterClass.Pyromancer)
        {
            _levelMin = 1;
            _vitMin = 10;
            _attMin = 12;
            _endMin = 11;
            _strMin = 12;
            _dexMin =  9;
            _resistanceMin = 12;
            _intMin = 10;
            _fthMin =  8;
        }
        else if (_starterClass == StarterClass.Cleric)
        {
            _levelMin = 2;
            _vitMin = 11;
            _attMin = 11;
            _endMin =  9;
            _strMin = 12;
            _dexMin =  8;
            _resistanceMin = 11;
            _intMin =  8;
            _fthMin = 14;
        }
        else if (_starterClass == StarterClass.Deprived)
        {
            _levelMin = 6;
            _vitMin = 11;
            _attMin = 11;
            _endMin = 11;
            _strMin = 11;
            _dexMin = 11;
            _resistanceMin = 11;
            _intMin = 11;
            _fthMin = 11;
        } else if (_starterClass == StarterClass.Cheat)
        {
            _levelMin = 1;
            _vitMin = 1;
            _attMin = 1;
            _endMin = 1;
            _strMin = 1;
            _dexMin = 1;
            _resistanceMin = 1;
            _intMin = 1;
            _fthMin = 1;
        }
    }

    private uint GetAttunementSlots(uint att)
    {
        if (att >= 50) return 10;
        if (att >= 41) return  9;
        if (att >= 34) return  8;
        if (att >= 28) return  7;
        if (att >= 23) return  6;
        if (att >= 19) return  5;
        if (att >= 16) return  4;
        if (att >= 14) return  3;
        if (att >= 12) return  2;
        if (att >= 10) return  1;
        return 0;
    }

    private UInt32 ToUInt32(StatInformation info)
    {
        DetailComparer.Add(info);
        return BitConverter.ToUInt32(Take(info));
    }

    private byte[] Take(StatInformation info)
    {
        return _data.Skip(info.Offset).Take(info.Length).ToArray();
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
       if (_level == 0) return; 
        
        FillUInt32IntoData(ref data, _level, CharacterStatsDefinition.Level);

        var nameBytes = Encoding.Unicode.GetBytes(_name);
        for (int i = 0, offset = CharacterStatsDefinition.Name.Offset; i < nameBytes.Length; i++)
        {
            data[i + offset] = nameBytes[i];
        }

        data[CharacterStatsDefinition.StarterClass.Offset] = (byte)_starterClass;
        
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
        
        FillUInt32IntoData(ref data, _hpCurrent, CharacterStatsDefinition.HPCurrent);
        FillUInt32IntoData(ref data, _hpTotalUnmodified, CharacterStatsDefinition.HPTotalUnmodified);
        FillUInt32IntoData(ref data, _hpTotalModified, CharacterStatsDefinition.HPTotalModified);
        
        FillUInt32IntoData(ref data, _staminaCurrent, CharacterStatsDefinition.StaminaCurrent);
        FillUInt32IntoData(ref data, _staminaTotalUnmodified, CharacterStatsDefinition.StaminaTotalUnmodified);
        FillUInt32IntoData(ref data, _staminaTotalModified, CharacterStatsDefinition.StaminaTotalModified);
        
        FillUInt32IntoData(ref data, _playtime, CharacterStatsDefinition.Playtime);

        data[CharacterStatsDefinition.WorldPrimary.Offset] = _worldPrimary;
        data[CharacterStatsDefinition.WorldSecondary.Offset] = _worldSecondary;
    }

    public StarterClass StarterClass
    {
        get => _starterClass;
        set
        {
            _starterClass = value;
            SetMinimumLevels();
            NotifyPropertyChanged();
        }
    }

    public IEnumerable<StarterClass> AllStarterClasses => Enum.GetValues(typeof(StarterClass)).Cast<StarterClass>();

    public uint Level
    {
        get => _level;
        set
        {
            _level = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint LevelMin
    {
        get => _levelMin;
        private set
        {
            _levelMin = value;
            NotifyPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (value.Length > 13) throw new DataException($"value.Length {value.Length} > 13");
            _name = value ?? throw new ArgumentNullException(nameof(value));
            NotifyPropertyChanged();
        }
    }

    public uint Vitality
    {
        get => _vit;
        set
        {
            _vit = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint VitalityMin
    {
        get => _vitMin;
        private set
        {
            _vitMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Attunement
    {
        get => _att;
        set
        {
            _att = value;
            AttunementSlots = GetAttunementSlots(_att);
            NotifyPropertyChanged();
        }
    }

    public uint AttunementMin
    {
        get => _attMin;
        private set
        {
            _attMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint AttunementSlots
    {
        get => _attunementSlots;
        private set
        {
            _attunementSlots = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint Endurance
    {
        get => _end;
        set
        {
            _end = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint EnduranceMin
    {
        get => _endMin;
        private set
        {
            _endMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Strength
    {
        get => _str;
        set
        {
            _str = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint StrengthMin
    {
        get => _strMin;
        private set
        {
            _strMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Dexterity
    {
        get => _dex;
        set
        {
            _dex = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint DexterityMin
    {
        get => _dexMin;
        private set
        {
            _dexMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Intelligence
    {
        get => _int;
        set
        {
            _int = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint IntelligenceMin
    {
        get => _intMin;
        private set
        {
            _intMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Faith
    {
        get => _fth;
        set
        {
            _fth = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint FaithMin
    {
        get => _fthMin;
        private set
        {
            _fthMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Resistance
    {
        get => _resistance;
        set
        {
            _resistance = value;
            NotifyPropertyChanged();
        }
    }
    
    public uint ResistanceMin
    {
        get => _resistanceMin;
        private set
        {
            _resistanceMin = value;
            NotifyPropertyChanged();
        }
    }

    public uint Humanity
    {
        get => _humanity;
        set
        {
            _humanity = value;
            NotifyPropertyChanged();
        }
    }

    public uint CurrentSouls
    {
        get => _currentSouls;
        set
        {
            if (value > _currentSouls) TotalSouls += value;
            _currentSouls = value;
            NotifyPropertyChanged();
        }
    }

    public uint TotalSouls
    {
        get => _totalSouls;
        set
        {
            _totalSouls = value;
            NotifyPropertyChanged();
        }
    }

    public uint Deaths => _deaths;

    public uint HPCurrent
    {
        get => _hpCurrent;
        set
        {
            _hpCurrent = value;
            NotifyPropertyChanged();
        }
    }

    public uint HPTotalUnmodified
    {
        get => _hpTotalUnmodified;
        set
        {
            _hpTotalUnmodified = value;
            NotifyPropertyChanged();
        }
    }

    public uint HPTotalModified
    {
        get => _hpTotalModified;
        set
        {
            _hpTotalModified = value;
            NotifyPropertyChanged();
        }
    }


    public uint StaminaCurrent
    {
        get => _staminaCurrent;
        set
        {
            _staminaCurrent = value;
            NotifyPropertyChanged();
        }
    }

    public uint StaminaTotalUnmodified
    {
        get => _staminaTotalUnmodified;
        set
        {
            _staminaTotalUnmodified = value;
            NotifyPropertyChanged();
        }
    }

    public uint StaminaTotalModified
    {
        get => _staminaTotalModified;
        set
        {
            _staminaTotalModified = value;
            NotifyPropertyChanged();
        }
    }


    public uint Playtime
    {
        get => _playtime;
        private set
        {
            _playtime = value;
            var seconds = _playtime / 1000;
            var minutes = seconds / 60;
            var hours = minutes / 60;
            
            seconds -= minutes * 60;
            minutes -= hours * 60;
            
            _playtimeString = $"{hours} : {(minutes > 10 ? minutes : "0" + minutes)} : {(seconds > 10 ? seconds : "0" + seconds)}";
            NotifyPropertyChanged();
        }
    }

    public string PlaytimeString => _playtimeString;


    public byte WorldPrimary
    {
        get => _worldPrimary;
        private set
        {
            _worldPrimary = value;
            LocationString = Location.GetLocation(_worldPrimary, _worldSecondary);
        }
    }

    public byte WorldSecondary
    {
        get => _worldSecondary;
        private set
        {
            _worldSecondary = value;
            LocationString = Location.GetLocation(_worldPrimary, _worldSecondary);
        }
    }

    public string LocationString
    {
        get => _locationString;
        private set
        {
            _locationString = value;
            NotifyPropertyChanged();
        }
    }

    
    
    
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}