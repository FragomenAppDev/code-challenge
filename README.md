# Fragomen Code Challenge

## Overview

This is a starting point for the code you will be writing before your Fragomen Technical Interview. The goal is to show off what you can do. Be creative! There is a specific problem to solve, but you are welcome to play around with it and add things that we didn't ask for. The code provided is intentionally bare bones and has very little to it other than to outline the problem. Feel free to use any development tools you want, and reference publicly available libraries if you choose. FYI, we use Visual Studio Code!

Your code will be shared among the team here, and we'll review it together during the in-person interview.

Provide us your completed code challenge by creating a new branch in this repo. Use your first name and the first initial of your last name to name the branch (eg. saraht, johns).

## The Problem

You are being asked to implement a Web API that lets you manage an archive that stores notable quotations. At minimum, you will need to be able to perform basic CRUD (Create, Read, Update, Delete) operations on Quotes. 

In the QuotesController, stubs have been created for you that will do just that. They just need to be implemented, which should be straightforward since there is a basic implementation of a QuoteRepository you may use which simply reads and writes the data in bulk to or from a Json file. More on that later.

However the main problem is that you've also received a requirement that you need to also provide an additional route that will find the number of pairs of Quotes in your archive that will fit into a text field of a given length. More formally,

Input: A numeric value representing a length of characters in a string
Expected result: The total number of unique pairs of Quotes in your archive that satisfy the following condition:
> Two quotes qualify if the sum of the length of the text of the two quotes is less than or equal to the provided input.

There is no stub for this route in the QuotesController right now, so this is entirely up to you. You can use the existing data access methods from the repository or write new ones if you think you need to.

## Additional Considerations

### The Quotes Repository (Data Access Layer)

As mentioned, the repository provided is very basic. It reads and writes Json from a text file. At Fragomen, for the projects that we'll be working on going forward, we're using Couchbase as our data store, which is a document store that works with Json documents. If you wanted to try to reference the .NET Couchbase API to instead read or write to a Couchbase bucket, feel free to write your own data layer that does just that. 

We really don't expect that though; the text files can easily be sufficient to code this up if you work on it.

So in other words, you can also try to optimize the data access methods already present. For instance, all the write operations currently read the entire file into memory, modify the collection, and write them back. Feel free to make it more efficient. You are welcome to change anything about the data layer, including storing additional data, possibly to a separate file. 

### Scaling

The provided archive, ShortDb.json, only has a few entries in it. Naturally, any algorithm that solves the problem will work on it. However, we've also provided a second file, LargeDb.json, that contains many more entries already present in the archive. Inefficient code won't handle this well. See if you can still handle this larger file.

If you end up generating any metadata for the provided files, please also provide your code for how this was generated even if that code is separate from the Web API.

### Framework level stuff (e.g. Logging, Exception Handling, Configuration)

This is again intentionally bare bones and you are welcome to implement as much or as little as you want. There's no need to make this production ready, but maybe be prepared to talk about these considerations in person.

### Testing

It would be helpful, but not required, to provide some form of unit test(s) or integration test(s) to prove that your code works.

### New Features

If you want to show off your skills in a different area, feel free to create your own features and implement them! 

One idea could be:

Create a Person object, and replace the Author field of the Quote object with a reference to a Person. Then provide CRUD operations to manage People.

## Sample Inputs

With the provided ShortDb.json, here's a few sample inputs and outputs for the new route that should be created:

* Input: 19, Output: 0
* Input: 22, Output: 1
* Input: 32, Output: 6
* Input: 40, Output: 7
* Input: 200, Output: 21
