public class MoneyManager
{
    public int Money { get; set; }
    private MoneyManager()
    {

    }

    private static MoneyManager instance;
    public static MoneyManager Instance
    {
        get
        {
            if (instance == null)
                instance = new MoneyManager();
            return instance;
        }
    }
}