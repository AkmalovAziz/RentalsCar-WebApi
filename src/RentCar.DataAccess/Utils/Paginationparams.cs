namespace RentCar.DataAccess.Utils;

public class Paginationparams
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public Paginationparams(int pagenumber, int pagesize)
    {
        PageNumber = pagenumber;
        PageSize = pagesize;
    }

    public int SkipCount()
    {
        return (PageNumber - 1) * PageSize;
    }
}
