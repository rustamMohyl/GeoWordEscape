using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CityCountryRandom
{
    private string[] cityAndCountries = {
        "argentina",
        "tanzania",
        "palau",
        "mozambique",
        "guatemala", 
        "sanmarino",
        "losangeles",
        "kyiv",
        "andorralavella",
        "minsk",
        "rome",
        "lisbon",
        "tokyo",
        "seol",
        "budapest",
        "newyork",
        "boston",
        "zurich"};

        public string GetRandomCityOrCountry() 
        {
            System.Random rnd = new  System.Random();
            int index  = rnd.Next(0, cityAndCountries.Length - 1);
            return cityAndCountries[index];
        }
}
