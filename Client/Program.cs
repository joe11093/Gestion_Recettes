﻿using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceRecettes serviceProxy = new ChannelFactory<IServiceRecettes>("RecetteServiceConfiguration").CreateChannel();
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
