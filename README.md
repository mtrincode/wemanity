## Wemanity
Gilded Rose Refactoring Kata

# Usage Instructions

Source code is in C# targeting .NET Framework 4.8 and it doesn't make use of any external libraries. MSTest was used to write unit tests.

# Architecture Design Notes

1. An adjusted strategy pattern design was used to implement the items quality update. Neither Item.cs nor the client Console App were touched, so the Goblin won't get angry.

2. Switched to MSTest which is my 2nd favorite unit testing framework after xUnit. MSTest simply fit better in this simple app.

3. Now it throws an exception for items with negative SellIn. It was not explicit on the requirements, but common sense tells me that creating an item with a deadline to be sold until yesterday is wrong.

4. In a real world scenario, I would wrap Item.cs so I could add a **Category** property which would be used to select the right quality strategy, but for simplicity sake, the item description was used for that.

5. I considered using StandardItem.cs as the base class, but it's more loosely coupled having it inheriting from a base class.

6. I know that we should favor composition over inheritance, but there's common implementation in the base class that helped to keep it **DRY**.
