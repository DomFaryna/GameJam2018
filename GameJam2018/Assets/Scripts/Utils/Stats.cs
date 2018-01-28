
public class Stats
{
    private float speed = 1;
    private float health = 1;
    private float infectionHealth = 1;
    private float infectionHealthDepleationRate = 1;
    private float attack = 1;
    private float infectionAttack = 1;

    public Stats(float speed, float health, float infectionHealth, float infectionHealthDepleationRate, float attack, float infectionAttack)
    {
        this.speed = speed;
        this.health = health;
        this.infectionHealth = infectionHealth;
        this.infectionHealthDepleationRate = infectionHealthDepleationRate;
        this.attack = attack;
        this.infectionAttack = infectionAttack;
    }


    public float Speed
    {
        get { return speed; }
    }

    public float Health
    {
        get { return health; }
    }

    public float InfectionHealth
    {
        get { return infectionHealth; }
    }

    public float InfectionHealthDepleationRate
    {
        get { return infectionHealthDepleationRate; }
    }

    public float Attack
    {
        get { return attack; }
    }

    public float InfectionAttack
    {
        get { return infectionAttack; }
    }
    
}
