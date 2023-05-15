using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using DSR.SlotDetailsDefinition;
using DSR.Utils;

namespace DSR.SlotDetails;

public class CharacterStats : INotifyPropertyChanged
{
    #region Variables
    
    private byte[] _data;
    
    private UInt32 _level;
    
    private string _name;

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

    public uint Level
    {
        get => _level;
        set
        {
            _level = value;
            NotifyPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public uint Vitality
    {
        get => _vit;
        set => _vit = value;
    }

    public uint Attunement
    {
        get => _att;
        set => _att = value;
    }

    public uint Endurance
    {
        get => _end;
        set => _end = value;
    }

    public uint Strength
    {
        get => _str;
        set => _str = value;
    }

    public uint Dexterity
    {
        get => _dex;
        set => _dex = value;
    }

    public uint Intelligence
    {
        get => _int;
        set => _int = value;
    }

    public uint Faith
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

    public uint HPCurrent
    {
        get => _hpCurrent;
        set => _hpCurrent = value;
    }

    public uint HPTotalUnmodified
    {
        get => _hpTotalUnmodified;
        set => _hpTotalUnmodified = value;
    }

    public uint HPTotalModified
    {
        get => _hpTotalModified;
        set => _hpTotalModified = value;
    }

    
    
    public uint StaminaCurrent
    {
        get => _staminaCurrent;
        set => _staminaCurrent = value;
    }

    public uint StaminaTotalUnmodified
    {
        get => _staminaTotalUnmodified;
        set => _staminaTotalUnmodified = value;
    }

    public uint StaminaTotalModified
    {
        get => _staminaTotalModified;
        set => _staminaTotalModified = value;
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