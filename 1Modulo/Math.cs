using System;

using System.Collections.Generic;


namespace Codenation.Challenge
{
    public class Math
    {

        public List<int> Fibonacci()
        {

            List<int> retorno = new List<int>() { 0, 1 };

            int ultimapos = 0;

            while (true)
            {

                ultimapos = retorno[retorno.Count - 1] + retorno[retorno.Count - 2];

                if (ultimapos > 350)
                {

                    break;

                }

                retorno.Add(ultimapos);

            }

            return retorno;

        }


        public bool IsFibonacci(int numberToTest)

        {

            return Fibonacci().Contains(numberToTest);

        }

    }

}


