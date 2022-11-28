using Xunit;
using System;


namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculateAnAverageGrade()
    {
        //arrange
        var book = new InMemoryBook("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);


        //act
        var result = book.GetStatistics();


        //assert
        Assert.Equal(85.6,result.Avereage, 1 );
        Assert.Equal('B',result.Letter );

    }
}