using System;

public class Wallet
{
    public int Coins { get; private set; }
    public event Action<int> OnSetCoins;

    public Wallet(int coins)
    {
        Coins = coins;
        OnSetCoins?.Invoke(Coins);
    }

    public void Add()
    {
        Coins++;
        OnSetCoins?.Invoke(Coins);
    }

    public void Add(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(coins.ToString());

        Coins += coins;
        OnSetCoins?.Invoke(Coins);
    }

    public bool CanBuy(int coins)
    {
        return Coins >= coins;
    }

    public void Buy(int coins)
    {
        if (!CanBuy(coins) || coins < 0)
            throw new ArgumentOutOfRangeException(coins.ToString());

        Coins -= coins;
        OnSetCoins?.Invoke(Coins);
    }
}
