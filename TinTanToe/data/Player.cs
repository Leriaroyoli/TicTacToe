namespace TinTanToe.data;

public class Player
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Password { get; set; }
    public double Rating { get; private set; }

    public Player(string name, string password, double rating)
    {
        Password = password;
        Name = name;
        Rating = rating;
    }

    public void AddToRating(double sum)
    {
        Rating += sum;
    }

    public void WithdrawFromRating(double sum)
    {
        Rating -= sum;
    }
   
}