using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;



namespace ACM.BLTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValid()
        {
            //Arrage
            var customer = new Customer();
            var goalSteps = "5000";
            var actualSteps = "2000";
            var expected = 40M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidAndSame()
        {
            //Arrage
            var customer = new Customer();
            var goalSteps = "5000";
            var actualSteps = "5000";
            var expected = 100M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidActuaIsZero()
        {
            //Arrage
            var customer = new Customer();
            var goalSteps = "5000";
            var actualSteps = "0";
            var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatGoalIsNull()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = null;
            var actualSteps = "2000";
            //var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatGoalIsEmpty()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = "";
            var actualSteps = "2000";
            //var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatGoalIsSpace()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = " ";
            var actualSteps = "2000";
            //var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatGoalIsNotNumeric()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = "one";
            var actualSteps = "2000";
            

            //Act
            try
            {
                var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Goal must be numeric!", ex.Message);
               
                throw; //reikia palikti throw nes nevykdytu ExpecteException salygos
            }
            

            //Assert


        }

        





        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatActualIsNull()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = null;
            //var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatActualIsEmpty()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = "5000";
            var actualSteps = "";
            //var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatActualIsSpace()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = "5000";
            var actualSteps = " ";
            //var expected = 0M;

            //Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTeatActualIsNotNumeric()
        {
            //Arrage
            var customer = new Customer();
            string goalSteps = "500";
            var actualSteps = "one";


            //Act
            try
            {
                var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Actual must be numeric!", ex.Message);

                throw; //reikia palikti throw nes nevykdytu ExpecteException salygos
            }


            //Assert


        }
       

        //[TestMethod()]
        //public void CalculatePercentOfGoalStepsTest()
        //{
        //    Assert.Fail();
        //}
    }
}
