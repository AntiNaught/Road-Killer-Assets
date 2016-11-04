public class RF_Config  {

    //转速表可以显示的最大速度
    public const float maxSpeed=50;


    //event keys
    public struct events
    {
        public const string oilStain="oilstain";
        public const string useUpFuel="useupfuel";
        public const string addFuel="addfuel";
        public const string carPlayerExplode="carplayerexplode";
        public const string hugeFriction="hugefriction";
    }

    public  struct GasStationPosition
    {
        //Y方向的坐标
        const float position1=400;

        const float position2=800;

        const float position3=1200;
    }
}
