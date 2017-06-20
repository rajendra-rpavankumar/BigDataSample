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
    public class PrescriptionReaderTests
    {
        private IPrescriptionReader lineReader;

        [SetUp]
        public void SetUp()
        {
            this.lineReader = new PrescriptionReader();
        }

        [Test]
        public void ReadPrescriptionFromCsvReturnCorrectData()
        {
            string filepath = "Prescription_Test1.csv";
            //Q30,5D7,A86021,0102000T0,Peppermint Oil                          ,0000012,00000088.55,00000081.98,201109                                 


            var prescription = new Prescriptions();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    prescription = lineReader.ExtractPrescriptions(line);
                }
            }
            Assert.That(prescription.PracticeId, Is.EqualTo("A86021"));
            Assert.That(prescription.BNFName, Is.EqualTo("Peppermint Oil"));
            Assert.That(prescription.Items, Is.EqualTo(12));
            //Assert.That(prescription.ActualCost/100, Is.EqualTo(0.8198));

        }

        [Test]
        public void ReadPrescriptionFromCsvReturnWrongData()
        {
            string filepath = "Prescription_Test2.csv";
            //Q30,5D7,A86021,0102000T0,Peppermint Oil                          ,0000012,00000088.55,00000081.98,201109                                 


            var prescription = new Prescriptions();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    prescription = lineReader.ExtractPrescriptions(line);
                }
            }
            Assert.That(prescription.PracticeId, Is.EqualTo("A86021"));
            Assert.That(prescription.BNFName, Is.EqualTo("Peppermint Oil"));
            Assert.That(prescription.Items, Is.EqualTo(0));


        }

    }
}
