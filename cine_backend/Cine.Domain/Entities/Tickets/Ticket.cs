namespace Cine.Domain.Entities.Tickets;
public class Ticket
{
    public int Id { get; private set; }
    public ShowTime? ShowTimes { get; private set; }
    public int ShowTimesId { get; private set; }
    public Chair? Chairs { get; private set; }
    public int ChairsId { get; private set; }
    public List<Discount> Discounts { get; private set; } = new List<Discount>();
    public bool IsWeb { get; private set; }
    public Ticket(int ShowTimesId, int ChairsId, bool IsWeb)
    {
        this.ShowTimesId = ShowTimesId;
        this.ChairsId = ChairsId;
        this.IsWeb = IsWeb;
    }
    public Ticket(ShowTime showTime, int ShowTimesId, Chair chair, int ChairsId, bool IsWeb)
    {
        ShowTimes = showTime;
        this.ShowTimesId = ShowTimesId;
        Chairs = chair;
        this.ChairsId = ChairsId;
        this.IsWeb = IsWeb;
    }
    public void Update(int ShowTimesId, int ChairsId, bool IsWeb)
    {
        this.ShowTimesId = ShowTimesId;
        this.ChairsId = ChairsId;
        this.IsWeb = IsWeb;
    }
    public void Update(ShowTime showTime, int ShowTimesId, Chair chair, int ChairsId, bool IsWeb)
    {
        ShowTimes = showTime;
        this.ShowTimesId = ShowTimesId;
        Chairs = chair;
        this.ChairsId = ChairsId;
        this.IsWeb = IsWeb;
    }
}