
var character = new Character(new AgrassiveCombatStrategy());
character.Attack();

character.SetCombatStrategy(new defensiveCombatStrategy());
character.Attack();

class Character
{
    private ICombatStrategy _combatStrategy;
    public Character()
    {
        
    }
    public Character(ICombatStrategy combatStrategy)
    {
        _combatStrategy = combatStrategy;
    }
    public void SetCombatStrategy(ICombatStrategy combatStrategy)
    {
        _combatStrategy = combatStrategy;
    }
    public void Attack()
    {
        _combatStrategy.ExecuteAttack();
    }
}


interface ICombatStrategy
{
    void ExecuteAttack();
}

class AgrassiveCombatStrategy : ICombatStrategy
{
    public void ExecuteAttack()
    {
        Console.WriteLine("Performing an aggressive attack!");
    }
}

class defensiveCombatStrategy : ICombatStrategy
{
    public void ExecuteAttack()
    {
        Console.WriteLine("Performing a defensive attack!");
    }
}