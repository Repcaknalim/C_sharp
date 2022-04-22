using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesObj
{
    class Adrian
    {
        public GetSecretIngredient MySecretIngredientMethod
        {
            get => AddAdriansSecredIngredient;
        }

        private string AddAdriansSecredIngredient(int amount)
        {
            return $"{amount} ounces of cloves";
        }
    }

    class Harper
    {
        private int total = 20;

        public GetSecretIngredient HarpersSecretIngredientMethod
        {
            get => AddHarpersSecredIngredient;
        }

        private string AddHarpersSecredIngredient(int amount)
        {
            if (total - amount < 0)
                return $"I don't have {amount} cans of sardines!";
            else
            {
                total -= amount;
                return $"{amount} cans of sardines";
            }
        }
    }
}
