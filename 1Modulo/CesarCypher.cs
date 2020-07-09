using System;
using System.Linq;

namespace Codenation.Challenge
{

    public class CesarCypher : ICrypt, IDecrypt
    {

        private static readonly string alfabeto = "abcdefghijklmnopqrstuvwxyz";

        private static readonly int chave = 3;

        public string ProcessaMensagem(string msg, bool ehCifrada)
        {

            if (msg is null)
            {

                throw new ArgumentNullException(nameof(msg));

            }


            int posicao, posicaoAlvo, posicaoProvisoria;

            string decifrado = "";

            msg = msg.ToLower();


            for (int i = 0; i < msg.Length; i++)
            {

                char ch = msg[i];

                char chAlvo;


                if (!alfabeto.Contains(ch))
                {


                    if (char.IsWhiteSpace(ch) || char.IsNumber(ch))
                    {

                        decifrado += ch;

                    }


                    else
                    {

                        throw new ArgumentOutOfRangeException();

                    }

                }

                else
                {

                    posicao = alfabeto.IndexOf(ch);

                    posicaoProvisoria = !ehCifrada ? posicao + chave : posicao - chave;

                    if (posicaoProvisoria >= 0 && posicaoProvisoria < alfabeto.Length)
                    {

                        chAlvo = alfabeto[posicaoProvisoria];

                    }

                    else
                    {

                        posicaoAlvo = !ehCifrada ? posicaoProvisoria - alfabeto.Length : alfabeto.Length + posicaoProvisoria;

                        chAlvo = alfabeto[posicaoAlvo];

                    }

                    decifrado += chAlvo;

                }

            }

            return decifrado;

        }


        public string Crypt(string message)
        {

            return ProcessaMensagem(message, false);

        }


        public string Decrypt(string cryptedMessage)
        {

            return ProcessaMensagem(cryptedMessage, true);

        }


    }

}