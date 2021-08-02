using RollModule.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RollModule.Services
{
    public interface IRollService
    {
        RollResponse GetRoll(RollRequest roll);
    }

    public class RollService : IRollService
    {
        public RollResponse GetRoll(RollRequest roll)
        {
            Random rnd = new Random();
            RollResponse response = new RollResponse();
            for(int i = 0;i<roll.Amount;i++)
            {
                response.Values.Add(rnd.Next(1, roll.Dice));
            }
            response.Summary = response.Values.Sum()+roll.Static;
            return response;
        }
    }
}
