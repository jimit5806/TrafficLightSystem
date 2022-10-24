using System;
using System.Web.UI;

namespace TrafficLightSystem
{
    public partial class TrafficLightSystemBonus : System.Web.UI.Page
    {

        /// <summary>
        /// During page load, timer controls will be disable and these timer controls will be enabled on Start button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TimerDisplay.Enabled = false;
                TimerCounter.Enabled = false;

                lblCounter.Text = "Counter will be start on click of Start button";
                lblStatus.Text = "Status will be display after click on Start button";
            }

        }

        /// <summary>
        /// This timer control event will be trigger as per dynamic interval set by iterateCounter method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TimerDisplay_Tick(object sender, EventArgs e)
        {
            trafficLightSystem(TrafficLightsBonus.varCounter, TrafficLightsBonus.blPeaktime, TrafficLightsBonus.blGreenarrow);
        }

        /// <summary>
        /// This timer control event will be trigger at every 1 second which is defined in aspx design page and this timer will run counter at each 1 second.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TimerCounter_Tick(object sender, EventArgs e)
        {

            if (TrafficLightsBonus.varTimer != 0)
            {
                TrafficLightsBonus.varTimer = TrafficLightsBonus.varTimer == 1 ? TrafficLightsBonus.varTimer : TrafficLightsBonus.varTimer - 1;
                lblCounter.Text = TrafficLightsBonus.varTimer.ToString();
            }
            else
                lblError.Text = "Please select date and time.";
        }

        /// <summary>
        /// This method will be called from timerdisplay tick event as per dynamic interval which will pass counter, peaktime and greenarrow as a paramter.
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="peaktime"></param>
        /// <param name="greenArrow"></param>
        private void trafficLightSystem(int counter, bool peaktime, bool greenArrow)
        {
            switch (counter)
            {
                case 1:
                    iterateCounter(colors.Green, peaktime, greenArrow, directions.north);
                    break;

                case 2:
                    iterateCounter(colors.Yellow, peaktime, greenArrow, directions.north);
                    break;

                case 3:
                    iterateCounter(colors.Red, peaktime, greenArrow, directions.north);
                    break;

                case 4:
                    iterateCounter(colors.Green, peaktime, greenArrow, directions.eastwest);
                    break;

                case 5:
                    iterateCounter(colors.Yellow, peaktime, greenArrow, directions.eastwest);
                    break;

                case 6:
                    iterateCounter(colors.Red, peaktime, greenArrow, directions.eastwest);
                    break;

                case 7:
                    iterateCounter(colors.GreenArrow, peaktime, greenArrow, directions.south);
                    break;

                case 8:
                    iterateCounter(colors.YellowArrow, peaktime, greenArrow, directions.south);
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        /// This method will show/hide green, yellow, red or green with right-turn images as per below parameters and set timer interval again for next iteration. 
        /// Below counter values set - 
        /// For South bound 20 seconds green, 5 seconds yellow and 4 seconds for red
        /// For North bound 20 seconds green, 5 seconds green,4 seconds green, 10 seconds green with right turn, 5 seconds yellow and 4 seconds for red
        /// For East and west bound 20 seconds green, 5 seconds yellow and 4 seconds for red
        /// </summary>
        /// <param name="paramColor"></param>
        /// <param name="peakTime"></param>
        /// <param name="greenArrow"></param>
        /// <param name="paramDirection"></param>
        private void iterateCounter(colors paramColor, bool peakTime, bool greenArrow, directions paramDirection)
        {

            NorthGreen.Visible = false;
            NorthRed.Visible = false;
            SouthGreen.Visible = false;
            SouthGreenArrow.Visible = false;
            SouthYellowArrow.Visible = false;
            SouthRed.Visible = false;
            EastGreen.Visible = false;
            EastRed.Visible = false;
            WestGreen.Visible = false;
            WestRed.Visible = false;
            NorthYellow.Visible = false;
            SouthYellow.Visible = false;
            EastYellow.Visible = false;
            WestYellow.Visible = false;

            switch (paramColor)
            {
                case colors.Green:

                    if (paramDirection == directions.north)
                    {
                        if (peakTime)
                        {
                            TimerDisplay.Interval = 40000;
                            TrafficLightsBonus.varTimer = 40;
                        }
                        else
                        {
                            TimerDisplay.Interval = 20000;
                            TrafficLightsBonus.varTimer = 20;
                        }

                        TrafficLightsBonus.varCounter = 2;

                        NorthGreen.Visible = true;
                        SouthGreen.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                    }
                    else
                    {

                        if (peakTime)
                        {
                            TimerDisplay.Interval = 10000;
                            TrafficLightsBonus.varTimer = 10;
                        }
                        else
                        {
                            TimerDisplay.Interval = 20000;
                            TrafficLightsBonus.varTimer = 20;
                        }

                        TrafficLightsBonus.varCounter = 5;

                        NorthRed.Visible = true;
                        SouthRed.Visible = true;
                        EastGreen.Visible = true;
                        WestGreen.Visible = true;
                    }

                    lblStatus.Text = "Have a safe journey";
                    lblCounter.Text = TrafficLightsBonus.varTimer.ToString();

                    break;

                case colors.Yellow:

                    if (paramDirection == directions.north)
                    {
                        TrafficLightsBonus.varCounter = 3;
                        TrafficLightsBonus.varTimer = 5;

                        NorthYellow.Visible = true;
                        SouthGreen.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                    }
                    else
                    {
                        TrafficLightsBonus.varCounter = 6;
                        TrafficLightsBonus.varTimer = 5;

                        NorthRed.Visible = true;
                        SouthRed.Visible = true;
                        EastYellow.Visible = true;
                        WestYellow.Visible = true;
                    }

                    lblStatus.Text = "slow down your vehicle";
                    TimerDisplay.Interval = 5000;
                    lblCounter.Text = TrafficLightsBonus.varTimer.ToString();

                    break;

                case colors.Red:

                    if (paramDirection == directions.north && greenArrow == false)
                    {
                        TrafficLightsBonus.varCounter = 7;
                        NorthRed.Visible = true;
                        SouthGreen.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                    }
                    else if (paramDirection == directions.north && greenArrow == true)
                    {
                        TrafficLightsBonus.varCounter = 4;
                        NorthRed.Visible = true;
                        SouthRed.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                        TrafficLightsBonus.blGreenarrow = false;
                    }
                    else
                    {
                        TrafficLightsBonus.varCounter = 1;
                        NorthRed.Visible = true;
                        SouthRed.Visible = true;
                        EastRed.Visible = true;
                        WestRed.Visible = true;
                    }

                    lblStatus.Text = "stop your vehicle";
                    TimerDisplay.Interval = 4000;
                    TrafficLightsBonus.varTimer = 4;
                    lblCounter.Text = TrafficLightsBonus.varTimer.ToString();

                    break;

                case colors.GreenArrow:

                    TimerDisplay.Interval = 10000;
                    TrafficLightsBonus.varTimer = 10;
                    TrafficLightsBonus.varCounter = 8;

                    SouthGreenArrow.Visible = true;
                    NorthRed.Visible = true;
                    EastRed.Visible = true;
                    WestRed.Visible = true;

                    lblStatus.Text = "Have a safe journey with right turn allowed";
                    lblCounter.Text = TrafficLightsBonus.varTimer.ToString();

                    break;

                case colors.YellowArrow:

                    TimerDisplay.Interval = 5000;
                    TrafficLightsBonus.varTimer = 5;
                    TrafficLightsBonus.varCounter = 3;

                    TrafficLightsBonus.blGreenarrow = true;

                    SouthYellowArrow.Visible = true;
                    NorthRed.Visible = true;
                    EastRed.Visible = true;
                    WestRed.Visible = true;

                    lblStatus.Text = "slow down your vehicle";
                    lblCounter.Text = TrafficLightsBonus.varTimer.ToString();

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// On click of Start button, this event will trigger which will validate Date is selected or not and check/set peak time and call first south bound Green counter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form[txtdate.UniqueID]))
            {

                lblError.Text = string.Empty;

                DateTime dtTrafficTime = DateTime.Parse(Request.Form[txtdate.UniqueID]);
                bool peaktimeMorning = false;
                bool peaktimeEvening = false;

                TimeSpan startMorning = new TimeSpan(8, 0, 0);
                TimeSpan endMorning = new TimeSpan(10, 0, 0);
                TimeSpan startEvening = new TimeSpan(17, 0, 0);
                TimeSpan endEvening = new TimeSpan(19, 0, 0);
                TimeSpan trafficTime = dtTrafficTime.TimeOfDay;

                // see if start comes before end for morning peak time
                if (startMorning < endMorning)
                    peaktimeMorning = startMorning <= trafficTime && trafficTime <= endMorning;
                // start is after end, so do the inverse comparison
                else
                    peaktimeMorning = !(endMorning <= trafficTime && trafficTime <= startMorning);

                // see if start comes before end for evening peak time
                if (startEvening < endEvening)
                    peaktimeEvening = startEvening <= trafficTime && trafficTime <= endEvening;
                // start is after end, so do the inverse comparison
                else
                    peaktimeEvening = !(endEvening <= trafficTime && trafficTime <= startEvening);

                TrafficLightsBonus.blPeaktime = peaktimeMorning == true || peaktimeEvening == true ? true : false;

                TimerDisplay.Enabled = true;
                TimerCounter.Enabled = true;

                lblCounter.Text = TrafficLightsBonus.varTimer.ToString();

                NorthNoLight.Visible = false;
                SouthNoLight.Visible = false;
                EastNoLight.Visible = false;
                WestNoLight.Visible = false;

                iterateCounter(colors.Green, TrafficLightsBonus.blPeaktime, TrafficLightsBonus.blGreenarrow, directions.north);

            }
            else
                lblError.Text = "Please select date and time.";
        }

        /// <summary>
        /// This event will be triggered on Reset button click which will refresh whole page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        /// <summary>
        /// Below enum is used to check/set traffic lights with arrow. 
        /// </summary>
        enum colors
        {
            Green,
            Yellow,
            Red,
            GreenArrow,
            YellowArrow
        }

        /// <summary>
        /// Below enum is used to check/set traffic lights directions.
        /// </summary>
        enum directions
        {
            north,
            south,
            eastwest
        }
    }

    public static class TrafficLightsBonus
    {
        /// <summary>
        /// This static variable is used to run counter and show counter value in label lblCounter.
        /// </summary>
        public static int varCounter = 1;

        /// <summary>
        /// This variable is used to check/set counter.
        /// </summary>
        public static int varTimer = 20;

        /// <summary>
        /// This static variable is used to check/set selected time is pick time or not.
        /// </summary>
        public static bool blPeaktime = false;

        /// <summary>
        /// This flag is used to check/set green signal with right turn.
        /// </summary>
        public static bool blGreenarrow = false;
    }

}