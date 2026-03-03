namespace Lab06.Tests;

public class ThreeTests
{
    DoublyLinkedList<int> testList;

    // Initializes a list with three items
    [SetUp]
    public void Setup()
    {
        testList = new();
        testList.AddFirst(42);
        testList.AddFirst(36);
        testList.AddFirst(30);
    }

    [Test]
    public void ReverseTest()
    {
        testList.ReverseList();
        Assert.Multiple(() =>
        {
            Assert.That(testList.First, Is.EqualTo(42));
            Assert.That(testList.Last, Is.EqualTo(30));
        });
    }
}