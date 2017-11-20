//Grading ID: D2575
//Program 1A
//Due 10/11/26
//Section 76
/* This is a class used to create concrete GroundPackage objects, which uses the Package class as it's base. 
 * The GroundPackage class has a new property called ZoneDist, which is used to determine the distance between the first digit of the
 * origin and destination addresses. This class also has a CalcCost method that uses the dimensions of the packages and the 
 * distance between the zip codes to provide the cost of shipping the package.
 * This class also has a ToString method that returns all properties and the cost to a string.
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GroundPackage : Package
{
    //constants
    private const double LWH_MULT = .20;
    private const double ZONE_DIST_MULT = .05;
    private const byte ZONE_DIST_ADD = 1;

    //constructor
    //precondition:
    //height > 0
    //length > 0
    //width > 0
    //weight > 0 
    //postcondition: creates a ground package with the height, length, width, weight, originAddress
    //and destAddress specified in the constructor.
    public GroundPackage(double height, double length, double width, double weight,
        Address originAddress, Address destAddress)
        : base(height, width, length, weight, originAddress, destAddress)
    {

    }

    //properties

    //precondition: none
    //postcondition: returns the distance between the first digit of the originAddress zip and 
    //the destAddress zip
    public int ZoneDist
    {
        //precondition: none
        //postcondition: returns the distance between the first digit of the originAddress zip and 
        //the destAddress zip
        get
        {
            const int FIRST_ZIP_FACTOR = 10000;
            int dist;

            dist = Math.Abs((OriginAddress.Zip / FIRST_ZIP_FACTOR) - (DestinationAddress.Zip / FIRST_ZIP_FACTOR));
            return dist;
        }
    }

    //CalcCost = .2*(L + Width + H) + .05*(ZoneDist + 1) * weight
    //precondition: none
    //postcondition: the ground package's cost has been returned.
    public override decimal CalcCost()
    {
        return (decimal)(LWH_MULT * (Length + Width + Height) + ZONE_DIST_MULT * (ZoneDist + ZONE_DIST_ADD) * Weight);
    }

    //precondition: none
    //postcondition: the base class properties and the zonedistance are returned as a string.
    public override string ToString()
    {
        return string.Format("{0},\nZone distance: {1}", base.ToString(), ZoneDist);
    }
}