using Xunit;
using System;
using GradeBook;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegte(string logMessage); 
    public class TypeTests
    {
        int count=0;

        [Fact]
        public void WriteLogDelegateCnPointToMethod()
        {
            WriteLogDelegte log=ReturnMessage;

            // log= new WriteLogDelegte(ReturnMessage);
            // log = ReturnMessage; //m2
            log += ReturnMessage; //multicast delegate
            log += IncrementCount; 
            var result =log("Hello");

            Assert.Equal(3,count);
        }

        string IncrementCount(string message){
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message){
            count++;
            return message;
        }

        [Fact]
        public void StringBehaveLikeValueTypes(){
            string name="siddhu";
            var upper=MakeUpperCase(name);
            // name[1]='c';

            Assert.Equal("siddhu",name);
            Assert.Equal("SIDDHU",upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void test1(){
            var x= GetInt();
            SetInt(x);
            Assert.Equal(3,x);
            SetIntByref(ref x);
            Assert.Equal(42,x);
        }

        private void SetIntByref(ref int x)
        {
            x=42;;
        }

        private void SetInt(int x)
        {
            x=42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact] //fact is used to symbolize or decorate a method to denote this is the test used to produce pass or fail
        public void CanSetNameFromRefernce()
        {
            //arrange
            var book1=GetBook("Book 1");
            SetName(book1,"New Name");
            var book2=GetBook("Book 2");

            Assert.Equal("New Name",book1.Name); 
            

        }
        private void SetName(InMemoryBook book1, string v)
        {
            // book1.Name=v;
        }


        [Fact] 
        public void CShaerpCanPassByReference()
        {
            //arrange
            var book1=GetBook("Book 1");
            GetBookSetNameByRef(ref book1,"New Name");
            var book2=GetBook("Book 2");

            Assert.Equal("New Name",book1.Name); //name change of original book1 referenced.
            

        }
        private void GetBookSetNameByRef(ref InMemoryBook book1, string v)
        {
            book1 =new InMemoryBook(v);//new object created so no affect on original object  
        }

        [Fact] 
        public void CShaerpisPassByvalue()
        {
            //arrange
            var book1=GetBook("Book 1");
            GetBookSetName(book1,"New Name");
            var book2=GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name); //no change occur to original book1 refenced.
            

        }

        private void GetBookSetName(InMemoryBook book1, string v)
        {
            book1 =new InMemoryBook(v);//new object created so no affect on original object  
        }

        [Fact] //fact is used to symbolize or decorate a method to denote this is the test used to produce pass or fail
        public void GetBookReturnsDifferentObject()
        {
            //arrange
            var book1=GetBook("Book 1");
            var book2=GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name); 
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);

        }
        [Fact] //fact is used to symbolize or decorate a method to denote this is the test used to produce pass or fail
        public void TwoVariableRefernceSameObject()
        {
            //arrange
            var book1=GetBook("Book 1");
            var book2=book1;
            
            Assert.Same(book1,book2); //tell us book1 book2 point same instances / same object

            Assert.True(Object.ReferenceEquals(book1,book2));//will tell us if book1 book2 exact same references
            // both same and referenceequls are same 

            // Assert.Equal("Book 1",book1.Name); 
            // Assert.Equal("Book 1",book2.Name);
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}