using System.Collections.Generic;

public class MultiBool
{
    public MultiBool(Type type)
    {
        _type = type;
    }

    public enum Type { and, or }

    private Dictionary<string, bool> _bools = new Dictionary<string, bool>();
    private Type _type = Type.and;

    private void SetValue(string key, bool value)
    {
        if (_bools.ContainsKey(key))
            _bools[key] = value;
        else
            _bools.Add(key, value);
    }

    private bool GetValue()
    {
        if (_bools.Count == 0) return false;

        bool result = false;

        if (_type == Type.and) result = true;
        if (_type == Type.or) result = false;

        foreach (var b in _bools)
        {
            var istrue = b.Value;

            if (_type == Type.and)
                if (!istrue) result = false;
            if (_type == Type.or)
                if (istrue) result = true;
        }

        return result;
    }

    public void SetTrue(string key)
    {
        SetValue(key, true);
    }

    public void SetFalse(string key)
    {
        SetValue(key, false);
    }

    public bool Value => GetValue();
}
