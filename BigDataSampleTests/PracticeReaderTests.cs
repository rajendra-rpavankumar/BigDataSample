using AFTaskModel.Model;
using AFTaskService.Interface;
using AFTaskService.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDataSampleTests
{
    [TestFixture]
    public class PracticeReaderTests
    {
        private IPracticeReader lineReader;

        [SetUp]
        public void SetUp()
        {
            this.lineReader = new PracticeReader();
        }

        [Test]
        public void ReadPracticeFromCsvReturnCorrectData()
        {
            string filepath = "Practice_Test1.csv";
            //201202,A81001,THE DENSHAM SURGERY ,THE HEALTH CENTRE ,LAWSON STREET,STOCKTON ,CLEVELAND,TS18 1HU



            var practice = new Practices();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    practice = lineReader.ExtractPractices(line);
                }
            }
            Assert.That(practice.ReferencePrac, Is.EqualTo("A81001"));
            Assert.That(practice.PracticeName, Is.EqualTo("THE DENSHAM SURGERY"));
            Assert.That(practice.PostCode, Is.EqualTo("TS18 1HU"));

        }

        [Test]
        public void ReadPracticeFromCsvReturnWrongData()
        {
            string filepath = "Practice_Test2.csv";
            //201202,A81001,THE DENSHAM SURGERY ,THE HEALTH CENTRE ,LAWSON STREET,STOCKTON ,CLEVELAND,TS18 1HU



            var practice = new Practices();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    practice = lineReader.ExtractPractices(line);
                }
            }
            Assert.That(practice.ReferencePrac, Is.EqualTo("A81001"));
            Assert.That(practice.PracticeName, Is.EqualTo("THE DENSHAM SURGERY"));
            Assert.That(practice.PostCode, Is.EqualTo("TS18 1HU"));

        }
    }
}
