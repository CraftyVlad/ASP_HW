namespace ASP_HW.Models
{
    public class Warrior
    {
        private readonly IWeapon Weapon;

        public Warrior(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public string Attack()
        {
            return Weapon.Kill();
        }
    }
}
