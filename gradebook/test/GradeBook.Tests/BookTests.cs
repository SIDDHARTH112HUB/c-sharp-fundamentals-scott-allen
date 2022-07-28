using Xunit;
using System;
using GradeBook;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact] //fact is used to symbolize or decorate a method to denote this is the test used to produce pass or fail
        public void BookCaluculatesAverageGrade()
        {
            //arrange
            var book=new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            book.AddGrade(105.0);
            // Assert.Equal(4,book.Count());

            // act
            // var act=x+y;
            var result=book.GetStatistics();

            //assert
            // Assert.Equal(expected,act);
            Assert.Equal(85.6,result.average,1);
            Assert.Equal(90.5,result.High,1);
            Assert.Equal(77.3,result.Low,1);
            Assert.Equal('B',result.Letter);
        }
    }
}