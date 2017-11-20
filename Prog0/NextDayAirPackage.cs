//Grading ID: D2575
//Program 1A
//Due 10/11/26
//Section 76
/* This class creates NextDayAirPackages using AirPackage as the base.
 * It also has a new property called expressFee that is added to the base cost of shipping the package.
 * On top of an express fee, the CalcCost here can have additional charges if the package is Heavy or if it is Large.
 * The ToString method also returns all properties and methods to a string.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NextDayAirPackage : AirPackage
{
    private const double LWH_MULT = .4;
    private const double WEIGHT_MULT = .3;
    private const decimal HEAVY_MULT = .25m;
    private const decimal LARGE_MULT = .25m;
    //backing fields
    decimal _expressFee;
    //constructor
    //precondition: 
    //height > 0
    //length > 0
    //width > 0
    //weight > 0
    //expressFee >= 0
    //postcondition: creates a next day air package with the height, length, width, weight, originAddress
    //destAddress, and express fee specified in the constructor.
    public NextDayAirPackage(decimal expressFee, double height, double width, double length,
        double weight, Address originAddress, Address destAddress)
        : base(height, width, length, weight, originAddress, destAddress)
    {
        _expressFee = expressFee;
    }
    //properties
    //precondition: none
    //postcondition: returns the express fee specified during the construction of the object
    private decimal ExpressFee //CAN USE PUBLIC SET
    {
        //precondition: none
        //postcondition: returns express fee of the package
        get { return _expressFee; }
    }

    //methods

    //precondition: none
    //postcondition: 
    public override decimal CalcCost()
    {
        decimal cost = (decimal)(LWH_MULT * (Length + Width + Height) + (WEIGHT_MULT * Weight)) + ExpressFee; //GET RID OF MAGIC NUMBERS!!!!!
        if (IsHeavy() == true)
        { cost += (HEAVY_MULT * (decimal)Weight); }
        if (IsLarge() == true)
        { cost += (LARGE_MULT * (decimal)(Length + Width + Height)); }
        return cost;
    }

    //precondition
    //postcondition
    public override string ToString()
    {
        return string.Format("{0}Express Fee: {1:C}", base.ToString(), ExpressFee);
    }

}
