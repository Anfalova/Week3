using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Test
{
    [TestClass]
    public class StorageTest
    {
        Storage repository;
        Example2 ex;
        IEnumerable<KeyValuePair<Guid, Example1>> pairs;
        [TestInitialize()]
        public void Initialize()
        {
            repository = new Storage();
            repository.Create<Example2>();
            repository.Create<Example1>();
            repository.Create<Example1>();
            ex = repository.Create<Example2>();
            pairs = repository.PairType<Example1>();
        }
        [TestMethod]
        public void Create_Return_ObjectType_T()
        {
            Assert.AreEqual(typeof(Example2), ex.GetType());
            Assert.AreEqual("This is an example.", ex.example);
        }
        [TestMethod]
        public void PairType_Return_CorrectPairs()
        {
            foreach (var item in pairs)
            {
                Assert.AreEqual(1, item.Value.example);
                Assert.AreEqual(typeof(Example1), item.Value.GetType());
            }
        }
        [TestMethod]
        public void PairType_Return_RightAmountOfPairs()
        {
            int count = 0;
            foreach (var item in pairs)
                count++;
            Assert.AreEqual(2, count);
        }
        [TestMethod]
        public void PairType_Return_EmptyEnumerable_T_IsNotInTheStorage()
        {
            int i = 0;
            IEnumerable<KeyValuePair<Guid, Storage>> pairs2 = repository.PairType<Storage>();
            foreach (var item in pairs2)
                i++;
            Assert.AreEqual(0, i);
        }
        [TestMethod]
        public void ObjectGuid_CorrectAnswer()
        {
            foreach (var item in pairs)
                Assert.AreEqual(1, repository.ObjectGuid<Example1>(item.Key).example);
        }
        [TestMethod]
        public void ObjectByGuid_Return_Null_Type_T_IsNotTypeOfObject()
        {
            foreach (var item in pairs)
                Assert.AreEqual(null, repository.ObjectGuid<Example2>(item.Key));
        }
        [TestMethod]
        public void ObjectGuid_Return_Null_ID_IsNotCorrect()
        {
            foreach (var item in pairs)
                Assert.AreEqual(null, repository.ObjectGuid<Example2>(Guid.NewGuid()));
        }
    }
}
