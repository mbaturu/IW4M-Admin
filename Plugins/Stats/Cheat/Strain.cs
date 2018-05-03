﻿using SharedLibraryCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace IW4MAdmin.Plugins.Stats.Cheat
{
    class Strain
    {
        private static double StrainDecayBase = 0.15;
        private double CurrentStrain;
        private Vector3 LastAngle;

        public double GetStrain(Vector3 newAngle, double deltaTime)
        {
            if (LastAngle == null)
                LastAngle = newAngle;

            double decayFactor = GetDecay(deltaTime);
            CurrentStrain *= decayFactor;

            double[] distance = Helpers.Extensions.AngleStuff(newAngle, LastAngle);

            // this happens on first kill
            if ((distance[0] == 0 && distance[1] == 0) ||
                deltaTime == 0 || 
                double.IsNaN(CurrentStrain))
            {
                return CurrentStrain;
            }

            double newStrain = Math.Pow(distance[0] + distance[1], 0.99) / deltaTime;

            if (newStrain + CurrentStrain > 0.25)
            {
                Console.WriteLine($"{LastAngle}-{newAngle}-{decayFactor}-{CurrentStrain}-{newStrain}-{distance[0]}-{distance[1]}-{deltaTime}");
            }

            CurrentStrain += newStrain;
            LastAngle = newAngle;
         
            return CurrentStrain;
        }
        
        private double GetDecay(double deltaTime) => Math.Pow(StrainDecayBase, deltaTime / 1000.0);
    }
}