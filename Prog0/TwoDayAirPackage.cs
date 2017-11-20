//Grading ID: D2575
//Program 1A
//Due 10/11/26
//Section 76
/* This class creates TwoDayAirPackages using AirPackage as the base.
 * This class has two delivery types, earyl and saver. If saver is chosen, there is a discount in the cost of shipping.
 * There is also a ToString that returns all the properties and methods to a string.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TwoDayAirPackage : AirPackage
{
    public enum Delivery : byte { Early, Saver };
    private Delivery _deliveryType;
    private const double LWH_MULT = .25;
    private const double WEIGHT_MULT = .25;
    private const decimal SAVER_MULT = .9m;

    //constructor
    //precondition: 
    //height > 0
    //length > 0
    //width > 0
    //weight > 0 
    //deliveryType must be 0 or 1
    //postcondition: creates an air package with the deliveryType, height, length, width, weight, originAddress
    //and destAddress specified in the constructor.
    public TwoDayAirPackage(double length, double width, double height,
        double weight, Address originAddress, Address destAddress, Delivery deliveryType)
        : base(length, width, height, weight, originAddress, destAddress)
    {
        DeliveryType = deliveryType;
    }
    //properties

    //precondition:DeliveryType must be Saver or Early
    //postcondition: the DeliveryType will be set to either early or saver and returned when the get method is used.
    public Delivery DeliveryType
    {
        //precondition: none
        //postcondition: returns deliveryType
        get { return _deliveryType; }
        //precondition: deliverType must be either Saver or Early
        //postcondition: the deliveryType will be set to either Early or Saver
        set
        {
            if (value == Delivery.Saver)
            { _deliveryType = Delivery.Saver; }
            else if (value == Delivery.Early)
            { _deliveryType = Delivery.Early; }
            else { throw new ArgumentOutOfRangeException("Please select Early or Saver for this package."); }
        }
    }
    //methods
    // .25*(l+w+h) + (.25*weight), if Saver, multiply all of that by .9
    //precondition: none
    //postcondition: returns the cost of shipping a two day airpackage
    public override decimal CalcCost()
    {
        decimal cost = (decimal)(LWH_MULT * (Length + Width + Height) + (WEIGHT_MULT * Weight)); //GET RID OF MAGIC NUMBERS!!!
        if (DeliveryType == Delivery.Saver)
        { cost = cost * SAVER_MULT; }
        return cost;
    }

    //precondition: none
    //postcondition: returns the base classe properties and methods, as well as the delivery type to a string.
    public override string ToString()
    {
        return string.Format("{0}\nDelivery Type: {1}", base.ToString(), DeliveryType);
    }
}
