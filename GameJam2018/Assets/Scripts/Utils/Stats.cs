
public class Stats
{
    private double speed = 1;
    private double health = 1;
    private double infectionHealth = 1;
    private double infectionHealthDepleationRate = 1;
    private double attack = 1;
    private double infectionAttack = 1;

    public Stats(double speed, double health, double infectionHealth, double infectionHealthDepleationRate, double attack, double infectionAttack)
    {
        this.speed = speed;
        this.health = health;
        this.infectionHealth = infectionHealth;
        this.infectionHealthDepleationRate = infectionHealthDepleationRate;
        this.attack = attack;
        this.infectionAttack = infectionAttack;
    }


    public double Speed
    {
        get { return speed; }
    }

    public double Health
    {
        get { return health; }
    }

    public double InfectionHealth
    {
        get { return infectionHealth; }
    }

    public double InfectionHealthDepleationRate
    {
        get { return infectionHealthDepleationRate; }
    }

    public double Attack
    {
        get { return attack; }
    }

    public double InfectionAttack
    {
        get { return infectionAttack; }
    }
    
}
