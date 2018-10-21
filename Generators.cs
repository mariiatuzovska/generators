﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    partial class Sequence 
    {
        public void rand()
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                number[i] = (byte)rand.Next(0, 2);
            }
        }

        public void rand(int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                number[i] = (byte)rand.Next(0, 2);
            }
        }

        public void LCG(string key)
        {
            Hex m = new Hex("100000000");
            Hex a = new Hex("10001");
            Hex c = new Hex("77");
            Hex x = new Hex(); Hex temp_1 = new Hex(); Hex temp_2 = new Hex();
            x.rand(900);

            if (key == "low")
            {
                for (int i = 0; i < size / 8; i++)
                {
                    temp_1.mul(a, x, temp_1);
                    temp_2.sum(temp_1, c, temp_2);
                    x.mod(temp_2, m, x);
                    for (int j = 0; j < 8; j++)
                    {
                        number[i * 8 + j] = (byte)x.number[j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < size / 8; i++)
                {
                    temp_1.mul(a, x, temp_1);
                    temp_2.sum(temp_1, c, temp_2);
                    x.mod(temp_2, m, x);
                    for (int j = 0; j < 8; j++)
                    {
                        number[i * 8 + j] = (byte)x.number[x.length() - j];
                    }
                }
            }
        }
    
        public void L20()
        {
            int t = 21;
            rand(21);
            for (t = 21;  t < size; t++) { number[t] = (byte)(number[t - 3] ^ number[t - 5] ^ number[t - 20]); t++; }
        }

        public void L89()
        {
            int t = 89;
            rand(89);
            while (t < size) { number[t] = (byte)(number[t - 38] ^ number[t - 89]); t++; }
        }

        public void Geffe()
        {
            Sequence L1 = new Sequence(size);
            Sequence L2 = new Sequence(size);
            Sequence L3 = new Sequence(size);
            L1.rand();
            L2.rand();
            L3.rand();
            for (int i = 0; i < size; i++)
            {
                number[i] = (byte)((L3[i] & L1[i]) ^ ((1 ^ L3[i]) & L2[i]));
            }
        }

        

    }
}
