using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        

        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered!", "goalSteps");
            if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual must be entered!", "actualSteps");

            //localus kintamieji turetu but kuo arciau kur ju reikia
            //labai svarbus vardai kad butu tikslus ir nuoseklus  camelCase
            //geriausia kur deklaruojama ten ir initialize
            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric!");
            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual must be numeric!");
            
            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);


            /* decimal result = 0;
            decimal goalStepCount = 0;
            decimal.TryParse(goalSteps, out goalStepCount);

            decimal actualStepCount = 0;
            decimal.TryParse(actualSteps, out actualStepCount);

            if (goalStepCount>0)
            {
                result = (actualStepCount / goalStepCount) * 100;
            }
            return result;*/

        }

        public decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0) throw new ArgumentException("Goal must be greater thar 0", "goalSteps");
            return Math.Round((actualStepCount/goalStepCount)*100, 2);
        }



        public OperationResult ValidateEmail()
        {
            //var valid = true;
            //Tuple<bool, string> result = Tuple.Create(true, "");

            var result = new OperationResult();
            //kai returninam multiple values geriausiai naudoti custom class
            

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                //valid = false;
                //message = "Email is null";
                //result = Tuple.Create(false, "Email is null");
                //throw new ArgumentException("Email is null");

                result.Success = false;
                result.AddMessage("Email is null Aidai");
            }

            if (result.Success)
            {
                var isValidForm = true;

                //cia reiktu kodo kuris validuotu formata nadojant regular exprssions

                if (!isValidForm)
                {
                    //valid = false;
                    //message = "Email is not in correct format";
                    //result = Tuple.Create(false, "Email is not in correct format");
                    //throw new ArgumentException("Email is not in correct format");

                    result.Success = false;
                    result.AddMessage("Email is not in correct format");
                }
            }

            if (result.Success)
            {
                var isRealDomain = true;
                //cia reiktu kodo kuris patvirtintu ar domenas ekzistuja

                if (!isRealDomain)
                {
                    //valid = false;
                    //message = "Email domain does not exist";
                    //result = Tuple.Create(false, "Email domain does not exist")
                    //throw new ArgumentException("Email domain does not exist");

                    result.Success = false;
                    result.AddMessage("Email is not in correct format");
                }
            }

            return result;
        }
    }
}
