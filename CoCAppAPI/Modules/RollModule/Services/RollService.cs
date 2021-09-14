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
        List<RollResponse> GetRoll(List<RollRequest> roll);
    }

    public class RollService : IRollService
    {
        public RollResponse GetRoll(RollRequest roll)
        {
            Random rnd = new Random();
            RollResponse response = new RollResponse();
            for(int i = 0;i<roll.Amount;i++)
            {
                response.Values.Add(rnd.Next(1, roll.Dice+1));
            }
            response.Summary = response.Values.Sum()+roll.Static;
            return response;
        }

        public List<RollResponse> GetRoll(List<RollRequest> rolls)
        {
            List<RollResponse> response = new List<RollResponse>();
            foreach (var item in rolls)
            {
                response.Add(GetRoll(item));
            }
            return response;
        }
    }
}