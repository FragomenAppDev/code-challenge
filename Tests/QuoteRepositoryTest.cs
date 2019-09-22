using System;
using Xunit;
using CodeChallenge.Model;
using System.Collections.Generic;

namespace CodeChallenge.Repository
{
    public class QuoteRepositoryTest
    {

        [Fact]
        public void PairsDataStructCreatedWithMoreThanOneQuoteOfTheSameLength()
        {
            QuoteRepository quoteRepository = new QuoteRepository();
            ICollection<Quote> quotes = new List<Quote>();

            Quote quote = new Quote();
            quote.Id = 1;
            quote.Text = "1";
            quotes.Add(quote);

            Quote quote2 = new Quote();
            quote2.Id = 2;
            quote2.Text = "22";
            quotes.Add(quote2);
            quotes.Add(quote2);

            quoteRepository.CreatePairsDataStruct(quotes);
            Assert.Equal(2, quoteRepository.pairsDictionary.Count);
            Assert.Equal(1, quoteRepository.pairsDictionary[1]);
            Assert.Equal(2, quoteRepository.pairsDictionary[2]);
        }

        [Fact]
        public void PairsDataStructCreatedWithQuoteLength()
        {
            ICollection<Quote> quotes = CreateQuotesTestList();
            QuoteRepository quoteRepository = new QuoteRepository();
            quoteRepository.CreatePairsDataStruct(quotes);
            Assert.Equal(6, quoteRepository.pairsDictionary.Count);
            Assert.False(quoteRepository.pairsDictionary.ContainsKey(1));
            Assert.Equal(1, quoteRepository.pairsDictionary[7]);
            Assert.Equal(1, quoteRepository.pairsDictionary[13]);
            Assert.Equal(2, quoteRepository.pairsDictionary[16]);
            Assert.Equal(1, quoteRepository.pairsDictionary[31]);
            Assert.Equal(1, quoteRepository.pairsDictionary[49]);
            Assert.Equal(1, quoteRepository.pairsDictionary[57]);
        }

        [Theory]
        [InlineData(19, 0)]
        [InlineData(22, 1)]
        [InlineData(32, 6)]
        [InlineData(40, 7)]
        [InlineData(200, 21)]
        public void GetPairsTest(long length, long expectedResult)
        {
            ICollection<Quote> quotes = CreateQuotesTestList();
            QuoteRepository quoteRepository = new QuoteRepository();
            quoteRepository.CreatePairsDataStruct(quotes);
            long result = quoteRepository.GetNumberOfPairs(length);
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void RemoveQuoteUpdatesPairsDataStructTest()
        {
            ICollection<Quote> quotes = CreateQuotesTestList();
            QuoteRepository quoteRepository = new QuoteRepository();
            quoteRepository.CreatePairsDataStruct(quotes);
            Assert.Equal(6, quoteRepository.pairsDictionary.Count);
            Assert.Equal(2, quoteRepository.pairsDictionary[16]);
            Quote quote = new Quote();
            quote.Text = "Cogito, ergo sum";
            quoteRepository.RemoveQuoteFromPairsDataStruct(quote);
            Assert.Equal(6, quoteRepository.pairsDictionary.Count);
            Assert.Equal(1, quoteRepository.pairsDictionary[16]);
        }

        [Fact]
        public void RemoveQuoteWhenNotInPairDSTest()
        {
            ICollection<Quote> quotes = CreateQuotesTestList();
            QuoteRepository quoteRepository = new QuoteRepository();
            quoteRepository.CreatePairsDataStruct(quotes);
            Assert.Equal(6, quoteRepository.pairsDictionary.Count);
            Assert.Equal(2, quoteRepository.pairsDictionary[16]);
            Quote quote = new Quote();
            quote.Text = "!";
            quoteRepository.RemoveQuoteFromPairsDataStruct(quote);
            Assert.Equal(6, quoteRepository.pairsDictionary.Count);
            Assert.Equal(2, quoteRepository.pairsDictionary[16]);
        }

        private ICollection<Quote> CreateQuotesTestList()
        {
            ICollection<Quote> quotes = new List<Quote>();
            Quote quote = new Quote();
            quote.Text = "Hello, World!"; //length 13
            quotes.Add(quote);
            Quote quote1 = new Quote();
            quote1.Text = "Veni, Vidi, Vici"; //length 16
            quotes.Add(quote1);
            Quote quote2 = new Quote();
            quote2.Text = "Cogito, ergo sum"; //length 16
            quotes.Add(quote2);
            Quote quote3 = new Quote();
            quote3.Text = "Do unto others as you would have them do unto you"; // length 49
            quotes.Add(quote3);
            Quote quote4 = new Quote();
            quote4.Text = "hunter2"; // length 7
            quotes.Add(quote4);
            Quote quote5 = new Quote();
            quote5.Text = "To every action there is always opposed an equal reaction"; //length 57
            quotes.Add(quote5);
            Quote quote6 = new Quote();
            quote6.Text = "Do, or do not. There is no try."; // length 31
            quotes.Add(quote6);
            return quotes;

        }
    }
}
