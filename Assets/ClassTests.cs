using UnityEngine;

public class ClassTests : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TestClass class1 = new TestClass(5);
        TestClass class2 = class1;
        class1.Number = 20;
        Debug.Log("Class2 " +class2.Number);

        TestStruct struct1 = new TestStruct(5);
        TestStruct struct2 = struct1;
        struct1.Number = 20;
        Debug.Log("Struct2 " +struct2.Number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class TestClass
{
    public int Number;

    public TestClass(int number)
    {
        Number = number;
    }
}

public struct TestStruct
{
    public int Number;

    public TestStruct(int number)
    {
        Number = number;
    }

    public void DoSomething()
    {

    }
}

