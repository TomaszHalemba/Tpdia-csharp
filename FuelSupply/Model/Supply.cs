using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Model
{
    class Supply
    {
        private int id;
        private int stationId;
        private int tankId;
        private String fuelType;
        private int tankCapacity;
        private DateTime startTime;
        private DateTime endTime;
        private int truckId;
        private int driverId;
        private int terminalId;

        private int detectedSupplyCapacity;
        private int detectedSupplyCapacityNet;

        private int declaredSupplyCapacity;
        private int declaredSupplyCapacityNet;

        private int tankStartHeight;
        private int tankEndHeight;


        private double VarBasedOnDetected;
        private double VarBasedOnDetectedNet;
        private double VarBasedOnHeight;
        private double VarBasedOnHeightNet;

        private bool possibleLeak;
        private bool possibleDetectorError;
        private bool excess;


        readonly Double tolerance = 0.05;
   
    
    /**
     * Default constructor
     */
    public Supply(int id)
        {
            this.id = id;
        }





        /**
         * Obliczanie var na podstawie wykrytej objÄ™toĹ›ci dostawy
         */
        public void calculateVarBasedOnDetected()
        {
            try
            {

                VarBasedOnDetected = declaredSupplyCapacity - detectedSupplyCapacity;

            }
            catch (Exception e)
            {

            }
        }

        /**
         * Obliczanie var na podstawie wykrytej objÄ™toĹ›ci dostawy przeskalowanej do temperatury referencyjnej
         */
        public void calculateVarBasedOnDetectedNet()
        {
            try
            {
                VarBasedOnDetectedNet = declaredSupplyCapacityNet - detectedSupplyCapacityNet;

            }
            catch (Exception e)
            {

            }
        }

        /**
         * Obliczanie var na podstawie objÄ™toĹ›ci dostawy obliczonej za pomocÄ… pomiarĂłw wysokoĹ›ci
         */
        public void calculateVarBasedOnHeight()//coďż˝ na stacji sie dziaďż˝o
        {
            try
            {
                // stare
                //VarBasedOnHeight = (tankCapacity * tankEndHeight / 100.0) - (tankCapacity * tankStartHeight / 100.0) - detectedSupplyCapacity;

                // obliczenie objetosci dostawy na podstawie otrzymanych wysokoĹ›ci
                double supplyCapacityBasedOnHeight = (tankCapacity * tankEndHeight / 100.0) - (tankCapacity * tankStartHeight / 100.0);

                // obliczenie varu
                VarBasedOnHeight = this.declaredSupplyCapacity - supplyCapacityBasedOnHeight;



            }
            catch (Exception e)
            {

            }
        }

        /**
         * Obliczanie var na podstawie objÄ™toĹ›ci dostawy obliczonej za pomocÄ… pomiarĂłw wysokoĹ›ci do zadeklarowanej przeskalowanej do temperatury referencyjnej
         */
        public void calculateVarBasedOnHeightNet()//coďż˝ na stacji sie dziaďż˝o
        {
            try
            {
                // stare
                //VarBasedOnHeight = (tankCapacity * tankEndHeight / 100.0) - (tankCapacity * tankStartHeight / 100.0) - detectedSupplyCapacity;

                // obliczenie objetosci dostawy na podstawie otrzymanych wysokoĹ›ci
                double supplyCapacityBasedOnHeight = (tankCapacity * tankEndHeight / 100.0) - (tankCapacity * tankStartHeight / 100.0);

                // obliczenie varu
                VarBasedOnHeightNet = this.declaredSupplyCapacityNet - supplyCapacityBasedOnHeight;



            }
            catch (Exception e)
            {

            }
        }

        public Supply(String inputStreamLine)
        {
            this.decodeTextLine(inputStreamLine);
        }

        private void decodeTextLine(String inputStreamLine)
        {

        }
        public bool isPossibleLeak()
        {
            return possibleLeak;
        }


        public void setPossibleLeak(bool possibleLeak)
        {
            this.possibleLeak = possibleLeak;
        }


        public bool isPossibleDetectorError()
        {
            return possibleDetectorError;
        }


        public void setPossibleDetectorError(bool possibleDetectorError)
        {
            this.possibleDetectorError = possibleDetectorError;
        }





        public double getVarBasedOnDetected()
        {
            return VarBasedOnDetected;
        }


        public void setVarBasedOnDetected(double varBasedOnDetected)
        {
            VarBasedOnDetected = varBasedOnDetected;
        }


        public double getVarBasedOnDetectedNet()
        {
            return VarBasedOnDetectedNet;
        }


        public void setVarBasedOnDetectedNet(double varBasedOnDetectedNet)
        {
            VarBasedOnDetectedNet = varBasedOnDetectedNet;
        }


        public double getVarBasedOnHeightNet()
        {
            return VarBasedOnHeightNet;
        }


        public void setVarBasedOnHeightNet(double varBasedOnHeightNet)
        {
            VarBasedOnHeightNet = varBasedOnHeightNet;
        }

        public int getId()
        {
            return id;
        }

        public int getStationId()
        {
            return stationId;
        }

        public void setStationId(int stationId)
        {
            this.stationId = stationId;
        }

        public int getTankId()
        {
            return tankId;
        }

        public void setTankId(int tankId)
        {
            this.tankId = tankId;
        }

        public String getFuelType()
        {
            return fuelType;
        }

        public void setFuelType(String fuelType)
        {
            this.fuelType = fuelType;
        }

        public int getTankCapacity()
        {
            return tankCapacity;
        }

        public void setTankCapacity(int tankCapacity)
        {
            this.tankCapacity = tankCapacity;
        }

        public DateTime getStartTime()
        {
            return startTime;
        }

        public void setStartTime(DateTime startTime)
        {
            this.startTime = startTime;
        }

        public DateTime getEndTime()
        {
            return endTime;
        }

        public void setEndTime(DateTime endTime)
        {
            this.endTime = endTime;
        }

        public int getTruckId()
        {
            return truckId;
        }

        public void setTruckId(int truckId)
        {
            this.truckId = truckId;
        }

        public int getDriverId()
        {
            return driverId;
        }

        public void setDriverId(int driverId)
        {
            this.driverId = driverId;
        }

        public int getTerminalId()
        {
            return terminalId;
        }

        public void setTerminalId(int terminalId)
        {
            this.terminalId = terminalId;
        }

        public int getDetectedSupplyCapacity()
        {
            return detectedSupplyCapacity;
        }

        public void setDetectedSupplyCapacity(int detectedSupplyCapacity)
        {
            this.detectedSupplyCapacity = detectedSupplyCapacity;
        }

        public int getDetectedSupplyCapacityNet()
        {
            return detectedSupplyCapacityNet;
        }

        public void setDetectedSupplyCapacityNet(int detectedSupplyCapacityNet)
        {
            this.detectedSupplyCapacityNet = detectedSupplyCapacityNet;
        }

        public int getDeclaredSupplyCapacity()
        {
            return declaredSupplyCapacity;
        }

        public void setDeclaredSupplyCapacity(int declaredSupplyCapacity)
        {
            this.declaredSupplyCapacity = declaredSupplyCapacity;
        }

        public int getDeclaredSupplyCapacityNet()
        {
            return declaredSupplyCapacityNet;
        }

        public void setDeclaredSupplyCapacityNet(int declaredSupplyCapacityNet)
        {
            this.declaredSupplyCapacityNet = declaredSupplyCapacityNet;
        }

        public int getTankStartHeight()
        {
            return tankStartHeight;
        }

        public void setTankStartHeight(int tankStartHeight)
        {
            this.tankStartHeight = tankStartHeight;
        }

        public int getTankEndHeight()
        {
            return tankEndHeight;
        }

        public void setTankEndHeight(int tankEndHeight)
        {
            this.tankEndHeight = tankEndHeight;
        }



        public Double getVarBasedOnMeasurment()
        {
            return VarBasedOnDetected;
        }

        public void setVarBasedOnMeasurment(Double var)
        {
            VarBasedOnDetected = var;
        }


        public Double getVarBasedOnHeight()
        {
            return VarBasedOnHeight;
        }


        public void setVarBasedOnHeight(Double varTransport)
        {
            VarBasedOnHeight = varTransport;
        }
    }
}
