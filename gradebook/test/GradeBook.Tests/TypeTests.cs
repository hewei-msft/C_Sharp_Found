using Xunit;
using System;


namespace GradeBook.Tests;
public delegate string WriteLogDelegrate(string logMessage);

public class TypeTests
{
     int count = 0;

    [Fact]
    public void WriteLogDelegrateCAnwork(){
        WriteLogDelegrate log = ReturnMessage;
        //log = new WriteLogDelegrate(ReturnMessage);
        log += ReturnMessage;
        log += IncrementCount;
        var result = log("Hello!");
        Assert.Equal(3, count);

    }

    string ReturnMessage(String message){
        count++;
        return message;
    }

    string IncrementCount(String message){
        count++;
        return message.ToLower();
    }
    
    [Fact]
    public void StringBehaviourValueType()
    {
        string name = "scott";
        MakeUpppercase(name);
        Assert.Equal(name,"scott");
    }
    private void MakeUpppercase(string parameter)
    {
        parameter = parameter.ToUpper();
    }


    [Fact]
    public void TestName()
    {
        // Given
        var x = GetInt();
        SetInt(ref x);

    
        // When
        Assert.Equal(42,x);

       
    
        // Then
    }
    private int GetInt(){

        return 3;

    }

    private void SetInt(ref int i)
    {
        i = 42;

    }



    [Fact]
    public void CanPassByRef()
    {
        //arrange
        var book1 = GetBook("Book1");
        GetBookRefSetName(out book1, "New Name");

        //assert
        Assert.Equal(book1.Name,"New Name" );


    }
    private void GetBookRefSetName(out InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }

    [Fact]
    public void CanPassByValue()
    {
        //arrange
        var book1 = GetBook("Book1");
        GetBookSetName(book1, "New Name");

        //assert
        Assert.Equal(book1.Name,"Book1" );


    }
    private void GetBookSetName(InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }



    [Fact]
    public void PassByReference()
    {
        //arrange
        var book1 = GetBook("Book1");
        SetName(book1, "New Name");

        //assert
        Assert.Equal(book1.Name,"New Name" );


    }
    private void SetName(InMemoryBook book, string name)
    {
        book.Name = name;
    }


    [Fact]
    public void BookCalculateAnAverageGrade()
    {
        //arrange
        var book1 = GetBook("Book1");
        var book2 = GetBook("Book2");



        //assert
        Assert.Equal(book1.Name,"Book1" );
        Assert.Equal(book2.Name,"Book2" );
        Assert.NotSame(book1,book2);

    }


        [Fact]
    public void TwoReferenceSameObject()
    {
        //arrange
        var book1 = GetBook("Book1");
        var book2 = book1;



        //assert
        Assert.Equal(book1.Name,book2.Name );
        Assert.Same(book1,book2);



    }


    private InMemoryBook GetBook(string name)
    {
        
        return new InMemoryBook(name);

    }
}