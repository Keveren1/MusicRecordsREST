using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicRecordsREST.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicRecordsREST.Models;

namespace MusicRecordsREST.Manager.Tests
{
    [TestClass()]
    public class MusicRecordManagerTests
    {
        private MusicRecordManager _recordManager;
        [TestInitialize()]
        public void SetUp()
        {
            _recordManager = new MusicRecordManager();
        }
        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_recordManager.GetAll(null, null, null, null));
        }
    }
}