using EfMultiTable.Infrastructure;
using FluentAssertions;
using Xunit.Abstractions;

namespace EfMultiTable.Tests;

public class MultiTableTests
{
    readonly MultiTableContext dbContex;
    private readonly ITestOutputHelper output;

    public MultiTableTests(ITestOutputHelper output)
    {
        const string connectionString = "Server=localhost;Database=MultiTable;User Id=sa;Password=Password1;TrustServerCertificate=True;";
        this.output = output;
        
        dbContex = new MultiTableContext(connectionString);
        
    }

    //[Fact]
    //public void ShouldLoadLive()
    //{
    //    dbContex.Live.ToList().Count.Should().Be(2);
    //}
    
    //[Fact]
    //public void ShouldLoadHistory()
    //{
    //    dbContex.History.ToList().Count.Should().Be(3);
    //}

    //[Fact]
    //public void ShouldLoadAll()
    //{
    //    IQueryable<ResultRow> live = dbContex.Live.Select(live => new ResultRow(
    //        live.Id, live.First, live.Last, "Live"
    //        ));

    //    IQueryable<ResultRow> history = dbContex.History.Select(live => new ResultRow(
    //        live.Id, live.First, live.Last, "History"
    //        ));

    //    live.ToList().Count.Should().Be(2);
    //    history.ToList().Count.Should().Be(3);
    //}

    [Fact]
    public void ShouldLoadAllAtOnce()
    {
        var all = dbContex.Live.Select(live => new ResultRow(
            live.Id, live.First, live.Last, "Live"
            )).AsEnumerable()
            //.Concat(
            //dbContex.History.Select(history => new ResultRow(
            //history.Id, history.First, history.Last, "History"))
            //)
            .ToList();
            


        all.Count.Should().Be(5);
        
    }


    public record ResultRow(int Id, string First, string Last, string Table);
}