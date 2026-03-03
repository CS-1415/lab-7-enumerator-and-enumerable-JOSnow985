namespace Lab06.Tests;

public class TwoTests
{
    DoublyLinkedList<int> testList;
    
    // Initializes a list with two items
    [SetUp]
    public void Setup()
    {
        testList = new();
        testList.AddFirst(42);
        testList.AddFirst(20);
    }

    [Test]
    public void RemoveFrontBackToEmptyTest()
    {
        testList.RemoveFirst();
        testList.RemoveLast();
        Assert.Multiple(() =>
        {
            Assert.That(testList.Length, Is.EqualTo(0));
            Assert.Throws<InvalidOperationException>(() => _ = testList.First);
            Assert.Throws<InvalidOperationException>(() => _ = testList.Last);
        });
    }
}