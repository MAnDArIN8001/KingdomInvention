using System;

public interface IHealable
{
    public event Action OnHealed;

    public void Heal(float healCount);
}
