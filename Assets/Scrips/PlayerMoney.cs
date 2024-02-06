using System;

/// <summary>
/// Структура кошелька для иговых денег игрока
/// </summary>
public struct PlayerMoney
{
    private int _value; // Внутреннее значение
    public int Value { get { return _value; } } // Геттер _value

    /// <summary>
    /// Функция для проверки, хватает ли денег в кошельке для покупки.
    /// </summary>
    /// <param name="cost">Цена покупки</param>
    /// <returns>Bool значение итог: true - покупка возможна, false - покупка невозможна.</returns>
    /// <exception cref="ArgumentException">Возникает при отрицательном значении cost</exception>
    public bool IsBuyAvailable(int cost)
    {
        if (cost < 0) throw new ArgumentException($"Стоимость постройки не может быть ниже нуля! : cost = {cost}");
        if (_value < cost) return false;
        return true;
    }

    /// <summary>
    /// Функция "Потратить деньги"
    /// </summary>
    /// <param name="cost">Стоимость покупки</param>
    /// <returns>Количество оставшихся денег</returns>
    public int Spend(int cost)
    {
        if (IsBuyAvailable(cost)) _value -= cost;
        return Value;
    }

    /// <summary>
    /// Функция, аналогичная PlayerMoney.Spend(int).
    /// </summary>
    /// <param name="cost">Стоимость покупки</param>
    /// <returns>Bool значение итог: true - покупка удалась, false - покупка неудалась.</returns>
    public bool TryToSpend(int cost)
    {
        bool res = IsBuyAvailable(cost);
        if (res) _value -= cost;
        return res;
    }

    public PlayerMoney(int value)
    {
        _value = value;
    }

    public static implicit operator PlayerMoney(int v)
    {
        return new PlayerMoney(v);
    }

    public static PlayerMoney operator +(PlayerMoney money, int value) => new PlayerMoney(money.Value + value);

    public override string ToString() => Value.ToString();
}