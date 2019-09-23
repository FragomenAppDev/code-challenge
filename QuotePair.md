# Algorithm Overview

## Quote Pairs Internal Data Structure
I have created a dictionary to store the <quote length, # quotes of that length in the dataset>. This data structrue gets built at initialization which takes O(n).  Once this is built it is kept in memory and with each CRUD operation the data structure gets updated. 

## Quote Pair Algorithm Design
The task is to find the number of quote pairs in the data set such that the sum of their lengths is equal to or less than a given input size.

This algorithm works by traversing through the quote length dictionary, from 0 to the given input size. 

For each length, I check if a pair of quotes of that length will satisfy the requirement. If that condition holds then the number of these pairs are added to the result. The number of possible pairs here is k * (k -1) / 2, where k is the number of quotes of this length. For example if there 2 quotes then the number of such pairs will be 1, if there are 3 then the total number of pairs is 3, if there are 4 quotes then the total number of possible pairs is 6 for 5 it is 10 and so on. If you generalize for k then this comes out to be (k * (k-1) )/2.

After this the next step is to look for all possible pairs that can be formed by combining that lenght quote with all other lengths in the dictionary. To do this I iterate through all the lengths more than that length that can make a possible pair. If such a length is found then the result is incremented by the possible pairs that can be formed by these two length quotes. Here the possible number of pairs is the multiplication of the number of quotes of both lengths.

The runtime for this algorithm is O(K^2)where K is the given input size which will be constant in this case so this reduces to O(1). It takes O(n) to setup the initial data structure.

## Quote Pairs Unit Test
I have used XUnit framework to add unit tests to the QuoteRepository. I have added unit tests to test the creation and update of the pairs dictionary and getPairs algorithm.
