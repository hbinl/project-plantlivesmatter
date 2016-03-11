using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Plant
{
    [XmlElement("name")]
    public string name;
    public float health;
    public float happiness;
    public float exp;

    public int numGoldLeafs;
    public int stage;

    public float hpDecayRate;
    public float time;

    public float maxHP;
    public float maxHappiness;

    public Dictionary<string, object>[] DATA =
        new Dictionary<string, object>[] {
            new Dictionary<string, object>() {

            }
        };

    public Plant(string newName)
    {
        name = newName;
        health = 25.0f;
        happiness = 100.0f;
        exp = 24.0f;
        numGoldLeafs = 10;
        maxHP = 25.0f;
        maxHappiness = 100.0f;

    }

    public int getGoldLeaf()
    {
        return numGoldLeafs;
    }

    public void addGoldLeaf(int num)
    {
        numGoldLeafs += num;
        if (numGoldLeafs < 0)
        {
            numGoldLeafs = 0;
        }
        if (numGoldLeafs > 10)
        {
            numGoldLeafs = 10;
        }
    }

    public float getMaxHP()
    {
        return maxHP;
    }

    public void setName(string newName)
    {
        if (newName != null)
        {
            name = newName;
        }
    }

    public string getName()
    {
        return name;
    }

    public float getHP()
    {
        return health;
    }

    public void addHP(float diff)
    {
        health += diff;
        if (health < 0)
        {
            health = 0;
        }
        if (health > maxHP)
        {
            health = maxHP;
        }
    }

    public float GetHappiness()
    {
        return happiness;
    }

    public void addHappiness(float diff)
    {
        happiness += diff;
        if (happiness < 0)
        {
            happiness = 0;
        }
        if (happiness > maxHappiness)
        {
            happiness = maxHappiness;
        }
    }

    public float GetExp()
    {
        return exp;
    }

    public void AddExp(float NewExp)
    {
        exp += NewExp;
    }


}

