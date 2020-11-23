using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLib;
using System.Reflection;
using System;

namespace BrowserUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Method1()
        {
        }

        public string Property1 { get; set; }
        private byte _field1;

        public class Class1
        {
            private int one;
            void Two()
            { 
            
            }
        }

        public class Class2
        { 
        
        }

        public class Class3
        {
            public int DoSmt() { return 0; }
        }

        private void Setup()
        {
            var info = new AssemblyBrowserLib.TypeInfo(typeof(Class2));
            info.Members[0].ToString();
        }

        [TestMethod]
        public void TestMethodInfo()
        {
            TypeMemberInfo info = new TypeMemberInfo(typeof(UnitTest1).GetMember("Method1")[0]);
            Assert.AreEqual("Method Method1()", info.Info);
        }

        [TestMethod]
        public void TestFieldInfo()
        {
            TypeMemberInfo info = new TypeMemberInfo(typeof(UnitTest1).GetField("_field1", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.AreEqual("Field System.Byte _field1", info.Info);
        }

        [TestMethod]
        public void TestPropertyInfo()
        {
            TypeMemberInfo info = new TypeMemberInfo(typeof(UnitTest1).GetProperty("Property1"));
            Assert.AreEqual("Property System.String Property1", info.Info);
        }

        [TestMethod]
        public void TestClassInfo()
        {
            var info = new AssemblyBrowserLib.TypeInfo(typeof(Class1));
            Assert.AreEqual(2, info.Members.Count);
        }

        [TestMethod]
        public void TestEmptyClassInfo()
        {           
            Assert.ThrowsException<ArgumentOutOfRangeException>(Setup);
        }

        [TestMethod]
        public void TestTypeInfo()
        {
            var info = new AssemblyBrowserLib.TypeInfo(typeof(Class1));
            Assert.AreEqual("Field System.Int32 one", info.Members[1].Info);
        }

        [TestMethod]
        public void TestMethodInClass()
        {
            var info = new AssemblyBrowserLib.TypeInfo(typeof(Class3));
            var methodInfo = new TypeMemberInfo(typeof(Class3).GetMember("DoSmt")[0]); 
            Assert.AreEqual(info.Members[0].Info, methodInfo.Info);
        }
    }
}
