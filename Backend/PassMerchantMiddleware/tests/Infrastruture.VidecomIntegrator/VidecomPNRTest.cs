using Microsoft.Extensions.Logging;
using SharedKernel.Utility;
using VidcomIntegrator.PNRService.Model;
using Xunit;

namespace Infrastruture.Videcom;


public class VideComPnrTest
{
    [Fact]
    void CanDecodeXML()
    {
        string str =
            @"&lt;PNR RLOC='ZZZJK6' GoldenOSIActive='False' PNRLocked='False' PNRLockedReason='' SecureFlight='False' sfpddob='N' sfpdgndr='N' NeedFG='False' NeedFSM='False' showFares='True' editFlights='False' editProducts='False' editPNR='True' brandid='' lang='' CanVoid='False' VoidCutoffTime=''&gt;
  &lt;Names&gt;
    &lt;PAX GrpNo='1' GrpPaxNo='1' PaxNo='1' Title='MR' FirstName='KALABASH' Surname='TESTIAIN' PaxType='AD' Age='' awards='0'/&gt;
  &lt;/Names&gt;
  &lt;Itinerary&gt;
    &lt;Itin Line='1' AirID='P4' FltNo='7122' Class='V' DepDate='2022-08-31' Depart='LOS' Arrive='ABV' Status='HK' PaxQty='1' DepTime='06:15:00' ArrTime='07:30:00' ArrOfst=' ' ddaygmt='2022-08-31' dtimgmt='05:15:00' adaygmt='2022-08-31' atimgmt='06:30:00' Stops='0' Cabin='Y' GDSID='' GDSRLoc='' DMap='' AMap='' SecID='' SecRLoc='' MSL='' Hosted='1' nostop='' cnx='' ClassBand='ECONOMY FLEXI DOMESTIC' ClassBandDisplayName='Economy Flexi Domestic' onlineCheckin='False' onlineCheckinComment='' OperatedBy='' OAWebsite='' SelectSeat='True' MMBSelectSeat='True' OpenSeating='False' MMBCheckinAllowed='False'/&gt;
  &lt;/Itinerary&gt;
  &lt;MPS/&gt;
  &lt;Contacts&gt;
    &lt;CTC Line='1' CTCID='E' Pax=''&gt;OYEDEJI@WAKANOW.COM&lt;/CTC&gt;
  &lt;/Contacts&gt;
  &lt;APFAX/&gt;
  &lt;GenFax/&gt;
  &lt;ZDISC/&gt;
  &lt;FareQuote&gt;
    &lt;FQItin Seg='1' Cur='NGN' CurInf='2,100,100' FQI='SITI 2789' FQB='VVOW' Total='27500' Fare='9400.00' Tax1='18100.00' Tax2='0' Tax3='0' miles='25000'/&gt;
    &lt;FareStore FSID='FQC' Pax='1' Cur='NGN' CurInf='2,100,100' Total='27500.00'&gt;
      &lt;SegmentFS SegFSID='' Seg='1' Fare='9400.00' Tax1='18100.00' Tax2='0' Tax3='0' miles='25000' disc='0' HoldPcs='1' HoldWt='20K' HandWt='6K'/&gt;
    &lt;/FareStore&gt;
    &lt;FareStore FSID='Total' Pax='' Cur='NGN' CurInf='2,100,100' Total='27500.00'/&gt;
    &lt;FareTax&gt;
      &lt;PaxTax Seg='1' Pax='1' Code='QT' Cur='NGN' Amnt='2000.00' CurInf='2,100,100' desc='AIRPORT SERVICE CHARGE' separate='false'/&gt;
      &lt;PaxTax Seg='1' Pax='1' Code='YQ' Cur='NGN' Amnt='15500.00' CurInf='2,100,100' desc='FUEL CHARGES' separate='false'/&gt;
      &lt;PaxTax Seg='1' Pax='1' Code='NG' Cur='NGN' Amnt='600.00' CurInf='2,100,100' desc='SALES TAX' separate='false'/&gt;
    &lt;/FareTax&gt;
    &lt;AirMiles Miles='25000' Money='18100'/&gt;
  &lt;/FareQuote&gt;
  &lt;Payments/&gt;
  &lt;TimeLimits&gt;
    &lt;TTL TTLID='TLC' TTLCity='LOS' TTLQNo='===' TTLTime='10:24:00' TTLDate='2022-08-04' AgCity='LOS' SineCode='TL' SineType='RC' ResDate='01AUG'/&gt;
  &lt;/TimeLimits&gt;
  &lt;Tickets/&gt;
  &lt;Remarks&gt;
    &lt;RMK Line='1' RMKID=''&gt;ZPAYREF: [KALABASH 707017737979]&lt;/RMK&gt;
  &lt;/Remarks&gt;
  &lt;TourOp/&gt;
  &lt;RLE RLOC='ZZZJK6' AirID='P4' IssOffCode='IBOH' City='LOS' AgType='A' Cur='NGN' CurInf='2,100,100' SineCode='TL' RLEDate='2022-08-01T10:24:17' issagtidpnr='ISB' issagtidtkt='' PIN='' brandid=''/&gt;
  &lt;Basket&gt;
    &lt;Outstanding cur='NGN' CurInf='2,100,100' amount='27500' info='Amount outstanding'/&gt;
    &lt;Outstandingairmiles cur='NGN' CurInf='2,100,100' amount='18100.00' info='Outstanding Currency and Airmiles' airmiles='25000'/&gt;
  &lt;/Basket&gt;
  &lt;zpay scheme='Kalabash' reference='707017737979' info='' mbamount='27500.00' mbcurrency='NGN' mbtotalfare='' mbtotaltax='' ttl='04Aug22 10:24 (LOS)'/&gt;
  &lt;pnrfields originissoffcode='IBOH'/&gt;
  &lt;fqfields&gt;
    &lt;fqfield line='1' fareid='2789' finf='0,0,1'/&gt;
  &lt;/fqfields&gt;
&lt;/PNR&gt;";
        var decoded = XmlUtil.DecodeXML(str);
        var model = XmlUtil.DeserializePNRXml<PNR>(decoded);
        Assert.IsType<PNR>(model.record);
        Assert.NotNull(model.record);
        Assert.NotEmpty(model.record.Itinerary.Itin.DepDate);
    }
}